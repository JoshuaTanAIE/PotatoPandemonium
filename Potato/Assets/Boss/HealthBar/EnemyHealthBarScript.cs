using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarScript : MonoBehaviour
{
    public EnemyHealth owner;
    Image currentHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealthBar = GetComponent<Image>();
        owner = GetComponentInParent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = owner.currentHealth/owner.maxHealth;
    }
}
