using UnityEngine;
using UnityEngine.UI;

public class Preface : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private GameObject panel;
    private void Awake()
    {
        if (exitButton != null)
            exitButton.onClick.AddListener(OnClickExit);
    }
    private void OnClickExit()
    {
        Debug.Log("Кнопка Выхода из предисловия нажата");
        panel.SetActive(false);
    }
}
