using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIButtons : MonoBehaviour
{
    [SerializeField] GameObject sidePanel;
    [SerializeField] GameManager gameManager;
    
    public void toggleSidePanel()
    {
        sidePanel.SetActive(!sidePanel.activeSelf);
    }

    public void endTurn_buttonAction()
    {
        gameManager.endTurn();
    }

    public void roll_buttonAction()
    {
        gameManager.roll();
    }
}
