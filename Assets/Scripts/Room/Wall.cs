using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Vector3 direction;

    MeshRenderer meshRenderer;
    CameraWallsChecker checker;

    public bool HideCollider = false;

    Collider _collider;

    

    public float value;

    private void Start()
    {
        checker = CameraWallsChecker.instance;
        meshRenderer = GetComponent<MeshRenderer>();
        if(HideCollider)
            _collider = GetComponent<Collider>();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, direction.normalized * 0.2f);
        Gizmos.DrawSphere(transform.position, 0.05f);
    }

    private void Update()
    {
        value = Vector3.Dot(checker.direction, direction);

        if (value > 0.75f) 
        {
            meshRenderer.enabled = false;
        }
        else 
        {
            meshRenderer.enabled = true;
        }

        if (HideCollider) 
        {
            if (value > 0.75f)
            {
                _collider.enabled = false;
            }
            else
            {
                _collider.enabled = true;
            }
        }
        
    }
}


