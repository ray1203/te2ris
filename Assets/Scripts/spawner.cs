using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawner : MonoBehaviour
{
    [SerializeField]
    public GameObject[] tetrominos;
    public Transform preview;
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
        if (SceneManager.GetActiveScene().name != "Start")
        {
            destroyer = GameObject.Find("destroyer").GetComponent<Destroyer>();
        }
        checkStart = true;
        //Debug.Log(preview.position);
    }

    public void new_teromino()
    {
        if(checkStart && SceneManager.GetActiveScene().name != "Start")
            destroyer.destroyCheck();
        Instantiate(tetrominos[cur_block], transform.position, Quaternion.identity);

        // preview
        prefab = Instantiate(tetrominos[pre_block], preview.position, Quaternion.identity);
        cur_block = pre_block;
        pre_block = Random.Range(0, tetrominos.Length);
        prefab.GetComponent<Rigidbody2D>().simulated = false;
        prefab.transform.GetChild(0).GetComponent<pixel>().flag = 0;
        prefab.transform.GetChild(1).GetComponent<pixel>().flag = 0;
        prefab.transform.GetChild(2).GetComponent<pixel>().flag = 0;
        prefab.transform.GetChild(3).GetComponent<pixel>().flag = 0;
    }

    public void destroy_preview()
    {
        Destroy(prefab);
    }
}
