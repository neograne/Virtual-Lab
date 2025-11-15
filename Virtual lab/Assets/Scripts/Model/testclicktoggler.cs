using UnityEngine;

public class testclicktoggler : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("Toggler нажат");
        GetComponent<Renderer>().material.color = Color.red;
    }
}
