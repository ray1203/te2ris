using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePage : MonoBehaviour
{
    public string thisScene;
    public GameObject pauseMenu;

    void Start(){
        thisScene = SceneManager.GetActiveScene().name;  
    }

    void Update() { 
        if (Input.GetKey(KeyCode.Escape)) {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        } 
    }

    public void Restart(){
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(thisScene);
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void startPage(){
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("start");
    }






}
