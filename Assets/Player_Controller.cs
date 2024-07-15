using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public bool player1;
    public bool player2;

    private float speed = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 4)
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
        if (transform.position.y < -4)
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if (player1 && transform.position.y < 4 && transform.position.y > -4)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
            }
        }
        if (transform.position.y > 4)
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
        if (transform.position.y < -4)
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if (player2 && transform.position.y < 4 && transform.position.y > -4)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, speed, 0) * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -speed, 0) * Time.deltaTime);
            }
        }
        if (player1 && Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(-9, 0, 0);
        }
        if (player2 && Input.GetKeyDown(KeyCode.R))
        {
            transform.position = new Vector3(9, 0, 0);
        }
    }
}
