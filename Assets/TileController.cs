using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public GameObject tileClosed;
    public GameObject tileOpened;

    public int i { get; private set; }
    public int j { get; private set; }

    public bool isOpened = false;

    public delegate void TileClicked(int i, int j);
    public static event TileClicked OnTileClicked;

    public void SetPosition(int i, int j)
    {
        this.i = i;
        this.j = j;
    }

    public void SetNewTile(Sprite newTile)
    {
        isOpened = true;
        tileClosed.SetActive(false);
        tileOpened.GetComponent<SpriteRenderer>().sprite = newTile;
    }

    void OnMouseDown()
    {
        if (!isOpened)
        {
            OnTileClicked(i, j);
        }
    }
}
