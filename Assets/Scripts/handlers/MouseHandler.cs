using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class MouseHandler : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] GameObject piece;

    bool listening = true;

    void Start()
    {
        if (!cam)
        {
            Debug.LogError("No camera set!");
        }
    }

    void Update()
    {
        if (listening)
        {
            RaycastHit hit;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                int tilemask = 1 << 6; // Tiles are on layer 6

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, tilemask))
                {
                    Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 2);

                    hit.transform.gameObject.GetComponent<Tile>().placePiece(piece);
                }
                else
                {
                    Debug.DrawRay(ray.origin, ray.direction * 100, Color.white, 2);
                }
            }
        }   
    }

    public void setListening(bool listening)
    {
        this.listening = listening;
    }

    public void setPiece(GameObject piece)
    {
        this.piece = piece;
    }
}
