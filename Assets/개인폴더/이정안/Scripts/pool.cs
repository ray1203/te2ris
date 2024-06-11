using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
    [Header("Game Settings")]
    public GameObject[] Prefab;
    public Transform pos;
    [Range(4,40)]
    public int boardWidth = 10;
    [Range(5,20)]
    public int boardHeight = 20;

    private int halfWidth;
    private int halfHeight;

    public void creatBlock(Transform pos)
    {
        var go = Instantiate(Prefab[Random.Range(0,7)]);
        go.transform.parent = pos;
        go.transform.localPosition = pos.localPosition;
    }

    void Start(){
        halfWidth = Mathf.RoundToInt(boardWidth * 0.5f);
        halfHeight = Mathf.RoundToInt(boardHeight * 0.5f);
        
        creatBlock(pos);
    }



    void Update()
    {
        
    }
}
