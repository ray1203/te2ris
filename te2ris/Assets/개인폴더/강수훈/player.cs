using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;                     //플레이어 움직임 나타내는 변수
    public float power;                     //점프파워 나타내는 변수
    private int canjump = 1;                //점프 가능여부를 나타내는 변수
    Rigidbody2D myrigid;                    //리지드바디 갖고오는 변수

    // Start is called before the first frame update
    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();              //리지드바디 갖고옴

    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        limit_move();
    }

    private void move()                     //플레이어 움직임 함수
    {
        Vector3 pos = transform.position;       //위치값을 담을 새로운 변수 생성
        if (Input.GetKey(KeyCode.LeftArrow))            //키 누르면 변수값을 가감시킴
        {
            pos.x -= Time.deltaTime * speed;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += Time.deltaTime * speed;

        }
        transform.position = pos;               //새로운 변수를 현재 위치에 대입시킴
    }

    private void limit_move()                       //화면밖으로 못나가게 하는 함수
    {       //위치를 화면비율(0,0)~(1,1)로 나타냄
        Vector3 limit_pos = Camera.main.WorldToViewportPoint(transform.position);       
        if( limit_pos.x <0.05f)                     //밖으로 나가면 텔레포트 시킴
        {
            limit_pos.x = 0.05f;
        }
        if (limit_pos.x > 0.95f)
        {
            limit_pos.x = 0.95f;
        }
        //화면 비율을 현재 위치로 다시 바꿈
        transform.position = Camera.main.ViewportToWorldPoint(limit_pos);           
    }

    private void jump()         //점프함수
    {
        if(Input.GetKeyDown(KeyCode.RightShift) && canjump==1)              //키를 누르고 점프 가능한 상태일 경우
        {
            myrigid.velocity = Vector2.up*power;                    //상단으로 힘을 받음
            canjump = 0;                                            //점프할경우 점프 불가 상태가 됨
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)          //물체 충돌 확인 함수
    {
        if(collision.gameObject.tag == "ground")            //태그가 그라운드,블록인 물체와 충돌할경우
        {
            canjump = 1;            //점프 가능
        }
        if (collision.gameObject.tag == "block")
        {
            canjump = 1;
        }
    }
}
