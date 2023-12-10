using System.Collections;
using UnityEngine;

public class CillynderData : MonoBehaviour
{

    public void Start()
    {
        SaveSystem.DeleteCillynderData();
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
        position.x = data.CillynderPosition[0];
        position.y = data.CillynderPosition[1];
        position.z = data.CillynderPosition[2];
        transform.position = new Vector3((float)position.x, (float)position.y, (float)position.z);

        Debug.Log("Loading Cillynder Data");
        Debug.Log(data.CillynderPosition[0]);
        Debug.Log(data.CillynderPosition[1]);
        Debug.Log(data.CillynderPosition[2]);
    }

    IEnumerator SavingCouritine()
    {
        //demonstration
        do
        {
            yield return new WaitForSeconds(5.0f);
            SaveCillynder();
            yield return new WaitForSeconds(5.0f);
            LoadCillynder();
            LoadCillynder();
            LoadCillynder();
            yield return new WaitForSeconds(5.0f);
            SaveSystem.DeleteCillynderData();
            Debug.Log("Deleted");
            yield return new WaitForSeconds(3.0f);
        }while (true);

    }
}
