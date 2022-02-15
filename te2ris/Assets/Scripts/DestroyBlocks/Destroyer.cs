using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private List<BlockCounter> blockCounters;
    public GameObject col;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 20; i++)
        {
            GameObject newCol = Instantiate(col, transform);
            newCol.tag = "destroyChecker";
            newCol.transform.position = new Vector2 (-0.35f, -4.0f + 0.5f*i);
        }
        blockCounters = new List<BlockCounter>();
        for(int i = 0; i < this.transform.childCount; i++)
        {
            blockCounters.Add(this.transform.GetChild(i).GetComponent<BlockCounter>());
        }
        
    }
    public void destroyCheck()
    {
        for(int i = 0; i < blockCounters.Count; i++)
        {
            if (blockCounters[i].getCount() >= 20)
            {
                //blockCounters[i].destroyBlocks();
                SoundManager.instance.SFXPlay("clear", clip);
                blockCounters[i].StartCoroutine(blockCounters[i].destroyBlocks());
            }
        }
        for (int i = 0; i < blockCounters.Count; i++)
            blockCounters[i].clearArr();
    }
    // Update is called once per frame
    void Update()
    {
        
            //destroyCheck();
    }
}
