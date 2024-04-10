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

    //Provjerava je li igrac usao u trigger napitka
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {   
            player.lives += 30;
            Destroy(this.gameObject);
        }
    }
}
