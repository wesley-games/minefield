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

    public delegate void TileRightClicked(int i, int j);
    public static event TileRightClicked OnTileRightClicked;

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
        tileOpened.GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.4f, 0.6f);
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
