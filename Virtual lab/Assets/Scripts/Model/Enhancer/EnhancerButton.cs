using UnityEngine;

public class EnhancerButton: MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject button;
    private bool isFirstClick = true;
    public bool enhancerState = false;

    public void OnMouseDown()
    {
        if (isFirstClick)
        {
            Debug.Log("Усилитель включен");
            indicator.GetComponent<Renderer>().material.color = Color.crimson;
            isFirstClick = false;
            enhancerState = true;
            button.transform.localRotation = Quaternion.Euler(0, 0, -45);
        }
        else
        {
            Debug.Log("Усилитель выключен");
            indicator.GetComponent<Renderer>().material.color = Color.black;
            isFirstClick = true;
            enhancerState = false;
            button.transform.localRotation = Quaternion.Euler(0, 0, 45);
        }
    }

    public void GlobalReset()
    {
        isFirstClick = true;
        enhancerState = false;
        indicator.GetComponent<Renderer>().material.color = Color.black;
        button.transform.localRotation = Quaternion.Euler(0, 0, 45);
    }
}
