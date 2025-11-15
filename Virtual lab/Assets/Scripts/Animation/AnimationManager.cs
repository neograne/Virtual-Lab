using UnityEngine;
using UnityEngine.UI;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
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
        animator.SetTrigger("ButtonClicked1");
    }
    private void OnClickOptions()
    {
        animator.SetTrigger("ButtonClicked2");
    }
}
