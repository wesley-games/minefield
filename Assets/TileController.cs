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

    public delegate void TileFlagChanged(int increment);
    public static event TileFlagChanged OnTileFlagChanged = delegate { };

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
        if (isFlagged)
        {
            OnTileFlagChanged(-1);
        }
    }

    public void ToggleFlag(Sprite tileFlag)
    {
        if (!isOpened)
        {
            if (!isFlagged)
            {
                this.spriteClosed = tileClosed.GetComponent<SpriteRenderer>().sprite;
                tileClosed.GetComponent<SpriteRenderer>().sprite = tileFlag;
                OnTileFlagChanged(1);
            }
            else
            {
                tileClosed.GetComponent<SpriteRenderer>().sprite = this.spriteClosed;
                OnTileFlagChanged(-1);
            }
            isFlagged = !isFlagged;
        }
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
