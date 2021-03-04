using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneManager : MonoBehaviour
{
    public void onPlayClicked()
    {
        if (GameManager.Instance.rolledCharacter)
        {
            Debug.Log("On Play Button Click");
            SceneManager.LoadScene("PlayScene");
        }
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
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
