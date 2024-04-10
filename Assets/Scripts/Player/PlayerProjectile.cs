using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float timeToLive = 1f;

    //Ova skripta sluzi da unisti projektil igraca nakon [timeToLive] sekundi
    private void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }
}
