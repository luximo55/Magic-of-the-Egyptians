using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public GameObject book;
    public GameObject TeleporterWarning;
    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    //Ova cijela skripta sluzi za transportiranje igraca medu levelima
    private void Start()
    {
        TeleporterWarning.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(SceneManager.GetActiveScene().buildIndex != 3)
            {
                gameManager.LevelEnd();
            }
            else if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                if(!book)
                {
                    gameManager.LevelEnd();
                }
                else 
                {
                    TeleporterWarning.SetActive(true);
                }
            }
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        TeleporterWarning.SetActive(false);
    }
}
