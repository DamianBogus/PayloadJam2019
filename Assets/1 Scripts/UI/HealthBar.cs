using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Player player;
    public Slider slider;
    private  float maxHealth;

    private void Start()
    {
        maxHealth = player.Health;
    }

    private void Update()
    {
        slider.value = player.Health / maxHealth;
    }

}
