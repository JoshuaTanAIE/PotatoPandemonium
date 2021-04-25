using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenacingSpawnerScript: MonoBehaviour
{
    public int noOfSpawns;
    int counter = 0;
    public GameObject menacingPrefab;
    public float spawnX;
    public Vector2 spawnRangeY;
    Vector2 spawnPos = new Vector2();
    Vector3 scale = new Vector3();
    public Vector2 sizeRange;

    public float startTimeTillSpawn;
    float timeTillSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeTillSpawn = startTimeTillSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeTillSpawn > 0)
        {
            timeTillSpawn -= Time.deltaTime;
        }
        else
        {
            if (counter < noOfSpawns)
            {
                float spawnY = Random.Range(spawnRangeY.x, spawnRangeY.y);
                spawnPos.Set(spawnX, spawnY);

                float size = Random.Range(sizeRange.x, sizeRange.y);
                scale.Set(size, size, size);

                GameObject menacing = Instantiate(menacingPrefab, spawnPos, transform.rotation);
                menacing.transform.localScale = scale;

                timeTillSpawn = startTimeTillSpawn;
                counter++;
            }
        }
    }
}
