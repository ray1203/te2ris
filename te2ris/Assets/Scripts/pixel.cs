using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pixel : MonoBehaviour
{
    [SerializeField]
    public int flag = 1;  

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
    
    // 타일블럭으로 접근(한칸 한칸씩)
    private void OnCollisionEnter2D(Collision2D other) { 
        if(other.gameObject.tag == "ground")
        {
            var parent =transform.parent.gameObject;
            parent.tag = "ground";
            flag = 0;
        }
    }
}
