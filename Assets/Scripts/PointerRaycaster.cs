using UnityEngine;
using UnityEngine.InputSystem;

public class PointerRaycaster : MonoBehaviour
{
    [SerializeField] private Camera arCamera;
    [SerializeField] private LayerMask interactableLayers = ~0;
    [SerializeField] private float maxDistance = 100f;

    private void Update()
    {
        Pointer pointer = Pointer.current;

        if (pointer == null || !pointer.press.wasPressedThisFrame)
            return;

        Vector2 screenPosition = pointer.position.ReadValue();
        Ray ray = arCamera.ScreenPointToRay(screenPosition);

        if (!Physics.Raycast(ray, out RaycastHit hit, maxDistance, interactableLayers))
            return;

        ARInteractable interactable =
            hit.collider.GetComponentInParent<ARInteractable>();

        if (interactable != null)
            interactable.Activate();
    }
}