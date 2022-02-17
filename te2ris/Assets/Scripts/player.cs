using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    public GameObject clear;
    public float speed;                     //�÷��̾� ������ ��Ÿ���� ����
    public float power;                     //�����Ŀ� ��Ÿ���� ����
    public int canjump = 1;                //���� ���ɿ��θ� ��Ÿ���� ����
    public AudioClip clip;
    Rigidbody2D myrigid;                    //������ٵ� �������� ����
    private bool iceMap = false;
    //animation
    SpriteRenderer spriteRenderer;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        myrigid = GetComponent<Rigidbody2D>();              //������ٵ� ������
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        if (SceneManager.GetActiveScene().name.Contains("stage3")) iceMap = true;
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
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))            //Ű ������ �������� ������Ŵ
            {
                pos.x -= Time.deltaTime * speed;
                spriteRenderer.flipX = false;
                animator.SetBool("walk", true);
                if (iceMap)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(-0.5f, 0);
                }
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                pos.x += Time.deltaTime * speed;
                spriteRenderer.flipX = true;
                animator.SetBool("walk", true);
                if (iceMap)
                {
                    GetComponent<Rigidbody2D>().velocity = new Vector2(0.5f, 0);
                }
            }
        }
        else
        {
            animator.SetBool("walk", false);
        }
        transform.position = pos;              //���ο� ������ ���� ��ġ�� ���Խ�Ŵ
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
        if(Input.GetKeyDown(KeyCode.Space) && canjump==1)              //Ű�� ������ ���� ������ ������ ���
        {
            myrigid.velocity = Vector2.up*power;                    //������� ���� ����
            canjump = 0;                                           //�����Ұ�� ���� �Ұ� ���°� ��
            
            SoundManager.instance.SFXPlay("jump", clip);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "goalLine")
        {
            Debug.Log("골라인");
            clear.SetActive(true);
            GameObject.Find("StageData").GetComponent<StageSave>().SaveData();
            Time.timeScale = 0f;
        }

    }
}
