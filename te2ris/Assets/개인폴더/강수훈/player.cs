using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float power;
    private int canjump = 1;
    Rigidbody2D myrigid;

    // Start is called before the first frame update
    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        limit_move();
    }
    private void move()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= Time.deltaTime * speed;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += Time.deltaTime * speed;

        }
        transform.position = pos;
    }
    private void limit_move()
    {
        Vector3 limit_pos = Camera.main.WorldToViewportPoint(transform.position);
        if( limit_pos.x <0.05f)
        {
            limit_pos.x = 0.05f;
        }
        if (limit_pos.x > 0.95f)
        {
            limit_pos.x = 0.95f;
        }
        transform.position = Camera.main.ViewportToWorldPoint(limit_pos);
    }
    private void jump()
    {
        if(Input.GetKeyDown(KeyCode.RightShift) && canjump==1)
        {
            myrigid.velocity = Vector2.up*power;
            canjump = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            canjump = 1;
        }
        if (collision.gameObject.tag == "block")
        {
            canjump = 1;
        }
    }
}
