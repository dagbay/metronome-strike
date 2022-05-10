using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem{

    public static void SavePlayer (PlayerController player)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistenDataPath + "/player.bored";
        FileSteam stream = new FileSteam(path, FIleMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.close();
    }

    public static PlayerData LoadPlayer()
    {

        string path = Application.persistenDataPath + "/player.bored";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileSteam stream = new FileSteam(path, FIleMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        } else
        {
            Debug.LogError("Save file not found");
            return null;
        }

    }

}
