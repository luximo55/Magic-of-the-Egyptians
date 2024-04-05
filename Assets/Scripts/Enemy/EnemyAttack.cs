using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform enemy;
    public float force = 1000f;
    public float shootingInterval = 3f;
    public bool canAttack = true;
    
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(canAttack)
            {
                canAttack = false;
                Invoke("ChangeAttack", shootingInterval);
                Rigidbody projectileInstance;
                projectileInstance = Instantiate(projectile, enemy.position, enemy.rotation) as Rigidbody;
                projectileInstance.AddForce(enemy.forward * force);
            }
        }
    }
    private void ChangeAttack()
    {
        canAttack = true;
    }
}
