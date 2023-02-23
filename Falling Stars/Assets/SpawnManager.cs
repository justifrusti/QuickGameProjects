using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject star;

    public Transform[] spawnPoints;

    public bool isSpawningA;
    public bool isSpawningS;

    private void Update()
    {
        if(!isSpawningA)
        {
            isSpawningA = true;
            Invoke("SpawnAsteroid", Random.Range(1.0f, 3.0f));
        }

        if (!isSpawningS)
        {
            isSpawningS = true;
            Invoke("SpawnStar", Random.Range(5.0f, 10.0f));
        }
    }

    public void SpawnAsteroid()
    {
        int ammount = Random.Range(1, 5);

        for (int i = 0; i < ammount; i++)
        {
            GameObject a = Instantiate(asteroid, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            float force = Random.Range(1, 5);

            a.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -force), ForceMode2D.Impulse);

            if(ammount >= i)
            {
                isSpawningA = false;
            }
        }
    }

    public void SpawnStar()
    {
        GameObject s = Instantiate(star, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        float force = Random.Range(1, 5);

        s.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -force), ForceMode2D.Impulse);

        isSpawningS = false;
    }
}
