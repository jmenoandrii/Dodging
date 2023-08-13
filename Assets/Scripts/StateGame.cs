using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateGame : MonoBehaviour
{
    private bool end;

    [SerializeField]
    private GameObject endGamePanel;

    public static StateGame singleton;

    private void Awake()
    {
        singleton = this;
    }

    private void Update()
    {
        if (GameEnded() && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public bool GameEnded()
    {
        return end;
    }

    public void End()
    {
        end = true;
        endGamePanel.SetActive(true);
    }
}
