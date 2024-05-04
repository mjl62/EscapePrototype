using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Rendering;

public class Tile : MonoBehaviour
{
    [SerializeField] Vector3 piecePlacementOffset = new Vector3(0, 0.5f, 0);

    [SerializeField] bool isKeySpace = false;
    [SerializeField] GameManager gameManager;

    public void placePiece(GameObject piece)
    {
        piece.transform.position = transform.position + piecePlacementOffset;
        if (isKeySpace && piece.GetType() != typeof(Robot)) {
            gameManager.keyGet();
            isKeySpace = false;
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", new Color(0f, 0f, 50f, .25f));
            gameManager.checkPlayerStatus();
        }
    }

}
