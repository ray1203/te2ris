using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagmove : MonoBehaviour
{
    Vector3 pos;
    public float delta = 4.0f; 
    public float speed = 0.9f;

    void Start()
    {
        pos = transform.position;
    }

    void Update()
    {
        Vector3 v = pos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
}
