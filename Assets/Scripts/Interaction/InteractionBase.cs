using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionBase : MonoBehaviour
{
    public Camera mainCamera;
    Camera originCamera;
    [Space(10)]
    public float Range = 15f;
    [Space(10)]
    public LayerMask interactionMask;
    public IInteractable.eventData interactionConfig;

    RaycastHit _hit;
    private void Awake()
    {
        originCamera = mainCamera;
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);



            if (touch.phase == TouchPhase.Began) 
            {
                Ray raycast = mainCamera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(raycast, out RaycastHit hitObject, Range, interactionMask)) 
                {
                    _hit = hitObject;

                    if (hitObject.transform.gameObject.TryGetComponent(out IInteractable interactable)) 
                    {
                        interactable.Interact(interactionConfig);
                    }
                }
            }
        }
    }

    public void SetCurrentCamera(Camera newCamera) 
    {
        mainCamera = newCamera;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        if(_hit.transform != null)
            Gizmos.DrawLine(mainCamera.transform.position, _hit.transform.position);
    }
}
