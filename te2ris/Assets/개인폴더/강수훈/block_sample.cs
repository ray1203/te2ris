using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block_sample : MonoBehaviour
{
    [SerializeField]
    public int left_flag = 0;            //���� �΋H������ �ƴ� ����
    [SerializeField]
    public int right_flag = 0;            //���� �΋H������ �ƴ� ����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        limit_move();
    }

    private void limit_move()
    {
        Vector3 limit_pos = Camera.main.WorldToViewportPoint(transform.position);
        if (limit_pos.x <= 0.05f)    //����
        {
            limit_pos.x = 0.05f;
            left_flag = 1;
        }
        else if (limit_pos.x >= 0.95f)           //������
        {
            limit_pos.x = 0.95f;
            right_flag = 1;
        }
        else            //���� 
        {
            left_flag = 0;
            right_flag = 0;
        }
        transform.position = Camera.main.ViewportToWorldPoint(limit_pos);
    }
}
