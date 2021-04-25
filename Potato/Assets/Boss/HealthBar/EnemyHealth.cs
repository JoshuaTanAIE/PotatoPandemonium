using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth;
    [HideInInspector] public float currentHealth;
    public GameObject key;
    public Vector3 keySpawnPos;
    public GameObject explodePrefab;

    public Canvas healthBarCanvasPrefab;
    [HideInInspector] public Canvas healthBarCanvas;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    public void StartFight()
    {
        healthBarCanvas = Instantiate(healthBarCanvasPrefab, transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerAttack"))
        {
            currentHealth -= 1;

            if(currentHealth <= 0)
            {
                Destroy(gameObject);
                key.transform.position = keySpawnPos;
                Instantiate(explodePrefab, transform.position, transform.rotation);
                Destroy(healthBarCanvas.gameObject);
            }
        }
    }
}
