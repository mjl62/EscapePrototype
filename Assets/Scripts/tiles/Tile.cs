using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class Tile : MonoBehaviour
{
    [SerializeField] Vector3 piecePlacementOffset = new Vector3(0, 0.5f, 0);


    public void placePiece(GameObject piece)
    {
        // TODO check pieces on same position
        piece.transform.position = transform.position + piecePlacementOffset;
    }

}
