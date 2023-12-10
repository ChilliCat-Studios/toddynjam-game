using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerCameraData : MonoBehaviour
{
    public void Start()
    {
        SaveSystem.DeleteCameraData();
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
        position.x = data.CameraPosition[0];
        position.y = data.CameraPosition[1];
        position.z = data.CameraPosition[2];
        transform.position = new Vector3((float)position.x, (float)position.y, (float)position.z);

        Debug.Log("Loading Camera Data");
        Debug.Log(data.CameraPosition[0]);
        Debug.Log(data.CameraPosition[1]);
        Debug.Log(data.CameraPosition[2]);
    }

    IEnumerator SavingCouritine()
    {
        //demonstration
        do
        {
            yield return new WaitForSeconds(5.0f);
            SaveCamera();
            yield return new WaitForSeconds(5.0f);
            LoadCamera();
            LoadCamera();
            LoadCamera();
            yield return new WaitForSeconds(5.0f);
            SaveSystem.DeleteCameraData();
            Debug.Log("Deleted");
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(SavingCouritine());
        }while (true);
    }
}
