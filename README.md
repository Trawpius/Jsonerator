# Jsonerator
Takes a .json file and builds a C# .cs file

## Design Platform

Language: C#
Framework: .NET 6.0
Output Type: Console Application

Developed on Windows 10 using Visual Studio 2022

## Function

Program accepts two arguments
[filepath] [namespace]
  - Filepath is the absolute path to the .json file the user wishes to convert into a .cs file
  - Namespace is the namespace to use in the .cs file

Reads all text from the .json file
Uses Newtonsoft to deserialize .json file into JObject
Parses JObject to simplify hierarchy of objects, arrays, and property types
Uses that hierarchy to format the string output
Creates and writes to a .cs file in the active directory
Currently designs to generate C# style objects only
