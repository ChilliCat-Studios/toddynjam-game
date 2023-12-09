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
    private float detectionCheckDelays = 0.1f;
    public Transform targetObj = null;
    public Transform Player;
   

    public bool IsTargetInRange { get; private set; }

    private void Start()
    {
        StartCoroutine(DetectionCourutine());
    }
    // Update is called once per frame
    private void Update()
    {
        StartCoroutine(DetectionCourutine());
    }
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
                transform.position = Vector3.MoveTowards(this.transform.position, targetObj.position, 10f * Time.deltaTime);
            }
        }
    }

    IEnumerator DetectionCourutine() 
    {
        yield return new WaitForSeconds(detectionCheckDelays);
        DectecTarget();
        StartCoroutine(DetectionCourutine());
    }
}
