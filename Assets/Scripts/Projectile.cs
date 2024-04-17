using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float timeToLive = 2f;
    Player player;
    GameManager gameManager;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        gameManager = FindObjectOfType<GameManager>();
    }

    //Ova funkcija sluzi da unisti projektil neprijatelja nakon [timeToLive] sekundi
    private void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }

    //Ova funkcija provjerava je li projektil pogodio igraca te skida zivote igracu
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {   
            player.lives-=5;
            if(player.lives <= 0)
            {   
                gameManager.GameOver();
            }   
        }
    }
}
