using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Player"))
            GameManager.instance.GameOver();
        else if (collision.transform.CompareTag("ground"))
        {
            Destroy(collision.gameObject);
        }
    }
}
