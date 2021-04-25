using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeTransition : MonoBehaviour
{
    Image image;
    float alpha;
    public float amountOfFade;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 1;

        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.color = new Color(0, 0, 0, alpha);

        alpha -= amountOfFade * Time.deltaTime;

        if (alpha < 0)
        {
            Destroy(GetComponentInParent<Canvas>().gameObject);
        }
    }
}
