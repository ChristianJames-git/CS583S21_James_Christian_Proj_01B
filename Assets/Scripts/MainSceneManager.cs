using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour
{
    public GameObject youSurePanel;
    public GameObject mainPanel;
    public Button playButton;

    public void Start()
    {
        youSurePanel.SetActive(false);
        if (!GameManager.Instance.rolledCharacter)
            playButton.interactable = false;
        else
            playButton.interactable = true;
    }

    public void onPlayClicked()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void onRollCharacterClicked()
    {
        if (GameManager.Instance.rolledCharacter)
        {
            youSurePanel.SetActive(true);
            mainPanel.SetActive(false);
        }
        else
            SceneManager.LoadScene("RollCharacterScene");
    }

    public void onQuitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void onYesClicked()
    {
        GameManager.Instance.rolledCharacter = false;
        GameManager.Instance.playerStats = new PlayerStats();
        SceneManager.LoadScene("RollCharacterScene");
    }

    public void onNoClicked()
    {
        youSurePanel.SetActive(false);
        mainPanel.SetActive(true);
    }
}
