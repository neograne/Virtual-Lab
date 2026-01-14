using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown modeDropDown;
    [SerializeField] private GlobalReset globalReset;
    [SerializeField] private GameObject section1;
    [SerializeField] private GameObject section2;
    [SerializeField] private GameObject wire1;
    [SerializeField] private GameObject wire2;
    [SerializeField] private GameObject thing1;
    [SerializeField] private GameObject thing2;

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
            wire1.SetActive(true);
            wire2.SetActive(false);
            thing1.SetActive(true);
            thing2.SetActive(false);
            globalReset.ResetStation();
        }
        else if (modeIndex == 1)
        {
            Debug.Log("Текущий режим Двухволновой");
            currentMode = "Двухволновой";
            section1.SetActive(false);
            section2.SetActive(true);
            wire1.SetActive(false);
            wire2.SetActive(true);
            thing1.SetActive(false);
            thing2.SetActive(true);
            globalReset.ResetStation();
        }
    }
}
