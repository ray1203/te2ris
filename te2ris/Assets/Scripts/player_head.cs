using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_head : MonoBehaviour
{
    public AudioClip clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            SoundManager.instance.SFXPlay("head", clip);
            GameManager.instance.GameOver();

        }
    }
}
