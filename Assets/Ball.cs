using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    private float speed;

    private float radius;
    private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized; // The direction is normalized (1,1)
        radius = transform.localScale.x / 2; // Halves the width
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        //Bounces off top and bottom of the window
        if (transform.position.y > GameManager.pos_topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y < GameManager.pos_bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }

        //Game over message
        if (transform.position.x > GameManager.pos_topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Player 1 wins.");
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.x < GameManager.pos_bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Player 2 wins.");
            Time.timeScale = 0;
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ThePlayer")
        {
            bool isRight = other.GetComponent<Player>().isRight;

            //Bounces off the player
            if(isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
            if(isRight == true && direction.x > 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}
