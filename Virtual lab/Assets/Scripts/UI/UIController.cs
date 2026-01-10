using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button allButton;
    [SerializeField] private Button helpButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button modeButton;
    [SerializeField] private Button exitButton;
    private void Awake()
    {
        if (allButton != null)
            allButton.onClick.AddListener(OnClickAll);

        if (helpButton != null)
            helpButton.onClick.AddListener(OnClickHelp);

        if (optionsButton != null)
            optionsButton.onClick.AddListener(OnClickOptions);

        if (modeButton != null)
            modeButton.onClick.AddListener(OnClickMode);

        if (exitButton != null)
            exitButton.onClick.AddListener(OnClickExit);
    }
    private void OnClickAll()
    {
        Debug.Log("Кнопка Все нажата");
    }

    private void OnClickHelp()
    {
        Debug.Log("Кнопка Помощь нажата");
    }

    private void OnClickOptions()
    {
        Debug.Log("Кнопка Настройки нажата");
    }

    private void OnClickMode()
    {
        Debug.Log("Кнопка Режима установки нажата");
    }
    private void OnClickExit()
    {
        Debug.Log("Кнопка Выхода нажата");
        Application.Quit();
    }
}
