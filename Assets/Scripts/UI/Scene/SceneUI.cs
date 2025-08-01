using UnityEngine;

public class SceneUI : UI
{
    public override void Init()
    {
        Manager.UI.SetCanvas(gameObject, false);
    }
}