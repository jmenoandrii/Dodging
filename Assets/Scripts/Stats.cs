using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private HealthPanel healthPanel;
    [SerializeField]
    private AudioSource minusHealthSound, addHealthSound;

    [SerializeField]
    private float times;
    [SerializeField]
    private Text timesText;
    [SerializeField]
    private Text timesRecordText;

    public int Lives { 
        get => health;
        set
        {
            if (value < health)
                minusHealthSound.Play();
            else
                addHealthSound.Play();
            health = Mathf.Clamp(value, 0, maxHealth);

            healthPanel.Health = health;
            if (health <= 0)
            {
                StateGame.singleton.End();
                if (PlayerPrefs.GetInt("Time") < Times)
                    WriteRecord();
                else
                    timesRecordText.text = "Your Record: " + Timer(PlayerPrefs.GetInt("Time"));
            }

        }
    }

    public float Times { 
        get => times; 
        set { 
            times = value;
            timesText.text = Timer((int)times);
        }
    }

    public static Stats singleton;

    private string Timer(int value)
    {
        string t = (value / 3600).ToString("00") + ":";
        value -= (value / 3600) * 3600;
        t += (value / 60).ToString("00") + ":";
        t += (value % 60).ToString("00");
        return t;
    }

    private void WriteRecord()
    {
        timesRecordText.text = "Your Record: " + Timer((int)Times);
        PlayerPrefs.SetInt("Time", (int)Times);
    }

    private void Awake()
    {
        singleton = this;
    }

    private void Update()
    {
        if (!StateGame.singleton.GameEnded())
            Times += Time.deltaTime;
    }
}
