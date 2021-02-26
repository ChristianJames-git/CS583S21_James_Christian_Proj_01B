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
        Debug.Log("Name: " + GameManager.Instance.playerStats.playerName);
        Debug.Log("Str: " + GameManager.Instance.playerStats.abilityScores[0] + " Con: " + GameManager.Instance.playerStats.abilityScores[1] + " Dex: " + GameManager.Instance.playerStats.abilityScores[2] + " Int: " + GameManager.Instance.playerStats.abilityScores[3] + " Wis: " + GameManager.Instance.playerStats.abilityScores[4] + " Cha: " + GameManager.Instance.playerStats.abilityScores[5]);
        Debug.Log("Class: " + GameManager.Instance.playerStats.playerClass);
        Debug.Log("Race: " + GameManager.Instance.playerStats.playerRace);
        Debug.Log("Alignment: " + GameManager.Instance.playerStats.alignment);
        Debug.Log("XP: " + GameManager.Instance.playerStats.currentXP + " / " + GameManager.Instance.playerStats.maxXP);
        Debug.Log("HP: " + GameManager.Instance.playerStats.currentHP + " / " + GameManager.Instance.playerStats.maxHP);
        Debug.Log("AC: " + GameManager.Instance.playerStats.armorClass);
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
