using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SavableSingleton
{
    private string savePath = "Database/saveDataAlpha.json";


    public void save()
    {
        //セーブ先のpath ****/saveData.json
        SaveData s;//セーブ対象のクラス　データは入れておく
        s = new SaveData();

        string json = JsonUtility.ToJson(s);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(savePath);
        bf.Serialize(file, json);
        file.Close();
    }

    public void load()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(savePath, FileMode.Open);
        string json = (string)bf.Deserialize(file);
        file.Close();
        SaveData saveData = JsonUtility.FromJson<SaveData>(json);
        Debug.Log(saveData.player.getLevel());

    }
}
