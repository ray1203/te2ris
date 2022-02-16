using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCounter : MonoBehaviour
{
    private static Dictionary<int, bool> removeCheck;
    private List<GameObject> blocks;
    public int showCount;

    private void Awake()
    {
        blocks = new List<GameObject>();
        removeCheck = new Dictionary<int, bool>();
    }
    private void Update()
    {
        showCount = getCount();
        //Debug.Log(getCount());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ground")|| collision.CompareTag("block")) blocks.Add(collision.gameObject);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ground") || collision.CompareTag("block")) blocks.Remove(collision.gameObject);
    }
    public int getCount()
    {
        return blocks.Count;
    }
    public void clearArr()
    {
        for(int i = 0; i < blocks.Count; i++)
        {
            if(blocks[i]==null) blocks.Remove(blocks[i]);
            if (removeCheck.ContainsKey(blocks[i].GetComponent<pixel>().id)) blocks.Remove(blocks[i]);
        }
    }
    /*
    public void destroyBlocks()
    {
        for(int i = 0; i < blocks.Count; i++)
        {
            Destroy(blocks[0]);
        }
    }*/
    public IEnumerator destroyBlocks()
    {
        Time.timeScale = 0.0f;
        List<SpriteRenderer> destroyList = new List<SpriteRenderer>();
        Color color;
        for(int i = 0; i < blocks.Count; i++)
        {
            destroyList.Add(blocks[i].transform.GetComponent<SpriteRenderer>());
            color = destroyList[i].color;
            destroyList[i].color = new Color( color.r, color.g, color.b, 0 );
        }
        yield return new WaitForSecondsRealtime(0.2f);
        for(int i = 0; i < destroyList.Count; i++)
        {
            color = destroyList[i].color;
            destroyList[i].color = new Color(color.r, color.g, color.b, 255);
        }
        yield return new WaitForSecondsRealtime(0.2f);
        for (int i = 0; i < destroyList.Count; i++)
        {
            color = destroyList[i].color;
            destroyList[i].color = new Color(color.r, color.g, color.b, 0);
        }
        yield return new WaitForSecondsRealtime(0.2f);
        for (int i = 0; i < destroyList.Count; i++)
        {
            color = destroyList[i].color;
            destroyList[i].color = new Color(color.r, color.g, color.b, 255);
        }
        yield return new WaitForSecondsRealtime(0.2f);

        int count = destroyList.Count;
        for (int i = 0; i < count; i++)
        {
            removeCheck.Add(destroyList[i].GetComponent<pixel>().id, true);
            Destroy(destroyList[i].gameObject);
            
        }
        destroyList.Clear();
        blocks.Clear();
        Time.timeScale = 1.0f;
    }
    
}
