using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public float timeToLive = 1f;
    private void Start()
    {
        Destroy(this.gameObject, timeToLive);
    }
}
