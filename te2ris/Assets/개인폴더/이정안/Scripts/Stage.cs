using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    [Header("Editor objects")]
    public GameObject tilePrefab;
    public Transform backgroundNode;
    public Transform boardNode;
    public Transform tetrominoNode;

    [Header("Game Settings")]
    [Range(4,40)]
    public int boardWidth = 10;
    [Range(5,20)]
    public int boardHeight = 20;
    public float fallCycle = 1.0f;

    private int halfWidth;
    private int halfHeight;
    private float nextFallTime;

    private void Start() {
        halfWidth = Mathf.RoundToInt(boardWidth * 0.5f);
        halfHeight = Mathf.RoundToInt(boardHeight * 0.5f);

        nextFallTime = Time.time + fallCycle;

        CreateBackground();

        CreateTetromino();
    }

    private void Update() {
        Vector3 moveDir = Vector3.zero;
        bool isRotate = false;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDir.x = -1;
        
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDir.x = 1;
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            isRotate = true;
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            moveDir.y = -1;
        }
        if(Time.time > nextFallTime)
        {
            nextFallTime = Time.time + fallCycle;
            moveDir = Vector3.down;
            isRotate = false;
        }
        if(moveDir != Vector3.zero || isRotate)
        {
            MoveTetromino(moveDir, isRotate);
        }
    }
    
    bool MoveTetromino(Vector3 moveDir, bool isRotate)
    {
        Vector3 oldPos = tetrominoNode.transform.position;
        Quaternion oldRot = tetrominoNode.transform.rotation;

        tetrominoNode.transform.position += moveDir;
        if (isRotate)
        {
            tetrominoNode.transform.rotation *= Quaternion.Euler(0, 0, 90);
        }

        if (!CanMoveTo(tetrominoNode))
        {
            tetrominoNode.transform.position = oldPos;
            tetrominoNode.transform.rotation = oldRot;

            return false;
        }

        return true;
    }

    bool CanMoveTo(Transform root)
    {
        for (int i = 0; i < root.childCount; ++i)
        {
            var node = root.GetChild(i);
            int x = Mathf.RoundToInt(node.transform.position.x + halfWidth);
            int y = Mathf.RoundToInt(node.transform.position.y + halfHeight - 1);

            if (x < 0 || x > boardWidth - 1)
                return false;

            if (y < 0)
                return false;
        }

        return true;
    }

    // 타일생성 부분
    Tile CreateTile(Transform parent, Vector2 position, Color color, int order = 1)
    {
        var go = Instantiate(tilePrefab);
        go.transform.parent = parent;
        go.transform.localPosition = position;

        var tile = go.GetComponent<Tile>();
        tile.color = color;
        tile.sortingOrder = order;

        return tile;
    }

    public void CreateBackground()
    {
        Color color = Color.gray;
        
        // 타일 보드
        color.a = 0.5f;
        for(int x = -halfWidth; x < halfWidth; x++)
        {
            for(int y = halfHeight; y > -halfHeight; y--)
            {
                CreateTile(backgroundNode, new Vector2(x,y), color, 0);
            }
        }

        // 좌우 
        color.a = 1.0f;
        for(int y = halfHeight; y > -halfHeight; y--)
        {
            CreateTile(backgroundNode, new Vector2(-halfWidth - 1, y), color, 0);
            CreateTile(backgroundNode, new Vector2(halfWidth, y), color, 0);
        }
        // 아래 
        for(int x = -halfWidth - 1; x <= halfWidth; x++)
        {
            CreateTile(backgroundNode, new Vector2(x, -halfHeight), color, 0);
        }
    }

    public void CreateTetromino()
    {
        int index = Random.Range(0,7);
        Color32 color = Color.white;

        tetrominoNode.rotation = Quaternion.identity;
        tetrominoNode.position = new Vector2(0, halfHeight);

        switch (index)
        {
            case 0:
                color = new Color32(115,251,253,255);
                CreateTile(tetrominoNode, new Vector2(-2f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(-1f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 0.0f), color);
                break;
            case 1:
                color = new Color32(0,33,245,255);
                CreateTile(tetrominoNode, new Vector2(-1f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(-1f, 1.0f), color);
                break;
            case 2:
                color = new Color32(243, 168, 59, 255);
                CreateTile(tetrominoNode, new Vector2(-1f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 0.0f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 1.0f), color);
                break;
            case 3:
                color = new Color32(255, 253, 84, 255);
                CreateTile(tetrominoNode, new Vector2(0f, 0f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 0f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 1f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 1f), color);
                break;
            case 4:
                color = new Color32(117, 250, 76, 255);
                CreateTile(tetrominoNode, new Vector2(-1f, -1f), color);
                CreateTile(tetrominoNode, new Vector2(0f, -1f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 0f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 0f), color);
                break;
            case 5:
                color = new Color32(155, 47, 246, 255);
                CreateTile(tetrominoNode, new Vector2(-1f, 0f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 0f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 0f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 1f), color);
                break;
            case 6:
                color = new Color32(235, 51, 35, 255);
                CreateTile(tetrominoNode, new Vector2(-1f, 1f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 1f), color);
                CreateTile(tetrominoNode, new Vector2(0f, 0f), color);
                CreateTile(tetrominoNode, new Vector2(1f, 0f), color);
                break;
        }
    }
}
