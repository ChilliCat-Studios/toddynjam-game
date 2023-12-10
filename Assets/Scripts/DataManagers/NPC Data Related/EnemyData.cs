using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(SavingCouritine());
    }
    public void SaveEnemy()
    {
        SaveSystem.SaveEnemyData(this);
        Debug.Log("SavingData");
    }

    public void LoadEnemy()
    {
        LevelEnemyData data = SaveSystem.LoadEnemyData();

        Vector3 position;
        position.x = data.CubePosition[0];
        position.y = data.CubePosition[1];
        position.z = data.CubePosition[2];
    }

    IEnumerator SavingCouritine()
    {

        yield return new WaitForSeconds(7.0f);
        SaveEnemy();
        StartCoroutine(SavingCouritine());
    }

}
