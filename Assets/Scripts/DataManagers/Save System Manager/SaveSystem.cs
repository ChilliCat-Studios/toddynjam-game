using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayerData(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "TestPlayerSave.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelEntitysData data = new LevelEntitysData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveCillynderData(CillynderData playerCillynder)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "TestPlayerCillynderSave.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelEntitysData data = new LevelEntitysData(playerCillynder);

        formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void SaveCameraData(MainPlayerCameraData playerCamera)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "TestPlayerCameraSave.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelEntitysData data = new LevelEntitysData(playerCamera);

        formatter.Serialize(stream, data);
        stream.Close();
    }



    public static LevelEntitysData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "TestPlayerSave.fun";

        if (File.Exists(path)) 
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelEntitysData data = formatter.Deserialize(stream) as LevelEntitysData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File Not Found in " + path);
            return null;
        }
    }

    public static LevelEntitysData LoadCillynderData()
    {
        string path = Application.persistentDataPath + "TestPlayerCillynderSave.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelEntitysData data = formatter.Deserialize(stream) as LevelEntitysData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File Not Found in " + path);
            return null;
        }
    }

    public static LevelEntitysData LoadCameraData()
    {
        string path = Application.persistentDataPath + "TestPlayerCameraSave.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelEntitysData data = formatter.Deserialize(stream) as LevelEntitysData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File Not Found in " + path);
            return null;
        }
    }




    public static void SaveEnemyData(EnemyData enemy)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "TestEnemySave.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelEnemyData data = new LevelEnemyData(enemy);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelEnemyData LoadEnemyData()
    {
        string path = Application.persistentDataPath + "TestEnemySave.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelEnemyData data = formatter.Deserialize(stream) as LevelEnemyData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.Log("File Not Found in " + path);
            return null;
        }
    }
}
