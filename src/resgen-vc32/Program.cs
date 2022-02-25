// See https://aka.ms/new-console-template for more information

using resgen_vc32;
using resgen_vc32.Vircon32.Xml;

if (args.Length < 1)
{
    Console.WriteLine($"Usage: resgen-vc32.exe <filename.xml>");

    return;
}

var inputFilename = args[0];

if (!File.Exists(inputFilename))
{
    Console.WriteLine($"ERROR: cannot open file \"{inputFilename}\"");

    return;
}

var outputFilename = args.Length > 1 ?
    args[1] :
    Path.Combine(Path.GetDirectoryName(inputFilename), "Resources.h");

using (var inputFile = File.OpenRead(inputFilename))
{
    var deserializer = new Vircon32XmlSerializer();
    var romDefinition = deserializer.Deserialize(inputFile);

    using (var outputFile = File.Create(outputFilename))
    {
        var headerWriter = new ResourcesHeaderWriter(outputFile);
        headerWriter.Write(romDefinition);
    }
}