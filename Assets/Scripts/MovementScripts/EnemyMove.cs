using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [Range(55f, 55f)]
    [SerializeField]
    private float ViewRange = 100f;
    [SerializeField]
    private float detectionCheckDelays = 20f;
    private Transform targetObj = null;
    public Transform Player;
    private bool IntervalsBetwenChecks = true;

    public bool IsTargetInRange { get; private set; }

    private void Update()
    {   
        
            StartCoroutine(DetectionCourutine());
        
    }
    // Update is called once per frame
    
    private void DectecTarget()
    {
        if(targetObj == null)
        {
            ChackIfPlayerInRange();
        }else if(targetObj == Player)
        {
            DetectIfTargetOutOfRange();
        }
    }

    private void DetectIfTargetOutOfRange()
    {
        if (targetObj == Player && Vector3.Distance(transform.position, targetObj.position) < ViewRange)
        {
            targetObj = null;
        }
    }

    private void ChackIfPlayerInRange()
    {
        Collider[] Colission = Physics.OverlapSphere(transform.position, ViewRange);
        if(Colission != null)
        {
            targetObj = Player;
            if (targetObj = Player)
            {
                transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 50f * Time.deltaTime);
            }
        }
    }

    IEnumerator DetectionCourutine() 
    {
       
        yield return new WaitForSeconds ( detectionCheckDelays );
        DectecTarget();
        
        
    }
}
