using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController : MonoBehaviour
{
    public GameObject tilePrefab;
    public int fieldSize = 10;
    public int amountBombs = 10;

    private float maxY = 4.5f;
    private float incrementY = -1f;
    private float minX = -4.5f;
    private float incrementX = 1f;
    // private float maxX = 4.5f;
    // private float minY = -4.5f;

    private int[,] mineField;
    private GameObject[,] screenField;

    void OnEnable()
    {
        TileController.OnTileClicked += OnTileClicked;
    }

    void OnDisable()
    {
        TileController.OnTileClicked -= OnTileClicked;
    }

    void Start()
    {
        InitializeScreenField();
        InitializeMineField();
        SetBombs();
    }

    void InitializeScreenField()
    {
        screenField = new GameObject[fieldSize, fieldSize];

        float y = maxY;
        for (int j = 0; j < fieldSize; j++, y += incrementY)
        {
            float x = minX;
            for (int i = 0; i < fieldSize; i++, x += incrementX)
            {
                GameObject tile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                TileController tileController = tile.GetComponent<TileController>();
                tileController.SetPosition(i, j);
                screenField[i, j] = tile;
            }
        }
    }

    void InitializeMineField()
    {
        mineField = new int[fieldSize, fieldSize];

        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                mineField[i, j] = 0;
            }
        }
    }

    void SetBombs()
    {
        for (int bombs = 0; bombs < amountBombs; bombs++)
        {
            int i = Random.Range(0, fieldSize);
            int j = Random.Range(0, fieldSize);
            if (mineField[i, j] != 1)
            {
                mineField[i, j] = 1;
                // método usado pra teste, provavelmente as bombas só existirão em mineField
                screenField[i, j].GetComponent<TileController>().SetBomb();
            }
        }
    }

    void OnTileClicked(int i, int j)
    {
        Debug.Log(i + " - " + j);
    }
}
