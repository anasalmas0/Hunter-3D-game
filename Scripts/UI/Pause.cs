using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Pause : MonoBehaviour
{
    public static bool gameIsPause = false;
    public GameObject PauseUI;
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void pauseButton () {
        pause();
    }

    public void pause(){
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPause = true ;

    }

    public void Resume(){
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPause = false ;
        
    }

    public void MainMenu (string sceneName) {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
        gameIsPause = false;
    }
}
