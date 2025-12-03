using UnityEngine;
using UnityEngine.InputSystem;

public class GeneratorButton : MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject button;
    private bool isFirstClick = true;
    public bool generatorState = false;

    public void OnMouseDown()
    {
        if (isFirstClick)
        {
            Debug.Log("Генератор включен");
            indicator.GetComponent<Renderer>().material.color = Color.crimson;
            isFirstClick = false;
            generatorState = true;
        }
        else
        {
            Debug.Log("Генератор выключен");
            indicator.GetComponent<Renderer>().material.color = Color.black;
            isFirstClick = true;
            generatorState = false;
        }
    }
}
