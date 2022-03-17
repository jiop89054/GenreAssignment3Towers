using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform enemyPrefab2;
    public Transform enemyPrefab3;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    //public float timeBetweenAltWaves = 8f;
    private float countdown = 2f;

    public GameObject waveCountdownText;

    private int waveNumber = 1;
    //private int altWaveNumber = 1;

    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.GetComponent<TextMeshProUGUI>().text = "Next wave: " + Mathf.Floor(countdown).ToString();


    }
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveNumber; i++)
        {
            if (waveNumber < 5)
                SpawnEnemy();
            else if (waveNumber < 10)
                SpawnEnemy2();
            else SpawnEnemy3();
            yield return new WaitForSeconds(.5f);
        }
        /*for (int i = 0; i < altWaveNumber; i++)
        {
            SpawnOtherEnemy();
            yield return new WaitForSeconds(.8f);
        }*/
        waveNumber++;
        timeBetweenWaves += .5f;
        if(waveNumber == 25)
        {
            FindObjectOfType<MenuScript>().LoadLevel("Winscreen");
        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnEnemy2()
    {
        Instantiate(enemyPrefab2, spawnPoint.position, spawnPoint.rotation);
    }
    void SpawnEnemy3()
    {
        Instantiate(enemyPrefab3, spawnPoint.position, spawnPoint.rotation);
    }
}
