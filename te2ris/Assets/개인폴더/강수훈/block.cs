using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField]
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate();
        move();
        limit_move();
    }
    private void rotate()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))                 //왼쪽 쉬프트 누르면
        {
            transform.Rotate(0, 0, +90);                    //90도 회전 시키기
        }
    }

    private void move()                     
    {
        Vector2 pos = transform.position;               //위치 옮겨적을 새로운 변수 생성
        if(Input.GetKey(KeyCode.A))                         //a누르면 
        {
            pos.x -= Time.deltaTime * speed;                   // 변수에서 x 값을 뺌
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
        }
        transform.position = pos;                       //새로운 변수의 변경된 값을 현재 위치에 대입
    }
    private void limit_move()
    {
        Vector3 limit_pos = Camera.main.WorldToViewportPoint(transform.position);           //화면 비율변수 생성
        if (limit_pos.x < 0.05f)                //밖으로 나가면 안쪽으로 텔레포트 시킴
        {
            limit_pos.x = 0.05f;
        }
        if (limit_pos.x > 0.95f)
        {
            limit_pos.x = 0.95f;
        }
        transform.position = Camera.main.ViewportToWorldPoint(limit_pos);           //화면 비율변수를 게임 화면에 대입
    }
}
