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
var oldThemeInfo = oldThemeDir.GetFilesInfoFromArray(newThemeFiles);

foreach (var (fileName, (size, lines)) in oldThemeInfo)
{
    Console.WriteLine($"{fileName} - Size: {size} bytes, Lines: {lines}");
}
// Write to console number off all files in the old theme
Console.WriteLine($"Number of files in the old theme: {oldThemeInfo.Count}");

// Write to console number off all files in the new theme
Console.WriteLine($"Number of files in the new theme: {newThemeInfo.Count}");