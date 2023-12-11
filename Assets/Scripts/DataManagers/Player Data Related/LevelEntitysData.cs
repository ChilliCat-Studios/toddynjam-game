using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;


[System.Serializable]
public class LevelEntitysData
{
    public float[] PlayerPosition;
    public float[] CameraPosition;
    public float[] CillynderPosition;


    public LevelEntitysData (PlayerData player)
    {
         PlayerPosition = new float[3];
        {
            PlayerPosition[0] = player.transform.position.x;
            PlayerPosition[1] = player.transform.position.y;
            PlayerPosition[2] = player.transform.position.z;
        }
       
    }
    public LevelEntitysData(CillynderData playerCillynder)
    {
        CillynderPosition = new float[3];
        {
            CillynderPosition[0] = playerCillynder.transform.position.x;
            CillynderPosition[1] = playerCillynder.transform.position.y;
            CillynderPosition[2] = playerCillynder.transform.position.z;
        }

    }
    public LevelEntitysData(MainPlayerCameraData playerCamera)
    {
        CameraPosition = new float[3];
        {
            CameraPosition[0] = playerCamera.transform.position.x;
            CameraPosition[1] = playerCamera.transform.position.y;
            CameraPosition[2] = playerCamera.transform.position.z;
        }

    }

}
