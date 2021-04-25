using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public bool isHeal;
    public bool isDash;
    public bool isFly;
    public bool isSuperDash;
    GameManagerScript gameManagerScript;
    public Canvas flyCanvas;
    public Canvas rollCanvas;
    public Canvas superDashCanvas;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            Player player = collision.GetComponent<Player>();

            if(isHeal)
            {
                player.health = player.maxHealth;
            }

            if(isDash)
            {
                player.hasDash = true;
                gameManagerScript.isPaused = true;
                Time.timeScale = 0;
                gameManagerScript.pauseCanvas = Instantiate(rollCanvas);
            }

            if (isFly)
            {
                player.hasFly = true;
                gameManagerScript.isPaused = true;
                Time.timeScale = 0;
                gameManagerScript.pauseCanvas = Instantiate(flyCanvas);
            }

            if(isSuperDash)
            {
                player.hasSuperDash = true;
                gameManagerScript.isPaused = true;
                Time.timeScale = 0;
                gameManagerScript.pauseCanvas = Instantiate(superDashCanvas);
            }

            Destroy(gameObject);
        }
    }
}
