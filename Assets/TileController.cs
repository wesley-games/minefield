using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public int i { get; private set; }
    public int j { get; private set; }
    // TODO verificar necessidade dessa variável, aparentemente não tem
    public bool hasBomb = false;

    public void SetPosition(int i, int j)
    {
        this.i = i;
        this.j = j;
    }

    public void SetBomb()
    {
        this.hasBomb = true;
    }

    void OnMouseDown()
    {
        Debug.Log("clicado: " + i + ", " + j);
    }
}
