using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [HideInInspector] public bool isPaused;
    [HideInInspector] public Canvas pauseCanvas;
    public Canvas pauseCanvasPrefab;
    Transform playerPos;

    public Vector2 spawnWallAtPlayerPosition;
    public Vector2 spawnWallPos;
    public GameObject wallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = true;
        Time.timeScale = 0;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        pauseCanvas = Instantiate(pauseCanvasPrefab);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            if (isPaused)
            {
                isPaused = false;
                Destroy(pauseCanvas.gameObject);
                Time.timeScale = 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                isPaused = true;
                pauseCanvas = Instantiate(pauseCanvasPrefab);
                Time.timeScale = 0;
            }
        }

        if(Vector2.Distance(playerPos.position, spawnWallAtPlayerPosition) < 3)
        {
            Instantiate(wallPrefab, spawnWallPos, Quaternion.Euler(0, 0, 0));
        }
    }
}
