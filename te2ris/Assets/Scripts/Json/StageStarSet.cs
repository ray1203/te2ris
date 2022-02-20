using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageStarSet : MonoBehaviour
{
    public Sprite star1, star2, star3, star4;
    public GameObject star, big_star;
    // Start is called before the first frame update
    void Start()
    {
        int[] starList = GameObject.Find("StageData").GetComponent<StageSave>().GetAllStars();
        for(int i = 1; i <= 9; i++)
        {
            if (starList[i] == 1)
            {
                GameObject newObject = Instantiate(star);
                newObject.GetComponent<Image>().sprite = star1;
                newObject.transform.SetParent (transform.Find("Stage" + i));
                newObject.transform.localScale = new Vector3(1, 1, 1);
                newObject.transform.localPosition = new Vector2(0, 24);
            }
            else if (starList[i] == 2)
            {
                GameObject newObject = Instantiate(star);
                newObject.GetComponent<Image>().sprite = star2;
                newObject.transform.SetParent(transform.Find("Stage" + i));
                newObject.transform.localScale = new Vector3(1, 1, 1);
                newObject.transform.localPosition = new Vector2(0, 24);
            }
            else if (starList[i] == 3)
            {
                GameObject newObject = Instantiate(star);
                newObject.GetComponent<Image>().sprite = star3;
                newObject.transform.SetParent (transform.Find("Stage" + i));
                newObject.transform.localScale = new Vector3(1, 1, 1);
                newObject.transform.localPosition = new Vector2(0, 24);
            }
            else if (starList[i] == 4)
            {
                GameObject newObject = Instantiate(big_star);
                newObject.GetComponent<Image>().sprite = star4;
                newObject.transform.SetParent(transform.Find("Stage" + i));
                newObject.transform.localScale = new Vector3(0.5f, 0.5f, 1);
                newObject.transform.localPosition = new Vector2(0, 25);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
