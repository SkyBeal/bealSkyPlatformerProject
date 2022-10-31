using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{
    public GameObject LoseScreen;
    void Start()
    {
        Application.targetFrameRate = 60;
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        LoseScreen.SetActive(false);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Dead2()
    {
        SceneManager.LoadScene(2);
    }
    public void Dead3()
    {
        SceneManager.LoadScene(3);
    }
}
