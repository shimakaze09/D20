using UnityEngine;

public interface IDataSerializer : IDependency<IDataSerializer>
{
    string Serialize(Data data);
    Data Deserialize(string json);
}

public class DataSerializer : IDataSerializer
{
    public string Serialize(Data data)
    {
        var result = JsonUtility.ToJson(data);
        Debug.Log(result);
        return result;
    }

    public Data Deserialize(string json)
    {
        return JsonUtility.FromJson<Data>(json);
    }
}