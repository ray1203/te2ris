using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private List<BlockCounter> blockCounters;
    // Start is called before the first frame update
    void Start()
    {
        blockCounters = new List<BlockCounter>();
        for(int i = 0; i < this.transform.childCount; i++)
        {
            blockCounters.Add(this.transform.GetChild(i).GetComponent<BlockCounter>());
        }
    }
    void destroyCheck()
    {
        for(int i = 0; i < blockCounters.Count; i++)
        {
            if (blockCounters[i].getCount() >= 20)
            {
                //blockCounters[i].destroyBlocks();
                blockCounters[i].StartCoroutine(blockCounters[i].destroyBlocks());
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
            destroyCheck();
    }
}
