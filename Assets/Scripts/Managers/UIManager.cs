using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    int _order = 10;

    private GameObject _root;
    public GameObject Root
    {
        get
        {
            if (_root == null)
                _root = new GameObject { name = "RootUI" };

            return _root;
        }
    }

    Stack<PopupUI> _popupStack = new Stack<PopupUI>();

    public void SetCanvas(GameObject go, bool sort = true)
    {
        Canvas canvas = Utility.GetOrAddComponent<Canvas>(go);
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvas.overrideSorting = true;

        if (sort)
        {
            canvas.sortingOrder = _order;
            _order++;
        }
        else
        {
            canvas.sortingOrder = 0;
        }

    }

    public T MakeSubItem<T>(Transform parent = null, string name = null) where T : UI
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Subitem/{name}");

        if(parent != null)
            go.transform.SetParent(parent);

        return Utility.GetOrAddComponent<T>(go);
    }

    public T ShowPopupUI<T>(string name = null) where T : PopupUI
    {
        if(string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Popup/{name}");


        go.transform.SetParent(Root.transform);

        T popupUI = Utility.GetOrAddComponent<T>(go);
        _popupStack.Push(popupUI);

        return popupUI;
    }

    public T ShowScenepUI<T>(string name = null) where T : SceneUI
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject go = Manager.Resource.Instantiate($"UI/Scene/{name}");

        go.transform.SetParent(Root.transform);
        T sceneUI = Utility.GetOrAddComponent<T>(go);

        return sceneUI;
    }

    public void ClosePopupUI()
    {
        if (_popupStack.Count == 0)
            return;

        PopupUI popup = _popupStack.Pop();
        Manager.Resource.Destroy(popup.gameObject);
    }

    public void ClosePopupUI(PopupUI popup)
    {
        if (_popupStack.Count == 0)
            return;

        if (_popupStack.Peek() != popup)
            return;

        ClosePopupUI();
    }


    public void CloseAllPopupUI()
    {
        while (_popupStack.Count > 0)
        {
            ClosePopupUI();
        }
    }
}