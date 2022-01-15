using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed;                     //�÷��̾� ������ ��Ÿ���� ����
    public float power;                     //�����Ŀ� ��Ÿ���� ����
    private int canjump = 1;                //���� ���ɿ��θ� ��Ÿ���� ����
    Rigidbody2D myrigid;                    //������ٵ� ������� ����

    // Start is called before the first frame update
    void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();              //������ٵ� �����

    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
        limit_move();
    }

    private void move()                     //�÷��̾� ������ �Լ�
    {
        Vector3 pos = transform.position;       //��ġ���� ���� ���ο� ���� ����
        if (Input.GetKey(KeyCode.LeftArrow))            //Ű ������ �������� ������Ŵ
        {
            pos.x -= Time.deltaTime * speed;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += Time.deltaTime * speed;

        }
        transform.position = pos;               //���ο� ������ ���� ��ġ�� ���Խ�Ŵ
    }

    private void limit_move()                       //ȭ������� �������� �ϴ� �Լ�
    {       //��ġ�� ȭ�����(0,0)~(1,1)�� ��Ÿ��
        Vector3 limit_pos = Camera.main.WorldToViewportPoint(transform.position);       
        if( limit_pos.x <0.05f)                     //������ ������ �ڷ���Ʈ ��Ŵ
        {
            limit_pos.x = 0.05f;
        }
        if (limit_pos.x > 0.95f)
        {
            limit_pos.x = 0.95f;
        }
        //ȭ�� ������ ���� ��ġ�� �ٽ� �ٲ�
        transform.position = Camera.main.ViewportToWorldPoint(limit_pos);           
    }

    private void jump()         //�����Լ�
    {
        if(Input.GetKeyDown(KeyCode.RightShift) && canjump==1)              //Ű�� ������ ���� ������ ������ ���
        {
            myrigid.velocity = Vector2.up*power;                    //������� ���� ����
            canjump = 0;                                            //�����Ұ�� ���� �Ұ� ���°� ��
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)          //��ü �浹 Ȯ�� �Լ�
    {
        if(collision.gameObject.tag == "ground")            //�±װ� �׶���,����� ��ü�� �浹�Ұ��
        {
            canjump = 1;            //���� ����
        }
        if (collision.gameObject.tag == "block")
        {
            canjump = 1;
        }
    }
}
