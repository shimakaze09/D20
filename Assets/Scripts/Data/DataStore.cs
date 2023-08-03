using System.IO;
using UnityEngine;

public interface IDataStore : IDependency<IDataStore>
{
    bool HasFile();
    string Read();
    void Write(string json);
    void Delete();
}

public class DataStore : IDataStore
{
    public DataStore(string fileName)
    {
        FilePath = $"{Application.persistentDataPath}/{fileName}.txt";
    }

    public string FilePath { get; }


    public bool HasFile()
    {
        return File.Exists(FilePath);
    }

    public string Read()
    {
        if (File.Exists(FilePath)) return File.ReadAllText(FilePath);

        return "";
    }

    public void Write(string json)
    {
        File.WriteAllText(FilePath, json);
    }

    public void Delete()
    {
        File.Delete(FilePath);
    }
}