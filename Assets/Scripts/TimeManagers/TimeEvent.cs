using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUI : MonoBehaviour
{
    public Transform Player;
    protected Transform targetObj;

    
    void Start()
    {
        targetObj = Player;
    }
    private void Update()
    {
        checkTime();
    }

    private void checkTime()
    {
        if (TimeManager.Hour == 1)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 50f * Time.deltaTime);
        }
    }
}
