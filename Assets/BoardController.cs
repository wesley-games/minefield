using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject tilePrefab;
    public float minX = -4.5f;
    public float maxX = 4.5f;
    public float minY = -4.5f;
    public float maxY = 4.5f;
    
    void Start()
    {
        for (float x = minX, i = 0; x <= maxX; x += 1f, i++) 
        {
            for (float y = maxY, j = 0; y >= minY; y -= 1f, j++) 
            {
                GameObject tile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                TileController tileController = tile.GetComponent<TileController>();
                tileController.I = i;
                tileController.J = j;
            }
        }
    }
}
