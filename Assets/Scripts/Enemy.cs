using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public float speed = 5.0f;
    public Transform player;
    private Rigidbody rb;
    public float vision = 10.0f;
    public int lives = 3;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }


    //Ova funkcija sluzi za AI enemya, kada igrac ude u Collider enemy krene prema igracu
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Vector3.Distance(this.transform.position, player.position) > 1.2f)
            {
                //Debug.Log("OnTriggerStay");
                agent.SetDestination(player.position);
            }
        }
    }
}
