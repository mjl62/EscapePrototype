using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    enum GAMESTATE { INIT, TURN, END };

    GAMESTATE gamestate = GAMESTATE.INIT;
    List<Player> players = new List<Player>();
    [SerializeField] MouseHandler mouseHandler;

    [SerializeField] GameObject Player1Piece;
    [SerializeField] GameObject Player2Piece;
    [SerializeField] GameObject Player3Piece;
    [SerializeField] GameObject Player4Piece;

    int playerturn_index = 0;
    Player currentPlayer = null;
    int keys_collected = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Create players and robot
        Player player1 = new Player("Human 1", Player1Piece);
        Player player2 = new Player("Human 2", Player2Piece);
        Player player3 = new Player("Human 3", Player3Piece);
        Player player4 = new Robot("Robot", Player4Piece);
        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);

        // Set current player
        currentPlayer = players[0];

        //StartCoroutine(GameLoop());
    }


    public void endTurn()
    {
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
        Debug.Log(currentPlayer.getName() + " rolls " + rolled);
    }

}

public class Player
{
    string name = "Player";
    bool alive = true;
    int movement = 0;

    GameObject piece;

    public Player(string name, GameObject piece)
    {
        this.name = name;
        this.piece = piece;
    }

    public int roll()
    {
        movement = Random.Range(1, 7);
        return movement;
    }

    public bool doMovement()
    {
        if (movement > 0)
        {
            movement--;
            return true;
        }
        return false;
    }

    public void setMovement(int movement)
    {
        this.movement = movement;
    }

    public int getMovement()
    {
        return movement;
    }

    public GameObject getPiece()
    {
        return piece;
    }

    public void die()
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

    public Robot(string name, GameObject piece) : base(name, piece)
    {
    }

    public new int roll()
    {
        setMovement(3);
        int random_roll = Random.Range(0, 10);

        switch (random_roll)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                break;
            case 4:
                setMovement(4);
                break;
            case 5:
                setMovement(5);
                break;
            case 6:
            case 7:
                Debug.Log("Freeze Trap");
                break;
            case 8:
                Debug.Log("Teleport");
                break;
            case 9:
                Debug.Log("Robot Move Player");
                break;
            case '_':
                Debug.LogError("Unexpected value: " + random_roll);
                break;
        }

        return random_roll;
    }

    public new void die()
    {
        Debug.Log("Robot cannot die!");
    }
}