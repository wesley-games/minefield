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

    private SpritesController sprites;
    private int[,] mineField;
    private GameObject[,] screenField;

    void Awake()
    {
        sprites = GetComponent<SpritesController>();

    }

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

        // TEST
        // OpenAllBombs();
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
                tile.GetComponent<TileController>().SetPosition(j, i);
                screenField[j, i] = tile;
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
            }
        }
    }

    void OnTileClicked(int i, int j)
    {
        switch (mineField[i, j])
        {
            case 0:
                CountBombsAround(i, j);
                break;
            case 1:
                OpenAllBombs();
                break;
        }
    }

    void OpenAllBombs()
    {
        for (int i = 0; i < fieldSize; i++)
        {
            for (int j = 0; j < fieldSize; j++)
            {
                if (mineField[i, j] == 1)
                {
                    screenField[i, j].GetComponent<TileController>().SetNewTile(sprites.getBombTile());
                }
            }
        }
    }

    void CountBombsAround(int i, int j)
    {
        int bombsCount = 0;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                int ix = i + x;
                int jy = j + y;
                if ((ix >= 0 && jy >= 0 && ix < fieldSize && jy < fieldSize) && mineField[ix, jy] == 1)
                {
                    bombsCount++;
                }
            }
        }
        screenField[i, j].GetComponent<TileController>().SetNewTile(sprites.getNumberTile(bombsCount));
        if (bombsCount == 0)
        {
            OpenTiles(i, j);
        }
    }

    void OpenTiles(int i, int j)
    {
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                int ix = i + x;
                int jy = j + y;
                if ((ix >= 0 && jy >= 0 && ix < fieldSize && jy < fieldSize) && !screenField[ix, jy].GetComponent<TileController>().isOpened)
                {
                    CountBombsAround(ix, jy);
                }
            }
        }
    }
}
