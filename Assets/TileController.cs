using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour
{
    public float I { get; set; }
    public float J { get; set; }

    void OnMouseDown()
    {
        Debug.Log("clicado: " + I + ", " + J);
    }
}
