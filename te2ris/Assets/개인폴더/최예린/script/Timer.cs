using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public string thisScene;
    public Text timerTxt;
    public GameObject fail;
    public float time = 200f;
    private float selectCountdown;

    void Start()
    {
        selectCountdown = time;
        thisScene = SceneManager.GetActiveScene().name;
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Mathf.Floor(selectCountdown) <= 0)
        {
            fail.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            selectCountdown -= Time.deltaTime;
            timerTxt.text = Mathf.Floor(selectCountdown).ToString();
        }
    }

    public void gotoStageList()
    {
        SceneManager.LoadScene("StageSelect");
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(thisScene);
    }
}
