using System.Collections;
using UnityEngine;


public class PlayerData : MonoBehaviour
{
  

    public void Start()
    {
        SavePlayer();

        StartCoroutine(SavingCouritine());
        
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayerData(this);
        Debug.Log("Saving Data");
       
    }

    public void LoadPlayer()
    {
        LevelEntitysData data = SaveSystem.LoadPlayerData();

        Vector3 position;
        position.x = data.PlayerPosition[0];
        position.y = data.PlayerPosition[1];
        position.z = data.PlayerPosition[2];
        transform.position = new Vector3((float)position.x, (float)position.y, (float)position.z);

        Debug.Log("Loading Player Data");
        Debug.Log(data.PlayerPosition[0]);
        Debug.Log(data.PlayerPosition[1]);
        Debug.Log(data.PlayerPosition[2]);
    }
    
    IEnumerator SavingCouritine()
    {
        yield return new WaitForSeconds(5.0f);
        LoadPlayer();
       StopAllCoroutines();
    }
}
