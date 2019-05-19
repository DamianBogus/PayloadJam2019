using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillcounterUI : MonoBehaviour
{
    public Text KillCountText;

    private KillCounter counter;

    public void Start()
    {
        counter = FindObjectOfType<Player>().Killcounter;
    }

    public void Update()
    {
        KillCountText.text = counter.Kills.ToString();
    }
}
