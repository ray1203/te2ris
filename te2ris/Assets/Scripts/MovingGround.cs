using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 0f;
            collision.GetComponent<Rigidbody2D>().velocity = new Vector2(0f,-0.05f);
        }
        if(collision.GetComponentInParent<block>() != null)
        {

            collision.GetComponentInParent<Rigidbody2D>().velocity = Vector2.zero;
            collision.GetComponentInParent<Rigidbody2D>().gravityScale = 0f;
            collision.GetComponentInParent<Rigidbody2D>().angularDrag = 100f;
            collision.GetComponentInParent<Rigidbody2D>().drag = 100f;
            collision.GetComponentInParent<Rigidbody2D>().mass = 100f;
            //collision.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<block>() != null)
        {
            collision.transform.parent.position = collision.transform.parent.position - new Vector3(0f, 0.009f*Time.deltaTime);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Rigidbody2D>().gravityScale = 1f;
        }
        if (collision.GetComponentInParent<block>() != null)
        {
            collision.GetComponentInParent<Rigidbody2D>().gravityScale = 0.5f;
            collision.GetComponentInParent<Rigidbody2D>().angularDrag = 1f;
            collision.GetComponentInParent<Rigidbody2D>().drag = 1f;
            //collision.GetComponentInParent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        }

    }
}
