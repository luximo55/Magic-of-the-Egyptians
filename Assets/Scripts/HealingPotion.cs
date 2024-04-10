using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {   
            player.lives += 30;
            Destroy(this.gameObject);
        }
    }
}
