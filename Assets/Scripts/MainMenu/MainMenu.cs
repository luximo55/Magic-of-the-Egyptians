using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{

 public void Play()
 {
    SceneManager.LoadScene("Level1");
 }

 public void Exit()
 {
    Application.Quit();
 }
}
