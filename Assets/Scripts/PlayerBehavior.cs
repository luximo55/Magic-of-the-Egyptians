using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        if()
         {
            PlayerTakeDamage(20);
            Debug.Log(GameManager.gameManager._playerHealth.Health);
         }
         if()
         {
            PlayerHeal(10);
         }
    }

    private void PlayerTakeDamage(int dmg)
    {
        GameManager.gameManager._playerHealth.DamageUnit(dmg);
    }

      private void PlayerHeal(int healing)
    {
        GameManager.gameManager._playerHealth.HealUnit(healing);
    }
}
