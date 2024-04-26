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
    public int index;
    GameManager gameManager;
    Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    //Ova funkcija sluzi za skidanje zivota neprijatelju
    public void Hit()
    {
        lives--;

        if(lives <= 0)
        {
            index = gameManager.enemies.IndexOf(this.enemy);
            gameManager.EnemyDie(index);
            Destroy(this.gameObject);
        } 
    }

    //Ova funkcija sluzi za AI enemya, kada igrac ude u Collider enemy krene prema igracu
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(Vector3.Distance(this.transform.position, player.position) > 1.2f)
            {
                agent.SetDestination(player.position);
            }
        }
    }

    public void FollowHit()
    {
            if(Vector3.Distance(this.transform.position, player.position) > 1.2f)
            {
                agent.SetDestination(player.position);
            }
    }
    
}
