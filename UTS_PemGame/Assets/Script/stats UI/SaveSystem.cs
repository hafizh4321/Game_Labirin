using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PG
{
    public static class SaveSystem
    {
        public static void SavePlayer(PlayerStats playerStats)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            string path = Application.persistentDataPath + "/player.data";
            FileStream stream = new FileStream(path, FileMode.Create);

            PlayerData data = new PlayerData(playerStats);

            formatter.Serialize(stream, data);
            stream.Close();
        }

        public static PlayerData LoadPlayer()
        {
            string path = Application.persistentDataPath + "/player.data";

            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);
                PlayerData data = formatter.Deserialize(stream) as PlayerData;

                stream.Close();
                return data;
            }
            else
            {
                Debug.LogError("save file not found in " + path);
                return null;
            }

        }
    }
}