using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MainScene - In start function.");
    }

    public void onPlayClicked()
    {
        if (GameManager.Instance.rolledCharacter)
            Debug.Log("On Play Button Click");
        else
            Debug.Log("Roll Character First");
    }

    public void onRollCharacterClicked()
    {
        Debug.Log("On Roll Character Button Click");
        SceneManager.LoadScene("RollCharacterScene");
    }

    public void onQuitClicked()
    {
        // Add to onClick() for button. Choose this function
        Debug.Log("On Quit Button Click");
        Debug.Log(GameManager.Instance.playerStats.playerName);
        Debug.Log(GameManager.Instance.playerStats.playerClass);
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
