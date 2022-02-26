# resgen-vc32
Generates header files from Vircon32 XML ROM definitions.

## Overview
resgen-vc32 is a .NET 6 command line tool that generates header files from [Vircon32](http://www.vircon32.com/) ROM definition XML files. The header file consists of macro definitions for each of the texture and sound files included in the project, helping minimize issues when adding new assets or renaming them.

## Prerequisites
You will need to install [.NET 6](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) to be able to run this tool.

## Usage
`resgen-vc32.exe <romdefinition.xml> [path/to/output/file]`

Note that the output file parameter is optional - if not specified, the tool will generate a `Resources.h` file in the same directory as the input XML file.

As an example, processing the following XML file

```xml
<?xml version="1.0" encoding="UTF-8" standalone="no" ?>
<rom-definition version="1.0">
    <rom type="cartridge" title="2048" version="1.0" />
    <binary path="obj/Main.vbin" />
    <textures>
        <texture path="obj/Texture2048.vtex" />
    </textures>
    <sounds>
        <sound path="obj/MusicTitle.vsnd" />
    </sounds>
</rom-definition>
```

Will output the following header file

```c
#ifndef __RESOURCES_H__
#define __RESOURCES_H__


// TEXTURES

#define Texture2048                              0

// SOUNDS

#define MusicTitle                               0


#endif
```
