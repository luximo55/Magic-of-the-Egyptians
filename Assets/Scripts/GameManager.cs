using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public Player player;
    public Text livesText;
    public Text totalEnemiesText;
    public Text reamainingHealthText;
    public Text gradeText;
    public GameObject music;
    public GameObject hand;
    public GameObject levelEnd;
    string grade;
    float livesGrade;
    float killGrade;
    int startEnemyNo;
    float enemiesKilledPer;
    public List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            DontDestroyOnLoad(music);
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        startEnemyNo = enemies.Count;
        hand.SetActive(true);
        levelEnd.SetActive(false);
        GameOverPanel.SetActive(false);
        livesText.text = player.lives.ToString();
    }

    //Ova funkcija sluzi da azurira tekst zivota igraca
    private void Update()
    {
        livesText.text = player.lives.ToString();
    }

    //Ova funkcija brise neprijatelja iz liste
    public void EnemyDie(int index)
    {
        enemies.RemoveAt(index);
    }

    //Ova funkcija pokrece zavrsnu sekvencu nivoa
    public void LevelEnd()
    {
        hand.SetActive(false);
        levelEnd.SetActive(true);
        TotalEnemiesKilled();
        Grade();
        Time.timeScale = 0;
        totalEnemiesText.text = enemiesKilledPer.ToString() + "%";
        reamainingHealthText.text = player.lives.ToString();
        gradeText.text = grade;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    //Ova funkcija racuna postotak ubijenih neprijatelja
    private void TotalEnemiesKilled()
    {
        float enemiesKilled = startEnemyNo - enemies.Count;
        enemiesKilledPer = enemiesKilled / startEnemyNo;
        enemiesKilledPer *= 100;
        enemiesKilledPer = Mathf.RoundToInt(enemiesKilledPer);
        Debug.Log(enemiesKilledPer + "%");
    }
    
    //Ova funkcija racuna ocjenu igre
    private void Grade()
    {
        switch(player.lives)
        {
            case >=85:
                livesGrade = 5;
                break;
            case >=70:
                livesGrade = 4;
                break;
            case >=60:
                livesGrade = 3;
                break;
            case >=50:
                livesGrade = 2;
                break;
            case <50:
                livesGrade = 1;
                break;
            default:
                Debug.Log("Failed to grade lives");
                break;
        }
        switch(enemiesKilledPer)
        {
            case >=85:
                killGrade = 5;
                break;
            case >=70:
                killGrade = 4;
                break;
            case >=60:
                killGrade = 3;
                break;            
            case >=50:
                killGrade = 2;
                break;
            case <50:
                killGrade = 1;
                break;
            default:
                Debug.Log("Failed to grade kills");
                break;
        }
        Debug.Log(livesGrade + " lives");
        Debug.Log(killGrade + " kills");
        if((livesGrade + killGrade) / 2 >= 4.5)
        {
            grade = "A";
        }
        else if((livesGrade + killGrade) / 2 >= 3.5)
        {
            grade = "B";
        }
        else if ((livesGrade + killGrade) / 2 >= 2.5)
        {
            grade = "C";
        }
        else if ((livesGrade + killGrade) / 2 >= 1.5)
        {
            grade = "D";
        }
        else if ((livesGrade + killGrade) / 2 == 1)
        {
            grade = "F";
        }
        else 
        {
            Debug.Log("Failed to grade total grade");
        }
    }

    //Ovo je funkcija koja se pokrece kada igrac izgubi sve zivote
    public void GameOver()
    {
        Time.timeScale = 0;
        hand.SetActive(false);
        GameOverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
