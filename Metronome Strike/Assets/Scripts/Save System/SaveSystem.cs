using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;




public static class SaveSystem
{

    string path = Application.persistenDataPath + "/player.bored";
    public static void SavePlayer (PlayerController player)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        FileSteam stream = new FileSteam(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {

        
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileSteam stream = new FileSteam(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();
            return data;

        } else
        {
            Debug.LogError("Save file not found");
            return null
        }

    }

}
