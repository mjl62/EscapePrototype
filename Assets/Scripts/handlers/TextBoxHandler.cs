using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxHandler : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] Text text;

    void FixedUpdate()
    {
        text.text = 
            "<color=" + gameManager.currentPlayer.getColor() + ">" 
            + gameManager.currentPlayer.getName() + " Turn\n" +
            "</color>"
            + gameManager.textBox;
    }
}
