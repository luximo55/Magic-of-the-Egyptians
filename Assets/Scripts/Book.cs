using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour
{
    public GameObject bookDestroyed;
    public GameObject enemies;

    private void Start()
    {
        bookDestroyed.SetActive(false);
    }

    //Ova funkcija sluzi da provjeri je li knjigu pogodio metak
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Debug.Log("Knjiga unistena");
            bookDestroyed.SetActive(true);
            Destroy(this.gameObject);
            Destroy(enemies);
        }
    }
}
