using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NewBehaviourScript : MonoBehaviour
{
    public NavMeshAgent Enemy;
    public Transform player;
    // Update is called once per frame
    void Update()
    {
        Enemy.SetDestination(player.position);
    }
}
