using UnityEngine;

using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;

public class TogglePassthrough : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty toggleAction;

    private ARCameraManager arCameraManager;

    private void Awake()
    {
        toggleAction.action.Enable();
        arCameraManager = (ARCameraManager)FindObjectOfType(typeof(ARCameraManager));
    }

    private void OnEnable() => toggleAction.action.performed += OnTogglePerformed;

    private void OnDisable() => toggleAction.action.performed -= OnTogglePerformed;

    private void OnTogglePerformed(InputAction.CallbackContext obj)
    {
        if (arCameraManager)
            arCameraManager.enabled = !arCameraManager.enabled;
    }
}
