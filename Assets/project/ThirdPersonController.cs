using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float cameraDistance = 5f;
    public float cameraHeight = 2f;
    public Transform cameraTransform;

    private float cameraYaw;
    private float cameraPitch = 15f;

    void Update()
    {
        Vector2 moveInput = Vector2.zero;

        if (Keyboard.current != null)
        {
            moveInput.x = (Keyboard.current.dKey.isPressed ? 1f : 0f) -
                          (Keyboard.current.aKey.isPressed ? 1f : 0f);

            moveInput.y = (Keyboard.current.wKey.isPressed ? 1f : 0f) -
                          (Keyboard.current.sKey.isPressed ? 1f : 0f);
        }

        if (Mouse.current != null)
        {
            Vector2 mouseDelta = Mouse.current.delta.ReadValue();

            cameraYaw += mouseDelta.x * mouseSensitivity;
            cameraPitch -= mouseDelta.y * mouseSensitivity;
            cameraPitch = Mathf.Clamp(cameraPitch, -30f, 70f);
        }

        Vector3 forward = Quaternion.Euler(0f, cameraYaw, 0f) * Vector3.forward;
        Vector3 right = Quaternion.Euler(0f, cameraYaw, 0f) * Vector3.right;

        Vector3 moveDirection = (forward * moveInput.y + right * moveInput.x).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;

            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                10f * Time.deltaTime
            );
        }
    }

    void LateUpdate()
    {
        Quaternion rotation = Quaternion.Euler(cameraPitch, cameraYaw, 0f);

        Vector3 targetPosition = transform.position + Vector3.up * cameraHeight;
        cameraTransform.position = targetPosition - rotation * Vector3.forward * cameraDistance;
        cameraTransform.rotation = rotation;
    }
}



