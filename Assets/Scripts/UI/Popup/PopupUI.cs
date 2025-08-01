using UnityEngine;

public class PopupUI : UI
{
    public override void Init()
    {
        Manager.UI.SetCanvas(gameObject, true);
    }

    public virtual void ClosePopupUI()
    {
        Manager.UI.ClosePopupUI(this);
    }
}