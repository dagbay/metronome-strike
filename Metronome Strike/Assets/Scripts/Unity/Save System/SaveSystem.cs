using UnityEngine;
using System.IO;
using Platformer.Mechanics;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{

    

    public static void SavePlayer (PlayerMovement player)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/save.bored";

        FileStream stream = new FileStream(path, FileMode.Create);
        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/save.bored";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        } else
        {
            Debug.LogError("Save file not found");
            return null;
        }

    }

    public static void DeleteSave()
    {
        string path = Application.persistentDataPath + "/save.bored";
        File.Delete(path);
    }

}

///test