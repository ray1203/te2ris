using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] tetrominos;
    // Start is called before the first frame update
    void Start()
    {
        new_teromino();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void new_teromino()
    {
        Instantiate(tetrominos[Random.Range(0, tetrominos.Length)], transform.position, Quaternion.identity);
    }
}
