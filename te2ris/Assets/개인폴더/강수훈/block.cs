using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
        move();
        limit_move();
    }
    private void rotate()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.Rotate(0, 0, +90);
        }
    }
    private void move()
    {
        Vector2 pos = transform.position;
        if(Input.GetKeyDown(KeyCode.A))
        {
            pos.x -= 0.5f;
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            pos.x += 0.5f;
            
        }
        
        transform.position = pos;
    }
    private void limit_move()
    {
        Vector3 limit_pos = Camera.main.WorldToViewportPoint(transform.position);
        if (limit_pos.x < 0.05f)
        {
            limit_pos.x = 0.05f;
        }
        if (limit_pos.x > 0.95f)
        {
            limit_pos.x = 0.95f;
        }
        transform.position = Camera.main.ViewportToWorldPoint(limit_pos);
    }
}
