using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class EnemyMov : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(player.position);
    }
}


