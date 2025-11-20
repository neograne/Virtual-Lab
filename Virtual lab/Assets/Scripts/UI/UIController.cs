using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button helpButton;
    [SerializeField] private Button optionsButton;

    private void Awake()
    {
        if (helpButton != null)
            helpButton.onClick.AddListener(OnClickHelp);
        if (optionsButton != null)
            optionsButton.onClick.AddListener(OnClickOptions);
    }

    private void OnClickHelp()
    {
        Debug.Log("Кнопка Помощь нажата");
    }
    private void OnClickOptions()
    {
        Debug.Log("Кнопка Настройки нажата");
    }
}
