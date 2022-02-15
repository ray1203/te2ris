using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public AudioClip clip;
  
    void Update()
    {
        if (transform.childCount == 0)
        {
            Destroy(gameObject);
        }
        if(transform.childCount!=0&&GetComponentInChildren<pixel>().flag ==1)
        {
            move();
            rotate();
        }
        limit_move();
    }

    private void rotate()
    {
        if(Input.GetKeyDown(KeyCode.S))               //���� ����Ʈ ������
        {
            transform.Rotate(0, 0, +90);                    //90�� ȸ�� ��Ű��
        }
    }

    private void move()                     
    {
        Vector2 pos = transform.position;               //��ġ �Ű����� ���ο� ���� ����
        if(Input.GetKey(KeyCode.A))                         //a������ 
        {
            pos.x -= Time.deltaTime * speed;                   // �������� x ���� ��
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x += Time.deltaTime * speed;
        }
        transform.position = pos;                       //���ο� ������ ����� ���� ���� ��ġ�� ����
    }


    private void limit_move()
    {
        Vector3 limit_pos = Camera.main.WorldToViewportPoint(transform.position);           //ȭ�� �������� ����
        if (limit_pos.x < 0.05f)                //������ ������ �������� �ڷ���Ʈ ��Ŵ
        {
            limit_pos.x = 0.05f;
        }
        if (limit_pos.x > 0.95f)
        {
            limit_pos.x = 0.95f;
        }
        transform.position = Camera.main.ViewportToWorldPoint(limit_pos);           //ȭ�� ���������� ���� ȭ�鿡 ����
    }
    
    public void set_ground()
    {
        SoundManager.instance.SFXPlay("dump", clip);
        FindObjectOfType<spawner>().destroy_preview();
        gameObject.tag = "ground";
        transform.GetChild(0).tag = "ground";
        transform.GetChild(0).GetComponent<pixel>().flag = 0;
        transform.GetChild(1).tag = "ground";
        transform.GetChild(1).GetComponent<pixel>().flag = 0;
        transform.GetChild(2).tag = "ground";
        transform.GetChild(2).GetComponent<pixel>().flag = 0;
        transform.GetChild(3).tag = "ground";
        transform.GetChild(3).GetComponent<pixel>().flag = 0;
        FindObjectOfType<spawner>().new_teromino();
    }
}
