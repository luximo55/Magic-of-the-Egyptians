using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;
    
    //Ova cijela skripta sluzi da se objekti mogu okretati 
    void Update()
    {
        if(Vector3.Distance(this.transform.position, player.position) > 0.1f)
        {
            transform.LookAt(player);
        }
    }
}
