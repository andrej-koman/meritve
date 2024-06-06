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

            // Exclude the everything before including the dashUI folder
            string filePath = file.Substring(file.IndexOf("dashUI", StringComparison.OrdinalIgnoreCase) + 7);

            fileInfo[filePath] = (fileSize, lineCount); // Use full path as key
        }

        return fileInfo;
    }

    public Dictionary<string, (long Size, int Lines)> GetFilesInfoFromArray(string[] files)
    {
        var fileInfo = new Dictionary<string, (long, int)>(); // (Size, Lines)

        foreach (var file in files)
        {
            // Check if the filename exists in the directory
            var checkFile = dir + "\\" + file;

            // If the file exists, get the file size and line count
            if (File.Exists(checkFile))
            {
                long fileSize = new FileInfo(checkFile).Length;
                int lineCount = File.ReadAllLines(checkFile).Length;

                fileInfo[file] = (fileSize, lineCount);
            }
        }
        return fileInfo;
    }

    public static string[] GetMatchingFiles(string[] files, string dir)
    {
        var matchingFiles = new List<string>();

        foreach (var file in files)
        {
            // Check if the filename exists in the directory
            var checkFile = dir + "\\" + file;

            // If the file exists, get the file size and line count
            if (File.Exists(checkFile))
            {
                matchingFiles.Add(file);
            }
        }
        return matchingFiles.ToArray();
    }
}