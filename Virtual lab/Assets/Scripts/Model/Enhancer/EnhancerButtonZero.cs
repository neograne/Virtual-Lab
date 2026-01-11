using UnityEngine;

public class EnhancerButtonZero : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private bool isFirstClick = true;
    public bool enhancerZeroState = false;

    public void OnMouseDown()
    {
        if (isFirstClick)
        {
            Debug.Log("Режим установки нуля включен");
            isFirstClick = false;
            enhancerZeroState = true;
            button.transform.localRotation = Quaternion.Euler(0, 0, -45);
        }
        else
        {
            Debug.Log("Режим установки нуля выключен");
            isFirstClick = true;
            enhancerZeroState = false;
            button.transform.localRotation = Quaternion.Euler(0, 0, 45);
        }
    }

    public void GlobalReset()
    {
        isFirstClick = true;
        enhancerZeroState = false;
        button.transform.localRotation = Quaternion.Euler(0, 0, 45);
    }
}
