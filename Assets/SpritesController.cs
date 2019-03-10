using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesController : MonoBehaviour
{
    public Sprite tileClosed;
    public Sprite tileBomb;
    public Sprite tileFlag;
    public Sprite tile0;
    public Sprite tile1;
    public Sprite tile2;
    public Sprite tile3;
    public Sprite tile4;
    public Sprite tile5;
    public Sprite tile6;
    public Sprite tile7;
    public Sprite tile8;

    public Sprite getBombTile()
    {
        return tileBomb;
    }

    public Sprite getNumberTile(int number)
    {
        switch (number)
        {
            case 0:
                return tile0;
            case 1:
                return tile1;
            case 2:
                return tile2;
            case 3:
                return tile3;
            case 4:
                return tile4;
            case 5:
                return tile5;
            case 6:
                return tile6;
            case 7:
                return tile7;
            case 8:
                return tile8;
            default:
                return null;
        }
    }
}
