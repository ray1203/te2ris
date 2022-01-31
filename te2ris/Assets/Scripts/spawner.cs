using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] tetrominos;
    public GameObject preview;
    private Destroyer destroyer;
    private bool checkStart = false;
    public int cur_block;
    public int pre_block;
    private GameObject prefab;
    
    void Start()
    {
        cur_block = Random.Range(0, tetrominos.Length);
        pre_block = Random.Range(0, tetrominos.Length);

        new_teromino();
        destroyer = GameObject.Find("destroyer").GetComponent<Destroyer>();
        checkStart = true;
    }

    public void new_teromino()
    {
        if(checkStart)
            destroyer.destroyCheck();
        Instantiate(tetrominos[cur_block], transform.position, Quaternion.identity);

        // preview
        prefab = Instantiate(tetrominos[pre_block], preview.transform.position, Quaternion.identity);
        cur_block = pre_block;
        pre_block = Random.Range(0, tetrominos.Length);
        prefab.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    public void destroy_preview()
    {
        Destroy(prefab);
    }
}
