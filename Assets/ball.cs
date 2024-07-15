using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ball : MonoBehaviour
{
    public TMP_Text player1text;
    public TMP_Text player2text;
    public GameObject P1WinText;
    public GameObject P2WinText;
    public float velocitybank = float.NaN;

    private Quaternion direction;
    private float initialSpeed = 500000;
    private float multiplier = 1.15f;
    private Rigidbody2D rb;
    private int player1score = 0;
    private int player2score = 0;

    // Start is called before the first frame update
    void Start()
    {
        direction = Quaternion.Euler(0, 0, Random.Range(-70, 70));
        rb = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1.5f);
        rb.AddForce(new Vector3(Mathf.Cos(Mathf.Deg2Rad * direction.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * direction.eulerAngles.z), 0) * Time.deltaTime * initialSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(rb.velocity.x, rb.velocity.y, 0) * Time.deltaTime * multiplier);
        if (Input.GetKeyDown(KeyCode.R))
        {
            P1WinText.SetActive(false);
            P2WinText.SetActive(false);
            direction = Quaternion.Euler(0, 0, Random.Range(-70, 70));
            initialSpeed = 500000;
            player1score = 0;
            player2score = 0;
            player1text.text = player1score.ToString();
            player2text.text = player2score.ToString();
            transform.position = new Vector3(0, 0, 0);
            rb.velocity = Vector3.zero;
            rb.AddForce(new Vector3(Mathf.Cos(Mathf.Deg2Rad * direction.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * direction.eulerAngles.z), 0) * Time.deltaTime * initialSpeed);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
        if (player1score == 10)
        {
            P1WinText.SetActive(true);
            rb.velocity = Vector3.zero;
        }
        if (player2score == 10)
        {
            P2WinText.SetActive(true);
            rb.velocity = Vector3.zero;
        }
    }

    IEnumerator OnScore()
    {
        rb.velocity = Vector3.zero;
        transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1.5f);
        direction = Quaternion.Euler(0, 0, Random.Range(0, 360));
        initialSpeed = 500000;
        rb.AddForce(new Vector3(Mathf.Cos(Mathf.Deg2Rad * direction.eulerAngles.z), Mathf.Sin(Mathf.Deg2Rad * direction.eulerAngles.z), 0) * Time.deltaTime * initialSpeed);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            player1score++;
            player1text.text = player1score.ToString();
            StartCoroutine(OnScore());
        }
        if (collision.gameObject.tag == "wall2")
        {
            player2score++;
            player2text.text = player2score.ToString();
            StartCoroutine(OnScore());
        }

    }
}
