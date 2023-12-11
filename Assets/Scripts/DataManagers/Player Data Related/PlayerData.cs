using System.Collections;
using UnityEngine;


public class PlayerData : MonoBehaviour
{

    PlayerMovement controller;
    private void Start()
    {
        // controller = GetComponent<PlayerMovement>();
        SaveSystem.DeletePlayerData();
        StartCoroutine(SavingCouritine());
        
    }
    private void SavePlayer()
    {
        SaveSystem.SavePlayerData(this);
        Debug.Log("Saving Data");
       
    }
    
    private void LoadPlayer()
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
        //demonstration
        do
        {
            yield return new WaitForSeconds(5.0f);
            SavePlayer();
            yield return new WaitForSeconds(5.0f);
            LoadPlayer();
            LoadPlayer();
            LoadPlayer();
            yield return new WaitForSeconds(5.0f);
            SaveSystem.DeletePlayerData();
            Debug.Log("Deleted");
            yield return new WaitForSeconds(3.0f);
            StartCoroutine(SavingCouritine());
        }while(true);
    }
}
