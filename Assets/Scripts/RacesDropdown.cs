using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RacesDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdownClasses;
    public void Start()
    {
        dropdownClasses.onValueChanged.AddListener(delegate
        {
            GameManager.Instance.playerStats.setRace(dropdownClasses.options[dropdownClasses.value].text);
        });
    }
}
