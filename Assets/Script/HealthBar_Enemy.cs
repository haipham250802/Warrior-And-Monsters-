using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Enemy : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public float MaxHealth;
    float currentHealth;

    public float CurrentHealth { get => currentHealth;private set => currentHealth = value; }

    private void Awake()
    {
        currentHealth = MaxHealth;
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void setHealth(float damage)
    {
        currentHealth -= damage;
        slider.gameObject.SetActive(currentHealth < MaxHealth);
        slider.fillRect.GetComponent<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
        slider.value = currentHealth;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            setHealth(10);
        }
    }
}
