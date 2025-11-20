using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] private Button helpButton;

    private void Awake()
    {
        if (helpButton != null)
            helpButton.onClick.AddListener(OnClickHelp);
    }

    private void OnClickHelp()
    {
        Application.OpenURL("https://disk.yandex.ru/i/9ZImFJTUBJf56Q");
    }
}
