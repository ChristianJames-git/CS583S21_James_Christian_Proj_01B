using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CharacterSceneManager : MonoBehaviour
{
    public List<GameObject> inputPanels;
    public GameObject characterNamePanel;
    public GameObject abilitiesPanel;
    public GameObject racesPanel;
    public GameObject classesPanel;
    public GameObject alignmentPanel;
    private int currentPanel;
    private bool panelComplete;
    public TMP_Text abilityScoreTxt;
    public TMP_Text raceDescription;
    public TMP_Text classDescription;
    public void Start()
    {
        inputPanels.Add(characterNamePanel);
        inputPanels.Add(abilitiesPanel);
        inputPanels.Add(racesPanel);
        inputPanels.Add(classesPanel);
        inputPanels.Add(alignmentPanel);
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
        if (index < inputPanels.Count)
        {
            if (index > 0)
                inputPanels[index - 1].SetActive(false);
            inputPanels[index].SetActive(true);
            panelComplete = false;
            currentPanel = index;
        }
        else
        {
            Debug.Log("Return to Main Menu");
            GameManager.Instance.rolledCharacter = true;
            SceneManager.LoadScene("MainScene");
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
        if (newName != "")
        {
            GameManager.Instance.playerStats.changeName(newName);
            panelComplete = true;
        }
        else
            Debug.Log("Name cannot be blank");
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
                GameManager.Instance.playerStats.abilityScores[i] = abilityScore;
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
            raceDescription.text = GameManager.Instance.raceList[raceNum].raceSummary + "\nWalking Speed: " + GameManager.Instance.raceList[raceNum].raceSpeeds[0] + "ft\nRunning Speed: " + GameManager.Instance.raceList[raceNum].raceSpeeds[1] + "ft\nJump Height: " + GameManager.Instance.raceList[raceNum].raceSpeeds[0] + "ft";
            GameManager.Instance.playerStats.playerRace = GameManager.Instance.raceList[raceNum].raceName;
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
            classDescription.text = GameManager.Instance.classList[classNum].classSummary + "\nMain Stat: " + GameManager.Instance.classList[classNum].classMainStats;
            GameManager.Instance.playerStats.playerClass = GameManager.Instance.classList[classNum].className;
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
            GameManager.Instance.playerStats.alignment = newAlignment;
            panelComplete = true;
        }
        else
        {
            panelComplete = false;
        }
    }
}
