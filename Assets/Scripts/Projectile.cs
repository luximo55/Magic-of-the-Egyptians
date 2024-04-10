using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Build.Content;
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

    private void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {   
            player.lives--;
            if(player.lives <= 0)
            {   
                gameManager.GameOver();
            }   
        }
    }
}
