using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

string newThemeDirString = "C:\\xampp\\htdocs\\cms2022\\resources\\views\\dashUI";
string oldThemeDirString = "C:\\xampp\\htdocs\\cms2022\\resources\\views";

var newThemeDir = new DirectoryInfo(newThemeDirString);
var oldThemeDir = new DirectoryInfo(oldThemeDirString);
var newThemeInfo = newThemeDir.GetFilesInfo();
// Create a new array out of all the keys in the newThemeInfo dictionary
var newThemeFiles = newThemeInfo.Keys.ToArray();

foreach (var file in newThemeFiles)
{
    Console.WriteLine(file);
}
/*
foreach (var (fileName, (size, lines)) in newThemeInfo)
{
    Console.WriteLine($"{fileName} - Size: {size} bytes, Lines: {lines}");
}
*/