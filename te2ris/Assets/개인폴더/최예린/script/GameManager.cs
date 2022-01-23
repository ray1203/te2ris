using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // public Stage stage;
    public GameObject CoverImage;
    

    // Start is called before the first frame update
    void Start()
    {
        // pool pol = GameObject.Find("Stage").GetComponent<pool>();
        
    }

    // Update is called once per frame
    public void OnClickStartButton()
    {
        CoverImage.SetActive(false);
        // stage.CreateBackground();
        // stage.CreateTetromino();
        //pol.creatBlock(pol.pos);

    }
}
