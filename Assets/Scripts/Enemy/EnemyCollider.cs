using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    //Ova funkcija sluzi da provjeri je li neprijatelja pogodio metak igraca
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemy.Hit();
            enemy.FollowHit();
            Destroy(other.gameObject);
        }
    }
}
