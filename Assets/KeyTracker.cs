using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyTracker : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    void FixedUpdate()
    {
        if (gameManager.keys_collected < 3)
        {
            gameObject.GetComponent<Text>().text = "<color=yellow>Keys:" + gameManager.keys_collected + "/3</color>";
        }
        else
        {
            gameObject.GetComponent<Text>().text = "<color=cyan>You can escape!\nKeys: " + gameManager.keys_collected + "/3</color>";
        }
    }
}
