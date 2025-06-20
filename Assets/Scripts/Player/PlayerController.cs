using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [Space(10)]
    public LayerMask defaultMask;
    public LayerMask focusedMask;
    [Space(10)]
    public InteractionBase interaction;
    public Camera OriginCamera;

    Camera _lastCamera;
    public enum State 
    {
        Global,
        Focused
    }

    public State state;
    
    //DEBUG PURPOSE ONLY :)
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            UnfocusPlayer();
        }
    }

    void Awake()
    {
        Instance = this;
    }

    public void FocusPlayer(Camera newCamera) 
    {
        OriginCamera.enabled = false;
        newCamera.enabled = true;
        SetState(State.Focused);
        _lastCamera = newCamera;
        interaction.SetCurrentCamera(newCamera);
        interaction.interactionMask = focusedMask;
    }

    public void UnfocusPlayer() 
    {
        if (state == State.Focused) 
        {
            OriginCamera.enabled = true;
            _lastCamera.enabled = false;
            interaction.interactionMask = defaultMask;
            interaction.SetCurrentCamera(OriginCamera);
            SetState(State.Global);
        }
    }

    void SetState(State newState) 
    {
        state = newState;
    }
}
