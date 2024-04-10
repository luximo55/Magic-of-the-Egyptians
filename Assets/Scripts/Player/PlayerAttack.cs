using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Rigidbody shootingProjectile;
    public float force = 10000f;

    //Ova skripta sluzi za ispaljivanje metaka
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Rigidbody projectileInstance;
            projectileInstance = Instantiate(shootingProjectile, transform.position, transform.rotation) as Rigidbody;
            projectileInstance.AddForce(transform.forward * force);
        }
    }
}
