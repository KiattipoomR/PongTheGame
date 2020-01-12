using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector2 pos_bottomLeft;
    public static Vector2 pos_topRight;

    public Player player;
    public Ball ball;

    // Start is called before the first frame update
    void Start()
    {
        // Converts screen's coordinate in to game's.
        pos_bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        pos_topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        // Instantiates a ball.
        Instantiate(ball);

        // Instantiate players.
        Player player_one = Instantiate(player) as Player;
        Player player_two = Instantiate(player) as Player;

        player_one.Init(false); // Player 1
        player_two.Init(true); // Player 2

    }
}
