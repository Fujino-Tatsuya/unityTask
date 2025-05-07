using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] Transform[] SpawnPoints;

    [SerializeField] GameObject arrow;
    [SerializeField] GameObject lineArrow;

    int spawnPointIndex = 0;
    int fiveSecondSpawnIndex = 0;

    int lineSpawnRange = 6;
    void Start()
    {
        //StartCoroutine(SpawnArrowsCoroutine());
        //StartCoroutine(SpawnEvenIndexArrowsCoroutine());
        StartCoroutine(SpawnLineIndex());
    }

    void Update()
    {

    }
    float CalculateSpawnDelay(float timeRemaining)
    {
        float rate;

        if (timeRemaining >= 60f)
        {
            rate = 1f;
        }
        else if (timeRemaining >= 30f)
        {
            rate = Mathf.Lerp(3f, 1f, (timeRemaining - 30f) / (60f - 30f));
        }
        else if (timeRemaining >= 10f)
        {
            rate = Mathf.Lerp(5f, 3f, (timeRemaining - 10f) / (30f - 10f));
        }
        else
        {
            rate = 5f;
        }

        rate = Mathf.Max(1f, rate);

        float delay = 1f / rate;

        return delay;
    }

    IEnumerator SpawnArrowsCoroutine()
    {
        while (GameManager.survivalTime > 0f && SpawnPoints != null && SpawnPoints.Length > 0)
        {
            float timeRemaining = GameManager.survivalTime;

            float delay = CalculateSpawnDelay(timeRemaining);

            Instantiate(arrow, SpawnPoints[spawnPointIndex].position, SpawnPoints[spawnPointIndex].rotation);

            spawnPointIndex = (spawnPointIndex + 1) % SpawnPoints.Length;

            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator SpawnEvenIndexArrowsCoroutine()
    {
        yield return new WaitForSeconds(5f);

        while (GameManager.survivalTime > 0f)
        {
            for (int i = 0; i < SpawnPoints.Length; i++)
            {
                if (i % 4 == 0)
                {
                    Instantiate(arrow, SpawnPoints[i].position, SpawnPoints[i].rotation);
                }
            }
            yield return new WaitForSeconds(5f);
        }
    }

    int index = 0;
    IEnumerator SpawnLineIndex()
    {
        yield return new WaitForSeconds(1f);
        while (GameManager.survivalTime > 0f)
        {
            index++;
            switch (index % 4)
            {
                case 0:
                    for (int i = 0; i < lineSpawnRange; i++)
                    {
                        Instantiate(lineArrow, SpawnPoints[i].position, SpawnPoints[i].transform.rotation);
                    }
                    break;
                case 1:
                    for (int i = 6; i < lineSpawnRange+6; i++)
                    {
                        Instantiate(lineArrow, SpawnPoints[i].position, SpawnPoints[i].transform.rotation);
                    }
                    break;
                case 2:
                    for (int i = 12; i < lineSpawnRange+12; i++)
                    {
                        Instantiate(lineArrow, SpawnPoints[i].position, SpawnPoints[i].transform.rotation);
                    }
                    break;
                case 3:
                    for (int i = 18; i < lineSpawnRange+18; i++)
                    {
                        Instantiate(lineArrow, SpawnPoints[i].position, SpawnPoints[i].transform.rotation);
                    }
                    break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
