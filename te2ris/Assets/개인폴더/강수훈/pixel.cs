using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixel : MonoBehaviour
{
    [SerializeField]
    public int flag = 1;                    //���� ��Ҵ��� Ȯ���ϴ� ����!


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)          //��ü �浹 Ȯ�� �Լ�
    {
        if (collision.gameObject.tag == "ground")            //�±װ� �׶���,����� ��ü�� �浹�Ұ��
        {
            flag = 0;            //������ ����
        }
        if (collision.gameObject.tag == "block")
        {
            flag= 0;
        }
    }
}
