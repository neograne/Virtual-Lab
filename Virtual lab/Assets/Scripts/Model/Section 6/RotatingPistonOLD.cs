using UnityEngine;

public class RotatingPistonOLD : MonoBehaviour
{
    [Header("Объекты")]
    [SerializeField] private GameObject rotatingPiston;
    [Header("Углы")]
    [SerializeField] private float maxAngle = 360f;
    [SerializeField] private float minAngle = 0f;
    [Header("Позиции")]
    [SerializeField] private float minPosition = -0.7f;
    [SerializeField] private float maxPosition = -1.7f;
    [Header("DEBUG")]
    [SerializeField] private Vector2 mouseTurn;
    [SerializeField] private float pos;
    [SerializeField] private float rotatingSpeed = 200f;



    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            mouseTurn.x -= Input.GetAxis("Mouse X");
            pos += mouseTurn.x;
            pos = Mathf.Clamp(pos, minPosition, maxPosition);
            mouseTurn.x = Mathf.Clamp(mouseTurn.x, minAngle, maxAngle);
            rotatingPiston.transform.localRotation = Quaternion.Euler(0, mouseTurn.x * rotatingSpeed * Time.timeScale, 0);
            rotatingPiston.transform.localPosition = new Vector3(0, pos, 0);
        }
    }

    public void GlobalReset()
    {
        mouseTurn.x = 0;
        rotatingPiston.transform.localPosition = new Vector3(0, -0.7f, 0);
        rotatingPiston.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
