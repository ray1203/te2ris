using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_head : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "block")
        {
            Debug.Log("�÷��̾� ���");
            GameManager.instance.GameOver();

        }
    }
}
