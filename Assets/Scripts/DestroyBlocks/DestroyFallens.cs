using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFallens : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("ground")) Destroy(collision.gameObject);
        //if (collision.CompareTag("block")) Destroy(collision.gameObject);
    }
}
