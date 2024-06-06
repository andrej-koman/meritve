string newThemeDirString = "C:\\xampp\\htdocs\\cms2022\\resources\\views\\dashUI";
string oldThemeDirString = "C:\\xampp\\htdocs\\cms2022\\resources\\views";

var newThemeDir = new DirectoryInfo(newThemeDirString);
var oldThemeDir = new DirectoryInfo(oldThemeDirString);
var newThemeInfo = newThemeDir.GetFilesInfo();

// Create a new array out of all the keys in the newThemeInfo dictionary
var newThemeFiles = newThemeInfo.Keys.ToArray();
var oldThemeInfo = oldThemeDir.GetFilesInfoFromArray(newThemeFiles);

// Create a new array that will be all the files that match eachother
var matchingFiles = DirectoryInfo.GetMatchingFiles(newThemeFiles, oldThemeDirString);

var oldThemeFiles = oldThemeInfo.Keys.ToArray();

// Write to console number off all files in the old theme
Console.WriteLine($"Number of files in the old theme: {oldThemeInfo.Count}");

// Write to console number off all files in the new theme
Console.WriteLine($"Number of files in the new theme: {newThemeInfo.Count}");

// Make the graphs
// Size graph
var sizeGraph = new Graph("Velikost datotek");
var sizeOld = new List<long>();
var sizeNew = new List<long>();

// Add the line series to the graphs
for(int i = 0; i < matchingFiles.Length; i++)
{
    sizeOld.Add(oldThemeInfo[matchingFiles[i]].Size / 1000);
    sizeNew.Add(newThemeInfo[matchingFiles[i]].Size / 1000);
}

sizeGraph.AddLineSeries([.. sizeOld], "Stara tema");
sizeGraph.AddLineSeries([.. sizeNew], "Nova tema");

sizeGraph.SaveAsPNG(1280, 720);

// Calculate some total statistics
long oldSize = 0;
long newSize = 0;

int oldLines = 0;
int newLines = 0;

foreach (var file in oldThemeInfo)
{
    oldSize += file.Value.Size;
    oldLines += file.Value.Lines;
}

foreach (var file in newThemeInfo)
{
    newSize += file.Value.Size;
    newLines += file.Value.Lines;
}

Console.WriteLine($"Old theme size: {oldSize / 1000} KB");
Console.WriteLine($"New theme size: {newSize / 1000} KB");

Console.WriteLine($"Old theme lines: {oldLines}");
Console.WriteLine($"New theme lines: {newLines}");