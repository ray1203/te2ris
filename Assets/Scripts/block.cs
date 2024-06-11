using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class block : MonoBehaviour
{   
    Rigidbody2D myrigid;
    public GameObject failpage;
    [SerializeField]
    
    public float speed;
    public AudioClip clip;

    private int can_move = 1;

    private void Start()
    {
        myrigid = GetComponent<Rigidbody2D>();
    }
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
            if (can_move == 0)
            {
                cannot_move();
            }
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
    private void cannot_move()
    {
        Vector2 pos = transform.position;
        if (Input.GetKey(KeyCode.A))                         //a������ 
        {
            pos.x += Time.deltaTime * speed;                   // �������� x ���� ��

        }
        else if (Input.GetKey(KeyCode.D))
        {
            pos.x -= Time.deltaTime * speed;
        }
        transform.position = pos;
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
        gameObject.layer = 2;
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "overLine" && this.gameObject.tag=="ground")
        {
            Debug.Log("오버라인");
            failPageOn();
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="left spring")
        {
            myrigid.velocity = Vector2.left * 10;
            can_move = 0;
        }
        if (collision.gameObject.tag == "right spring")
        {
            myrigid.velocity = Vector2.right * 10;
            can_move = 0;
        }
        if (collision.gameObject.tag == "spring")
        {
            myrigid.velocity = Vector2.up * 5;
        }
    }
    
    public void failPageOn()
    {
        
        GameObject.Find("CanvasForFail").transform.Find("FAIL").gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
