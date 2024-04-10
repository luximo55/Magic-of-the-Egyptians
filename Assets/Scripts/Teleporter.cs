using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public GameObject book;
    public GameObject TeleporterWarning;

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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                if(!book)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
