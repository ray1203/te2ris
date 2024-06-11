using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixel : MonoBehaviour
{
    [SerializeField]
    public int flag = 1;
    private static int curId = 0;
    public int id;
    public Color color
    {
        set
        {
            spriteRenderer.color = value;
        }

        get
        {
            return spriteRenderer.color;
        }
    }

    public int sortingOrder
    {
        set
        {
            spriteRenderer.sortingOrder = value;
        }

        get
        {
            return spriteRenderer.sortingOrder;
        }
    }

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("You need to SpriteRenderer for Block");
        }
    }
    private void Start()
    {
        id = curId++;
    }
    // 타일블럭으로 접근(한칸 한칸씩)
    private void OnCollisionEnter2D(Collision2D other) { 
        if(other.gameObject.tag == "ground" && flag == 1)
        {
            gameObject.GetComponentInParent<block>().set_ground();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ground" && flag == 1)
        {
            gameObject.GetComponentInParent<block>().set_ground();
        }
    }
}
