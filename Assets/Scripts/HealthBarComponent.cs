using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarComponent : MonoBehaviour
{
    Image foreground, background;

    // Start is called before the first frame update
    void Start()
    {
        Image[] images = GetComponentsInChildren<Image>();
        background = images[0];
        foreground = images[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBar(float health, float maxHealth)
    {
        foreground.fillAmount = health / maxHealth;
    }

    public void SetBar(float fillAmount)
    {
        foreground.fillAmount = fillAmount;
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
