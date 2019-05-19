using UnityEngine;
using UnityEngine.UI;

public class FlyMeter : MonoBehaviour
{
    public GameObject Meter;
    public Slider MeterSlider;

    private Player player;
    private PlayerMovement movement;

    void Start()
    {
        player = FindObjectOfType<Player>();
        movement = player.GetComponent<PlayerMovement>();
        player.Killcounter.OnThresholdsPassed += ThresholdPassed;
        MeterSlider.maxValue = movement.FlyingMeterMax;

        Meter.SetActive(false);
    }

    private void ThresholdPassed(int num)
    {
        if(num == 1)
        {
            //Enable fly bar.
            Meter.SetActive(true);
        }
    }

    void Update()
    {
        if (Meter.activeSelf)
        {
            MeterSlider.value = movement.FlyingMeter;
        }
    }
}
