using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSceneManager : MonoBehaviour
{
    private GameManager gm;
    private PlayerStats ps;
    public List<GameObject> inputPanels;
    public GameObject characterNamePanel, abilitiesPanel, racesPanel, classesPanel, alignmentPanel, jsonPanel;
    private int currentPanel;
    private bool panelComplete;
    public TMP_Text abilityScoreTxt, raceDescription, classDescription;
    public TMP_InputField outputJSON;
    public void Start()
    {
        gm = GameManager.Instance;
        ps = gm.playerStats;
        inputPanels.Add(characterNamePanel);
        inputPanels.Add(abilitiesPanel);
        inputPanels.Add(racesPanel);
        inputPanels.Add(classesPanel);
        inputPanels.Add(alignmentPanel);
        inputPanels.Add(jsonPanel);
        ResetPanels();
        OpenPanel(0);
    }
    
    void ResetPanels()
    {
        for (int i = 0; i < inputPanels.Count; i++)
        {
            inputPanels[i].SetActive(false);
        }
    }

    public void OpenPanel(int index)
    {
        if (index == -1)
        {
            Debug.Log("Return to Main Menu");
            gm.rolledCharacter = true;
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            if (index > 0)
                inputPanels[index - 1].SetActive(false);
            inputPanels[index].SetActive(true);
            panelComplete = false;
            currentPanel = index;
            outputJSON.text = JsonUtility.ToJson(gm.playerStats, true);
        }
    }

    public void submitPanel()
    {
        if (panelComplete)
        {
            Debug.Log("Panel Complete");
            OpenPanel(++currentPanel);
        }
        else
            Debug.Log("Finish before submitting");
    }

    public void changeName(string newName)
    {
        Debug.Log("Name: " + newName);
        if (newName != "")
        {
            ps.playerName = newName;
            panelComplete = true;
        }
        else
        {
            Debug.Log("Name cannot be blank");
            panelComplete = false;
        }
    }

    public void rollAbilityScores()
    {
        if (!panelComplete)
        {
            List<int> rolls = new List<int>();
            int abilityScore;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                    rolls.Add(Random.Range(1, 5));
                rolls.Sort();
                abilityScore = rolls[4] + rolls[5] + rolls[6];
                ps.abilityScores[i] = abilityScore;
                abilityScoreTxt.text += " " + abilityScore;
                rolls.Clear();
            }
            panelComplete = true;
        }
        else
            Debug.Log("Only 1 Roll Allowed");
    }

    public void raceSelected(int raceNum)
    {
        if (raceNum != 0)
        {
            raceNum--;
            raceDescription.text = gm.raceList[raceNum].raceSummary + "\nWalking Speed: " + gm.raceList[raceNum].raceSpeeds[0] + "ft\nRunning Speed: " + gm.raceList[raceNum].raceSpeeds[1] + "ft\nJump Height: " + gm.raceList[raceNum].raceSpeeds[2] + "ft";
            ps.playerRace = gm.raceList[raceNum].raceName;
            ps.playerSpeeds = gm.raceList[raceNum].raceSpeeds;
            panelComplete = true;
        }
        else
        {
            raceDescription.text = "Please Choose a Race!";
            panelComplete = false;
        }
    }

    public void classSelected(int classNum)
    {
        if (classNum != 0)
        {
            classNum--;
            classDescription.text = gm.classList[classNum].classSummary + "\nMain Stat: " + gm.classList[classNum].classMainStats + "\nHit Die: d" + gm.classList[classNum].hitDie;
            ps.playerClass = gm.classList[classNum].className;
            ps.maxHP = gm.classList[classNum].hitDie + 2; //since assuming all modifiers to be +2
            ps.currentHP = ps.maxHP;
            panelComplete = true;
        }
        else 
        {
            classDescription.text = "Please Choose a Class!";
            panelComplete = false;
        }
    }

    public void alignmentSelected(int alignmentNum)
    {
        if (alignmentNum != 0)
        {
            string newAlignment = "";
            switch (alignmentNum)
            {
                case 1:
                case 2:
                case 3:
                    newAlignment += "Lawful ";
                    break;
                case 4:
                case 5:
                case 6:
                    newAlignment += "Neutral ";
                    break;
                case 7:
                case 8:
                case 9:
                    newAlignment += "Chaotic ";
                    break;
            }
            switch (alignmentNum)
            {
                case 1:
                case 4:
                case 7:
                    newAlignment += "Good";
                    break;
                case 2:
                case 5:
                case 8:
                    newAlignment += "Neutral";
                    break;
                case 3:
                case 6:
                case 9:
                    newAlignment += "Evil";
                    break;
            }
            ps.alignment = newAlignment;
            panelComplete = true;
        }
        else
            panelComplete = false;
    }
}
