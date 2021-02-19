using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("GameManager - In start function.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onExitClicked()
    {
        // Add to onClick() for button. Choose this function
        Debug.Log("On Exit Button Click");
    }
}
