using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerCameraData : MonoBehaviour
{
    public void Start()
    {
        SaveCamera();

        StartCoroutine(SavingCouritine());

    }
    public void SaveCamera()
    {
        SaveSystem.SaveCameraData(this);
        Debug.Log("Saving Data");

    }

    public void LoadCamera()
    {
        LevelEntitysData data = SaveSystem.LoadCameraData();

        Vector3 position;
        position.x = data.PlayerPosition[0];
        position.y = data.PlayerPosition[1];
        position.z = data.PlayerPosition[2];
        transform.position = new Vector3((float)position.x, (float)position.y, (float)position.z);

        Debug.Log("Loading Camera Data");
        Debug.Log(data.PlayerPosition[0]);
        Debug.Log(data.PlayerPosition[1]);
        Debug.Log(data.PlayerPosition[2]);
    }

    IEnumerator SavingCouritine()
    {
        yield return new WaitForSeconds(5.0f);
        LoadCamera();
        StopAllCoroutines();
    }
}
