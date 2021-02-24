using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool rolledCharacter = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager - In start function.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPlayClicked()
    {
        if (rolledCharacter)
            Debug.Log("On Play Button Click");
        else
            Debug.Log("Roll Character First");
    }

    public void onRollCharacterClicked()
    {
        Debug.Log("On Roll Character Button Click");
        SceneManager.LoadScene("RollCharacterScene");
        rolledCharacter = true;
    }
    
    public void onQuitClicked()
    {
        // Add to onClick() for button. Choose this function
        Debug.Log("On Quit Button Click");
    }
}
