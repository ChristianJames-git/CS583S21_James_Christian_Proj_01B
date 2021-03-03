using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlaySceneManager : MonoBehaviour
{

    public TMP_InputField outputJSON;
    // Start is called before the first frame update
    void Start()
    {
        outputJSON.text = JsonUtility.ToJson(GameManager.Instance.playerStats, true);
    }

    public void onBack()
    {
        SceneManager.LoadScene("MainScene");
    }
}
