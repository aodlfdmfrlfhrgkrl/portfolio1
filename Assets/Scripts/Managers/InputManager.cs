using System;
using UnityEngine;

public class InputManager
{
    //Listener Pattern
    public Action KeyAction = null;

    public void OnUpdate()
    {
        if (Input.anyKey == false)
            return;

        if(KeyAction != null)
            KeyAction.Invoke();
    }
}