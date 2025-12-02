using UnityEngine;
using UnityEngine.InputSystem;

public class GeneratorButton : MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject button;
    private bool isFirstClick = true;
    public bool generatorState = false;

    private void Awake()
    {
        indicator.GetComponent<Renderer>().material.color = Color.crimson;
    }

    public void OnMouseDown()
    {
        if (isFirstClick)
        {
            Debug.Log("Генератор включен");
            indicator.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Индикатор загорелся зеленым");
            isFirstClick = false;
            generatorState = true;
        }
        else
        {
            Debug.Log("Генератор выключен");
            indicator.GetComponent<Renderer>().material.color = Color.crimson;
            Debug.Log("Индикатор загорелся красным");
            isFirstClick = true;
            generatorState = false;
        }
    }
}
