using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public Vector2 boardScale = new Vector2(20, 11);
    public float spacingScale = 1;
    public Vector3 topLeft = new Vector3(0, 0, 0);
    int[,] boardLayout;
    public GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        setTileLocations();

        if (!tile) {
            Debug.LogError("BoardManager Error: No Tiles Defined!");
            return;
        }

        boardLayout = setTileLocations();

        for (int i = 0; i < boardScale.y; i++)
        {
            for (int j = 0; j < boardScale.x; j++)
            {
                if (boardLayout[i, j] == 1)
                {
                    Instantiate(tile, new Vector3(i * spacingScale, 0,  j * spacingScale), Quaternion.identity, this.transform);
                }
            }
        }

    }

    private int[,] setTileLocations()
    {
        /****************************
            0 is empty
            1 is normal tile
            2 is teleport tile
            3 is key tile
        ****************************/

        int[,] tileLocations = { 
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
            { 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 1, 1, 1 },
            { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 2, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 2 },
            { 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
            { 1, 0, 1, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 1, 1, 1 },
            { 1, 0, 1, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        };

        return tileLocations;
    }
}
