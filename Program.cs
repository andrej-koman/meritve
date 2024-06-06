using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

string classicThemeDir = "C:\\xampp\\htdocs\\cms2022\\resources\\views";
string newThemeDir = "C:\\xampp\\htdocs\\cms2022\\resources\\views\\dashUI";


var newThemeDirectory = new DirectoryInfo(newThemeDir);
var newThemeInfo = newThemeDirectory.GetFilesInfo();

Console.WriteLine("Classic Theme Files:");
foreach (var (fileName, (size, lines)) in newThemeInfo)
{
    Console.WriteLine($"{fileName} - Size: {size} bytes, Lines: {lines}");
}

// Testing graph

