using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject StartObj;
    public GameObject PauseMenu;
    public GameObject Game;
    public GameObject WinPanel;
    public GameObject GameOver;

    public void Pause()
    {
        StartObj.SetActive(false);
        PauseMenu.SetActive(true);
        Game.SetActive(false);
        WinPanel.SetActive(false);
        GameOver.SetActive(false);

        Time.timeScale = 0;
    }

    public void Over()
    {
        StartObj.SetActive(false);
        PauseMenu.SetActive(false);
        Game.SetActive(false);
        WinPanel.SetActive(false);
        GameOver.SetActive(true);

        Time.timeScale = 0;
    }

    public void Win()
    {
        StartObj.SetActive(false);
        PauseMenu.SetActive(false);
        Game.SetActive(false);
        WinPanel.SetActive(true);
        GameOver.SetActive(false);

        Time.timeScale = 0;
    }

    public void StartGame() 
    {
        StartObj.SetActive(false); 
        PauseMenu.SetActive(false);
        Game.SetActive(true);
        WinPanel.SetActive(false);
        GameOver.SetActive(false);

        Time.timeScale = 1;
    }

    public void Continue(){
        StartObj.SetActive(false);
        PauseMenu.SetActive(false);
        Game.SetActive(true);
        WinPanel.SetActive(false);
        GameOver.SetActive(false);

        Time.timeScale = 1;
    }

    public void Resume()
    {
        StartObj.SetActive(false);
        PauseMenu.SetActive(false);
        Game.SetActive(true);
        WinPanel.SetActive(false);
        GameOver.SetActive(false);

        Time.timeScale = 1;
    }

    // public void Exit()
    // {                         	
    //     Time.timeScale = 1;
    //     SceneManager.LoadScene("MainMenu");
    // }

    public void lvl2()
    {                         	
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_2");
    }

    public void lvl3()
    {                         	
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_3");
    }

    public void lvl4()
    {                         	
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_4");
    }

    public void lvl5()
    {                         	
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_5");
    }

    public void Again()
    {    
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_1");
    }

    public void Again2()
    {    
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_2");
    }

    public void Again3()
    {    
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_3");
    }

    public void Again4()
    {    
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_4");
    }

    public void Again5()
    {    
        Time.timeScale = 1;
        SceneManager.LoadScene("nivel_5");
    }

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

