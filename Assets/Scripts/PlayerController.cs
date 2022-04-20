using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rigidbody2d;
    public float speed;
    public GameObject gameWonPanel;
    public GameObject gamePausePanel;
    private bool isGameWon = false;
    private bool isGamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Code to Pause/Resume Game on Press of Esc key
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if (isGamePaused == true)
            {
                isGamePaused = false;
                gamePausePanel.SetActive(false);
            }
            else if (isGamePaused == false)
            {
                isGamePaused = true;
                gamePausePanel.SetActive(true);
               
            }
            
        }
        if(isGameWon == true || isGamePaused == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }

        else
        {

            if (Input.GetAxis("Horizontal") > 0)
            {
                rigidbody2d.velocity = new Vector2(speed, 0f);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                rigidbody2d.velocity = new Vector2(-speed, 0f);
            }
            else if (Input.GetAxis("Vertical") > 0)
            {
                rigidbody2d.velocity = new Vector2(0f, speed);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                rigidbody2d.velocity = new Vector2(0f, -speed);
            }
            else if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0)
            {
                rigidbody2d.velocity = new Vector2(0f, 0f);
            }
        }

    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            Debug.Log("Level Complete!!!");
            gameWonPanel.SetActive(true);
            isGameWon = true;
        }
        
    }
}
