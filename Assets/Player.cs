using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private float height;
    private string input;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
        speed = 10f;
    }

    public void Init(bool isRightSide)
    {
        // If isRight, places player at the right side of screen, else, places at left side
        // Then, moves a bit away from the camera edge
        Vector2 pos = Vector2.zero;
        isRight = isRightSide;

        if (isRight)
        {
            pos = new Vector2(GameManager.pos_topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            input = "PlayerTwo";
        }
        else
        {
            pos = new Vector2(GameManager.pos_bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "PlayerOne";
        }

        // Last, updates the player's attribute
        transform.position = pos;
        transform.name = input;
    }

    // Update is called once per frame
    void Update()
    {
        // A method to move the player
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        // Restrains player from moving outside of the window
        if(transform.position.y < GameManager.pos_bottomLeft.y + (height / 2) && move < 0)
        {
            move = 0;
        }
        if(transform.position.y > GameManager.pos_topRight.y - (height / 2) && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
