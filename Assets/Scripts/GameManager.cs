using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Player player;
    public Text livesText;

    private void Start()
    {
        GameOverPanel.SetActive(false);
        livesText.text = player.lives.ToString();
    }

    //Ova funkcija sluzi da azurira tekst zivota igraca
    private void Update()
    {
        livesText.text = player.lives.ToString();
    }

    //Ovo je funkcija koja se pokrece kada igrac izgubi sve zivote
    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
