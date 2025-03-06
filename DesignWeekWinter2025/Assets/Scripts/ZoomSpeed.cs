using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Header("Camera Settings")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float minFOV = 60f;
    [SerializeField] private float maxFOV = 90f;
    [SerializeField] private float zoomSpeed = 2f;
    [SerializeField] private float maxSpeedForZoom = 50f;

    [Header("Player Settings")]
    [SerializeField] private Rigidbody playerRigidbody;

    private float currentFOV;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
        if (playerRigidbody == null)
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        currentFOV = playerCamera.fieldOfView;
    }

    void Update()
    {
        float currentSpeed = playerRigidbody.velocity.magnitude;
        float normalizedSpeed = Mathf.InverseLerp(0, maxSpeedForZoom, currentSpeed);
        float targetFOV = Mathf.Lerp(minFOV, maxFOV, normalizedSpeed);

        currentFOV = Mathf.Lerp(currentFOV, targetFOV, Time.deltaTime * zoomSpeed);
        playerCamera.fieldOfView = currentFOV;
    }
}
