using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawns : MonoBehaviour {
    public List<Transform> spawnPoints = new List<Transform>();
    public List<GameObject> enemyType = new List<GameObject>();
    public float spawnTimer;
    public float backupTimer;
    public float survivalTimer;
    public GameObject barrier;
    public bool isDivided = false;
    public AudioSource source;
    public AudioClip startTune;
    public AudioClip endTune;
	// Use this for initialization
	void Start () {
        backupTimer = spawnTimer;
        barrier = GameObject.FindGameObjectWithTag("Barrier");
        source.PlayOneShot(startTune, 1);

    }
	
	// Update is called once per frame
	void Update () {
        survivalTimer -= Time.deltaTime;
        spawnTimer -= Time.deltaTime;
        if (spawnTimer < 0)
        {
            spawnEnemyAtRandom();
            spawnTimer = backupTimer;
        }
        if (survivalTimer < 45 && isDivided == false)
        {
            backupTimer = backupTimer / 2;
            isDivided = true;
        }
        if (survivalTimer < 0)
        {
            Destroy(barrier);
            gameObject.SetActive(false);
            source.PlayOneShot(endTune, 1);
        }
	}
    public void spawnEnemyAtRandom ()
    {
        int spawnPos = Random.Range(0, spawnPoints.Count);
        int type = Random.Range(0, enemyType.Count);
        Instantiate(enemyType[type], spawnPoints[spawnPos].transform);
    }
}
