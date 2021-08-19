using UnityEngine;

public class PlayerRotator : MonoBehaviour
{

    [SerializeField] private float mouseSensitivity = 150f;
    
    public Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        MouseLookSetup();
    }

    void Update()
    {
        MouseCalc();
    }

    void MouseLookSetup()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void MouseCalc()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
