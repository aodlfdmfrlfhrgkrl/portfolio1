using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Scene : MonoBehaviour
{
    public Define.Scene SceneType
    {
        get;
        protected set;
    }
    = Define.Scene.UnKnown;

    protected virtual void Init()
    {
        Object obj = Object.FindAnyObjectByType(typeof(EventSystem));
        if (obj == null)
            Manager.Resource.Instantiate("UI/EventSystem").name = "@EventSystem";
    }

    public abstract void Clear();
}