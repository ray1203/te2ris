using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] tetrominos;
    private Destroyer destroyer;
    private bool checkStart = false;
    // Start is called before the first frame update
    void Start()
    {
        new_teromino();
        destroyer = GameObject.Find("destroyer").GetComponent<Destroyer>();
        checkStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void new_teromino()
    {
        if(checkStart)
            destroyer.destroyCheck();
        Instantiate(tetrominos[Random.Range(0, tetrominos.Length)], transform.position, Quaternion.identity);
    }
}
