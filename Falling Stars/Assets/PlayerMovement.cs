using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public static int score;
    public int previousScore;

    public float speed;
    public float timeInSeconds;
    public float bulletForce;

    public GameObject bullet;
    public Transform bulletPoint;

    public TMP_Text scoreTxt;
    public TMP_Text time;

    public GameObject rToRestart;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            score = 0;
            SceneManager.LoadScene(1);
        }

        scoreTxt.text = "Score: " + score;
        time.text = "Time in S: " + timeInSeconds.ToString("0");

        timeInSeconds += 1 * Time.deltaTime;

        if(previousScore < score)
        {
            previousScore = score;

            speed += (.008135f * score);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }else if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }else if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }else if(Input.GetKey(KeyCode.S))
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }

        speed += (.00008135f * timeInSeconds) * Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject currentBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            currentBullet.transform.Rotate(0, 0, 90);
            currentBullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletForce), ForceMode2D.Impulse);
        }

        if(transform.position.y > 6)
        {
            transform.position = new Vector2(transform.position.x, -5.99f);
        }else if(transform.position.y < -6)
        {
            transform.position = new Vector2(transform.position.x, 5.99f);
        }
        else if(transform.position.x > 10)
        {
            transform.position = new Vector2(-9.99f, transform.position.y);
        }else if (transform.position.x < -10)
        {
            transform.position = new Vector2(10, transform.position.y);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Asteroid"))
        {
            Time.timeScale = 0;
            rToRestart.SetActive(true);
        }
    }
}
