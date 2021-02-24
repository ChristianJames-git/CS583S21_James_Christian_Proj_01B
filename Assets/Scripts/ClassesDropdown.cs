using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClassesDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdownClasses;
    public void Start()
    {
        dropdownClasses.onValueChanged.AddListener(delegate
        {
            GameManager.Instance.playerStats.setClass(dropdownClasses.options[dropdownClasses.value].text);
            Debug.Log(dropdownClasses.options[dropdownClasses.value].text);
        });
    }
}
