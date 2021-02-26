using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    //will change these to private after testing
    public string playerName;
    public int[] abilityScores = new int[6]; //Strength Dexterity Constitution Intelligence Wisdom Charisma
    public string race;
    public string playerClass;
    public string alignment;
    public int currentXP;
    public int maxXP;
    public int currentHP;
    public int maxHP;
    public int armorClass;
    public float[] playerSpeeds = new float[3]; //Walking Running JumpHeight
    public List<string> itemList = new List<string>();

    public void changeName(string characterName)
    {
        playerName = characterName;
        Debug.Log("Changed Character Name to: " + playerName);
    }

    public void setClass(string newClass)
    {
        playerClass = newClass;
        Debug.Log("Changed Character Class to: " + playerClass);
    }

    public void setRace(string newRace)
    {
        race = newRace;
        Debug.Log("Changed Character Class to: " + race);
    }
}
