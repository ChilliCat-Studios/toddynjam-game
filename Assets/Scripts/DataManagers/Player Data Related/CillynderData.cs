using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CillynderData : MonoBehaviour
{

    public void Start()
    {
        SaveCillynder();

        StartCoroutine(SavingCouritine());

    }
    public void SaveCillynder()
    {
        SaveSystem.SaveCillynderData(this);
        Debug.Log("Saving Data");

    }

    public void LoadCillynder()
    {
        LevelEntitysData data = SaveSystem.LoadCillynderData();

        Vector3 position;
        position.x = data.PlayerPosition[0];
        position.y = data.PlayerPosition[1];
        position.z = data.PlayerPosition[2];
        transform.position = new Vector3((float)position.x, (float)position.y, (float)position.z);

        Debug.Log("Loading Cillynder Data");
        Debug.Log(data.PlayerPosition[0]);
        Debug.Log(data.PlayerPosition[1]);
        Debug.Log(data.PlayerPosition[2]);
    }

    IEnumerator SavingCouritine()
    {
        yield return new WaitForSeconds(5.0f);
        LoadCillynder();
        StopAllCoroutines();
    }
}
