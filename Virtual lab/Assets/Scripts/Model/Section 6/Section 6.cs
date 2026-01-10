using UnityEngine;

public class Section6 : MonoBehaviour
{
    [SerializeField] private GameObject section6;
    [SerializeField] private float minAngle = 0;
    [SerializeField] private float maxAngle = 360;
    [SerializeField] private Vector2 mouseTurn;
    [SerializeField] public float trueAngle;

    private void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {
            mouseTurn.x -= Input.GetAxis("Mouse X");
            mouseTurn.x = Mathf.Clamp(mouseTurn.x, minAngle, maxAngle);
            trueAngle = Mathf.Abs(mouseTurn.x - 360);
            section6.transform.localRotation = Quaternion.Euler(mouseTurn.x - 90, 90, -90);
        }
    }

    public void GlobalReset()
    {

    }
}
