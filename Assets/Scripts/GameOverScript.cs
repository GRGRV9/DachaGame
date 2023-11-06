using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{

    public DachaController dacha;

    public GameObject GameOverBadUI;

    public GameObject GameOverWinUI;

    // Update is called once per frame
    void Update()
    {
        if (dacha.GetIsDead())
        {
            GameOverBadUI.SetActive(true);
        }

        // if (dacha.GetWon())
        // {
        //     GameOverWinUI.SetActive(true);
        // }
    }

    public void QuitToMenuButtonClick () {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart () {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

}
