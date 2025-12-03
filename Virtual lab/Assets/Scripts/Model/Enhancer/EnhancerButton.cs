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
        }
        else
        {
            Debug.Log("Усилитель выключен");
            indicator.GetComponent<Renderer>().material.color = Color.black;
            isFirstClick = true;
            enhancerState = false;
        }
    }
}
