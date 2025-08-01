using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 0;

    Stack<PopupUI> _popupStack = new Stack<PopupUI>();

    public T ShowPopupUI<T>(string name = null) where T : PopupUI
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Popup/{name}");
        
        T popup = Utility.GetOrAddComponent<T>(go);
        _popupStack.Push(popup);
        return null;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        PopupUI popup = _popupStack.Pop();
        Manager.Resource.Destroy(popup.gameObject);
    }
}