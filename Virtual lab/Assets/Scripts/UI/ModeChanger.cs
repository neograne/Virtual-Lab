using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown modeDropDown;
    [SerializeField] private GlobalReset globalReset;
    [SerializeField] private GameObject section1;
    [SerializeField] private GameObject section2;

    public string currentMode = "Одноволновой";

    private void Awake()
    {
        if (modeDropDown != null)
            modeDropDown.onValueChanged.AddListener(OnSetMode); 
    }

    private void Start()
    {
        modeDropDown.ClearOptions();
        List<string> modes = new List<string>() { "Одноволновой", "Двухволновой" };
        modeDropDown.AddOptions(modes);
    }

    private void OnSetMode(int modeIndex)
    {
        if (modeIndex == 0)
        {
            Debug.Log("Текущий режим Одноволновой");
            currentMode = "Одноволновой";
            section1.SetActive(true);
            section2.SetActive(false);
            globalReset.ResetStation();
        }
        else if (modeIndex == 1)
        {
            Debug.Log("Текущий режим Двухволновой");
            currentMode = "Двухволновой";
            section1.SetActive(false);
            section2.SetActive(true);
            globalReset.ResetStation();
        }
    }
}
