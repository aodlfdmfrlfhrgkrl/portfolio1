using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputManager
{
    //Listener Pattern
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    public void OnUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.anyKey == false)
            return;

        if(KeyAction != null)
            KeyAction.Invoke();
    }
}