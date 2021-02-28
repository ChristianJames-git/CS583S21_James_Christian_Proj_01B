using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlaySceneManager : MonoBehaviour
{

    public TMP_Text textL;
    public TMP_Text textR;
    // Start is called before the first frame update
    void Start()
    {
        textL.text = "Name: " + GameManager.Instance.playerStats.playerName;
        textL.text += "\nRace: " + GameManager.Instance.playerStats.playerRace;
        textL.text += "\nClass: " + GameManager.Instance.playerStats.playerClass;
        textR.text += "Speeds:\n     Walking: " + GameManager.Instance.playerStats.playerSpeeds[0] + "\n     Running: " + GameManager.Instance.playerStats.playerSpeeds[1] + "\n     Jump Height: " + GameManager.Instance.playerStats.playerSpeeds[2];
        textR.text += "\nStats:\n   Strength: " + GameManager.Instance.playerStats.abilityScores[0] + "\n   Constitution: " + GameManager.Instance.playerStats.abilityScores[1] + "\n   Dexterity: " + GameManager.Instance.playerStats.abilityScores[2] + "\n   Wisdom: " + GameManager.Instance.playerStats.abilityScores[3] + "\n   Intelligence: " + GameManager.Instance.playerStats.abilityScores[4] + "\n   Charisma: " + GameManager.Instance.playerStats.abilityScores[5];
        textL.text += "\nAlignment: " + GameManager.Instance.playerStats.alignment;
        textR.text += "\nHealth: " + GameManager.Instance.playerStats.currentHP + " / " + GameManager.Instance.playerStats.maxHP;
        textR.text += "\nExperience: " + GameManager.Instance.playerStats.currentXP + " / " + GameManager.Instance.playerStats.maxXP;
        textR.text += "\nArmor Class: " + GameManager.Instance.playerStats.armorClass;
        textL.text += "\nItem List: ";
    }

    public void onBack()
    {
        SceneManager.LoadScene("MainScene");
    }
}
