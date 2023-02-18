using System.Text;

public class Wrapper
{
    public static readonly string Cyrillic = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";

    public static FileStream CreateIfNotExist(string path)
    {
        return File.Exists(path) ? File.Open(path, FileMode.OpenOrCreate) : File.Create(path);
    }

    public static void WriteStringInFile(string path, string text)
    {
        using var sw = new StreamWriter(path);
        sw.Write(text);
    }

    public static void InitializeDirectory(params string[] paths)
    {
        foreach (var item in paths)
        {
            Wrapper.CreateIfNotExist(item).Dispose();
        }
    }

    public static string GetStringInFile(string path, Encoding encoding, string? separator = null)
    {
        using var sr = new StreamReader(path, encoding);
            return sr.ReadToEnd();
    }
}
