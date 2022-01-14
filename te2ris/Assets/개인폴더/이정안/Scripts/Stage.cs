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

    private void Start() {
        halfWidth = Mathf.RoundToInt(boardWidth * 0.5f);
        halfHeight = Mathf.RoundToInt(boardHeight * 0.5f);

        CreateBackground();
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

    void CreateBackground()
    {
        Color color = Color.gray;
        
        // 타일 보드
        color.a = 0.5f;
        for(int x = -halfWidth;x < halfWidth; x++)
        {
            for(int y = halfHeight; y > -halfHeight; y++)
            {
                CreateTile(backgroundNode, new Vector2(x,y), color, 0);
            }
        }

        // 좌우 
        color.a = 1.0f;
        for(int y = halfHeight; y > -halfHeight; y--)
        {
            CreateTile(backgroundNode, new Vector2(-halfHeight - 1, y), color, 0);
            CreateTile(backgroundNode, new Vector2(-halfWidth, y), color, 0);
        }
        // 아래 
        for(int x = -halfWidth; x <= halfWidth; x++)
        {
            CreateTile(backgroundNode, new Vector2(x, -halfHeight), color, 0);
        }

    }
}
