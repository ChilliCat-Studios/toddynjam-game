using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Runtime.InteropServices.ComTypes;

public static class SaveSystem
{
    public static void SavePlayerData(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/TestPlayerSave.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelEntitysData dataPlayer = new LevelEntitysData(player);

        formatter.Serialize(stream, dataPlayer);
        stream.Close();
    }
    public static void SaveCillynderData(CillynderData playerCillynder)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/TestPlayerCillynderSave.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelEntitysData dataCillynder = new LevelEntitysData(playerCillynder);

        formatter.Serialize(stream, dataCillynder);
        stream.Close();
    }
    public static void SaveCameraData(MainPlayerCameraData playerCamera)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/TestPlayerCameraSave.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelEntitysData dataCamera = new LevelEntitysData(playerCamera);

        formatter.Serialize(stream, dataCamera);
        stream.Close();
    }



    public static LevelEntitysData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/TestPlayerSave.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelEntitysData dataPlayer = formatter.Deserialize(stream) as LevelEntitysData;
            stream.Close();

            return dataPlayer;
        }
        else
        {
            Debug.LogError("File Not Found in " + path);
            return null;
        }
    }

    public static LevelEntitysData LoadCillynderData()
    {
        string path = Application.persistentDataPath + "/TestPlayerCillynderSave.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelEntitysData dataCillynder = formatter.Deserialize(stream) as LevelEntitysData;
            stream.Close();

            return dataCillynder;
        }
        else
        {
            Debug.LogError("File Not Found in " + path);
            return null;
        }
    }

    public static LevelEntitysData LoadCameraData()
    {
        string path = Application.persistentDataPath + "/TestPlayerCameraSave.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelEntitysData dataCamera = formatter.Deserialize(stream) as LevelEntitysData;
            stream.Close();

            return dataCamera;
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

        string path = Application.persistentDataPath + "/TestEnemySave.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelEnemyData data = new LevelEnemyData(enemy);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelEnemyData LoadEnemyData()
    {
        string path = Application.persistentDataPath + "/TestEnemySave.fun";

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

    public static void DeletePlayerData()
    {
        File.Delete(Application.persistentDataPath + "/TestPlayerSave.fun");
    }
    public static void DeleteCameraData()
    {
        File.Delete(Application.persistentDataPath + "/TestPlayerCameraSave.fun");
    }
    public static void DeleteCillynderData()
    {
        File.Delete(Application.persistentDataPath + "/TestPlayerCillynderSave.fun");
    }
    public static void DeleteEnemyData()
    {
        File.Delete(Application.persistentDataPath + "/TestEnemySave.fun");
    }
}
    
