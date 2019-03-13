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
    public static event TileClicked OnTileClicked = delegate { };

    public delegate void TileRightClicked(int i, int j);
    public static event TileRightClicked OnTileRightClicked = delegate { };

    private bool isFlagged = false;
    private Sprite spriteClosed;

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

    public void ToggleFlag(Sprite tileFlag)
    {
        if (!isFlagged)
        {
            this.spriteClosed = tileClosed.GetComponent<SpriteRenderer>().sprite;
            tileClosed.GetComponent<SpriteRenderer>().sprite = tileFlag;
        }
        else
        {
            tileClosed.GetComponent<SpriteRenderer>().sprite = this.spriteClosed;
        }
        isFlagged = !isFlagged;
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !isOpened)
        {
            OnTileClicked(i, j);
        }
        if (Input.GetMouseButtonDown(1))
        {
            OnTileRightClicked(i, j);
        }
    }
}
