using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;
    public float power;
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
    }
    private void jump()
    {

    }
}
