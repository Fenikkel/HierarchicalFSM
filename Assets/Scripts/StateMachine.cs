using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    BaseState _CurrentState;

    void Start()
    {
        _CurrentState = GetInitialState();

        if (_CurrentState != null) 
        {
            _CurrentState.Enter();
        }
    }


    void Update()
    {
        if (_CurrentState != null)
        {
            _CurrentState.UpdateLogic();
        }
    }

    private void LateUpdate() // FixedUpdate()  // Usamos LateUpdate para mantener la StateMachine dentro de el Game Logic (https://docs.unity3d.com/Manual/ExecutionOrder.html)
    {
        if (_CurrentState != null)
        {
            _CurrentState.UpdatePhysics();
        }
    }

    public void ChangeState(BaseState newState) 
    {
        _CurrentState.Exit(); //Salimos del estado actual
        _CurrentState = newState; //Asignamos el nuevo estado
        _CurrentState.Enter(); //Entramos al nuevo estado
    }

    protected virtual BaseState GetInitialState() 
    {
        return null;
    }

    private void OnGUI()
    {
        string content;

        if (_CurrentState != null)
        {
            content = _CurrentState.m_StateName;
        }
        else 
        {
            content = "(no current state)";
        }

        GUILayout.Label($"<color='black'><size=40>{content}</size></color>"); //No spaces allowed in tags
    }
}
