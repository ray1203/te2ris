using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixel : MonoBehaviour
{
    [SerializeField]
    public int flag = 1;                    //땅에 닿았는지 확인하는 변수!


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)          //물체 충돌 확인 함수
    {
        if (collision.gameObject.tag == "ground")            //태그가 그라운드,블록인 물체와 충돌할경우
        {
            flag = 0;            //움직임 가능
        }
        if (collision.gameObject.tag == "block")
        {
            flag= 0;
        }
    }
}
