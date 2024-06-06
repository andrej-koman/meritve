using System.Runtime.InteropServices;

class DirectoryInfo(string dir)
{
    private readonly string dir = dir;
    public Dictionary<string, (long Size, int Lines)> GetFilesInfo()
    {
        var fileInfo = new Dictionary<string, (long, int)>(); // (Size, Lines)

        foreach (var file in Directory.GetFiles(dir, "*.blade.php", SearchOption.AllDirectories))
        {
            long fileSize = new FileInfo(file).Length;
            int lineCount = File.ReadAllLines(file).Length;

            fileInfo[Path.GetFileName(file)] = (fileSize, lineCount);
        }

        return fileInfo;
    }

    public Dictionary<string, (long Size, int Lines)> GetFilesInfoFromArray(string[] files)
    {
        var fileInfo = new Dictionary<string, (long, int)>(); // (Size, Lines)

        foreach (var file in files)
        {
            long fileSize = new FileInfo(file).Length;
            int lineCount = File.ReadAllLines(file).Length;

            fileInfo[Path.GetFileName(file)] = (fileSize, lineCount);
        }

        return fileInfo;
    }
}