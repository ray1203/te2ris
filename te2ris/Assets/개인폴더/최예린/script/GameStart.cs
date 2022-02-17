using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public AudioClip clip;

    public void StartGame()
    {
        StartCoroutine(select());
    }

    IEnumerator select()
    {
        SoundManager.instance.SFXPlay("coin", clip);
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("StageSelect");
    }
}
