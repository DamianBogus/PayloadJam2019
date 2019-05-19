using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    public GameObject DeathPanel;

    public void Start()
    {
        DeathPanel.SetActive(false);
    }

    public void EnableDeathPanel()
    {
        DeathPanel.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene("Damian");
    }
}
