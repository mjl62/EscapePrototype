using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class BoardTile : MonoBehaviour
{
    public GameObject tileNorth;
    public GameObject tileEast;
    public GameObject tileSouth;
    public GameObject tileWest;

    int connectedTiles = 0;

    bool junction = false;

    private void Start()
    {
        if (tileNorth != null) { connectedTiles += 1; }
        if (tileEast != null) { connectedTiles += 1; }
        if (tileWest != null) { connectedTiles += 1; }
        if (tileSouth != null) { connectedTiles += 1; }

        if (connectedTiles > 2)
        {
            junction = true;
        }
    }

    public GameObject nextTile()
    {
        return tileNorth;
    }

    public bool isJunction() {
        return junction;
    }
}
