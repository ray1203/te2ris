using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_foot : MonoBehaviour
{
    public player obj;

    private void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "ground")
        {
            obj.canjump = 1;
            //FindObjectOfType<player>().canjump = 1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            obj.canjump = 0;
            //FindObjectOfType<player>().canjump = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "thorn")
        {
            GameManager.instance.GameOver();
        }
    }
}
