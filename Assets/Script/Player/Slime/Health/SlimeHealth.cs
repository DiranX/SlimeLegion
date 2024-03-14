using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Slider healthSlider;
    

    // Start is called before the first frame update
    void Start()
    {
        
        maxHealth = health;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
            
        }
    }
}
