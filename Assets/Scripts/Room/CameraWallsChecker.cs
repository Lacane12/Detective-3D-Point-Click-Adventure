
using UnityEngine;

public class CameraWallsChecker : MonoBehaviour
{
    
    public static CameraWallsChecker instance;
    public InteractionBase interaction;

    [HideInInspector]
    public Vector3 direction;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        direction = new(interaction.mainCamera.transform.forward.x, 0f, interaction.mainCamera.transform.forward.z);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(interaction != null)
         Gizmos.DrawRay(interaction.mainCamera.transform.position, new(direction.x, direction.y, direction.z));
    }
}
