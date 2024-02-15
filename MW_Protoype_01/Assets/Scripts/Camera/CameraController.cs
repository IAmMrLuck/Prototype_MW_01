using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using ConaLuk;

public class CameraController : MonoBehaviour
{
    public float sensitivity = 1f; // Adjust this to control the sensitivity of camera movement

    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private DroneInputs droneInputs;

    private float cameraInput;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Change the tag according to your player's tag
    }

    private void Update()
    {
        cameraInput = droneInputs.CameraVert;


    }

    private void LateUpdate()
    {
        // Rotate the virtual camera based on input
        if (!Mathf.Approximately(cameraInput, 0f))
        {

            float rotationSpeed = sensitivity * Time.deltaTime;

            // Rotate around the player's position
            Vector3 cameraRotation = new Vector3(0, cameraInput, 0) * rotationSpeed;
            virtualCamera.transform.RotateAround(playerTransform.position, Vector3.up, cameraRotation.y);
            Debug.Log(message: "method called");

        }
    }
}
