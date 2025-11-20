using UnityEngine;
using UnityEngine.InputSystem;

public class Lever : MonoBehaviour
{
    [SerializeField] private GameObject indicator;
    [SerializeField] private GameObject lever;
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
            Debug.Log("Рычаг нажат");
            lever.transform.rotation = Quaternion.Euler(-45, 0, 0);
            indicator.GetComponent<Renderer>().material.color = Color.green;
            Debug.Log("Индикатор загорелся зеленым");
            isFirstClick = false;
            generatorState = true;
        }
        else
        {
            Debug.Log("Рычаг нажат");
            lever.transform.rotation = Quaternion.Euler(-135, 0, 0);
            indicator.GetComponent<Renderer>().material.color = Color.crimson;
            Debug.Log("Индикатор загорелся красным");
            isFirstClick = true;
            generatorState = false;
        }
    }
}
