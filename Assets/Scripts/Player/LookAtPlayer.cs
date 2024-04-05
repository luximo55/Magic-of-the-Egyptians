using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Player player;
    
    //Ova cijela skripta sluzi da se objekti mogu okretati 
    private void Awake()
    {
        player = FindFirstObjectByType<Player>();
    }
    void Update()
    {
        if(Vector3.Distance(this.transform.position, player.transform.position) > 0.1f)
        {
            transform.LookAt(player.transform);
        }
    }
}
