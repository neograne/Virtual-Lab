using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown modeDropDown;
    [SerializeField] private GlobalReset globalReset;
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
            globalReset.ResetStation();
        }
        else if (modeIndex == 1)
        {
            Debug.Log("Текущий режим Двухволновой");
            globalReset.ResetStation();
        }
    }
}
