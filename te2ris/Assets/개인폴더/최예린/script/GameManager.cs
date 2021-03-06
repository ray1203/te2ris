using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string thisScene;
    public GameObject pauseMenu;
    public static GameManager instance;
    public GameObject gameoverMenu;
    private void Awake()
    {
        instance = this;
    }
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

    public void gotoStage(){
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("StageSelect");
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameoverMenu.SetActive(true);
        gameoverMenu.transform.localScale = new Vector3(1f, 1f, 1f);
    }





}
