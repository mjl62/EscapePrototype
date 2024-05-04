using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    List<Player> players = new List<Player>();
    [SerializeField] MouseHandler mouseHandler;

    [SerializeField] GameObject Player1Piece;
    [SerializeField] GameObject Player2Piece;
    [SerializeField] GameObject Player3Piece;
    [SerializeField] GameObject Player4Piece;

    int playerturn_index = 0;
    public Player currentPlayer = null;
    public int keys_collected = 0;

    // What to display in the text box at the top of the UI
    public string textBox = "";

    // Start is called before the first frame update
    void Start()
    {
        // Create players and robot
        Player player1 = new Player("Human 1", Player1Piece, "yellow");
        Player player2 = new Player("Human 2", Player2Piece, "blue");
        Player player3 = new Player("Human 3", Player3Piece, "red");
        Player player4 = new Robot("Robot", Player4Piece, "white");
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);

        // Set current player
        currentPlayer = players[0];
    }

    public void endTurn()
    {
        textBox = "";
        if (playerturn_index >= 3) playerturn_index = 0;
        else playerturn_index++;

        if (players[playerturn_index].isAlive())
        {
            currentPlayer = players[playerturn_index];
            mouseHandler.setPiece(currentPlayer.getPiece());
        }
        else endTurn();
    }

    public void roll()
    {
        int rolled = currentPlayer.roll();
        textBox = currentPlayer.getName() + " rolls " + rolled;
        if (playerturn_index == 3)
        {
            if (rolled <= 3) textBox = ("Robot can move 3 spaces");
            else if (rolled == 4) textBox = ("Robot can move 4 spaces");
            else if (rolled == 5) textBox = ("Robot can move 5 spaces");
            else if (rolled == 6 || rolled == 7) textBox = ("Robot can move 3 spaces and place a <color=blue>Freeze Trap</color>");
            else if (rolled == 8) textBox = ("Teleport to any <color=purple>Teleport Space</color>");
            else if (rolled == 9) textBox = ("Robot can move a human player 3 spaces any direction!");
            else Debug.LogError("Unexpected value: " + rolled);
        }
    }

    public void keyGet()
    {
        keys_collected++;
    }

    public void checkPlayerStatus()
    {
        for (int i = 0; i < 3; i++)
        {
            if (players[i].getPiece().transform.position == players[3].getPiece().transform.position)
            {
                players[i].die();
                players[i].getPiece().SetActive(false);
            }
        }
    }

}

public class Player
{
    string name = "Player";
    bool alive = true;
    int movement = 0;
    string color;

    GameObject piece;

    public Player(string name, GameObject piece, string color)
    {
        this.name = name;
        this.piece = piece;
        this.color = color;
    }

    public string getColor()
    {
        return color;
    }

    public virtual int roll()
    {
        movement = Random.Range(1, 7);
        return movement;
    }


    public GameObject getPiece()
    {
        return piece;
    }

    public virtual void die()
    {
        alive = false;
    }

    public string getName()
    {
        return name;
    }

    public bool isAlive()
    {
        return alive;
    }
}

public class Robot : Player
{

    public Robot(string name, GameObject piece, string color) : base(name, piece, color)
    {
    }

    public override int roll()
    {
        int random_roll = Random.Range(0, 10);
        return random_roll;
    }

    public override void die()
    {
        Debug.Log("Robot cannot die!");
    }
}