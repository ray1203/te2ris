using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePage : MonoBehaviour
{
    public static bool GameIsPaused = false; 
    public GameObject pauseMenuCanvas; 
    
    void Update() { 
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused) 
                Resume();  
            else 
                Pause(); 
        } 
    }

    public void Resume() {
        pauseMenuCanvas.SetActive(false); 
        Time.timeScale = 1f; 
        GameIsPaused = false; 
    }

    public void Pause() { 
        pauseMenuCanvas.SetActive(true); 
        Time.timeScale = 1f; 
        GameIsPaused = true; 
    }

    
    

    
}
