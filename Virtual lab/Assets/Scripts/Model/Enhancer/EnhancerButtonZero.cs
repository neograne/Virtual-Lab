using UnityEngine;

public class EnhancerButtonZero : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private bool isFirstClick = true;

    public void OnMouseDown()
    {
        if (isFirstClick)
        {
            Debug.Log("Режим установки нуля включен");
            isFirstClick = false;
            button.transform.localRotation = Quaternion.Euler(0, 0, -45);
        }
        else
        {
            Debug.Log("Режим установки нуля выключен");
            isFirstClick = true;
            button.transform.localRotation = Quaternion.Euler(0, 0, 45);
        }
    }

    public void GlobalReset()
    {
        isFirstClick = true;
        button.transform.localRotation = Quaternion.Euler(0, 0, 45);
    }
}
