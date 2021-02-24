using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSceneManager : MonoBehaviour
{
    public void returnToMain()
    {
        Debug.Log("Return to Main Menu");
        GameManager.Instance.rolledCharacter = true;
        SceneManager.LoadScene("MainScene");
    }

    public void changeName(string newName)
    {
        GameManager.Instance.playerStats.changeName(newName);
    }
}
