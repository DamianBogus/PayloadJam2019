using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Player player;
    public Slider slider;
    public Text HealthText;
    private float maxHealth;

    private void Start()
    {
        if (player == null) player = FindObjectOfType<Player>();

        maxHealth = player.Health;
    }

    private void LateUpdate()
    {
        slider.value = player.Health / maxHealth;
        HealthText.text = player.Health.ToString();
    }

}
