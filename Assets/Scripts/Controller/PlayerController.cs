using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void Start()
    {
        //Avoid redundancy
        Manager.Input.KeyAction -= OnKeyAction;
        Manager.Input.KeyAction += OnKeyAction;
    }
    public void OnKeyAction()
    {

    }
}
