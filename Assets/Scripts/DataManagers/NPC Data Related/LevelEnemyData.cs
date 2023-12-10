using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelEnemyData
{
    public float[] CubePosition;
   

    public LevelEnemyData(EnemyData enemy)
    {
        CubePosition = new float[3];
        {
            CubePosition[0] = enemy.transform.position.x;
            CubePosition[1] = enemy.transform.position.y;
            CubePosition[2] = enemy.transform.position.z;
        }
       
    }
}
