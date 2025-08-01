using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Manager : MonoBehaviour
{
    static Manager _instance;
    static Manager Instance { get { Init(); return _instance; } }

    InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } }

    UIManager _ui = new UIManager();
    public static UIManager UI { get { return Instance._ui; } }
    ResourceManager _resource = new ResourceManager();
    public static ResourceManager Resource { get { return Instance._resource; } }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        _input.OnUpdate();
    }

    private static void Init()
    {
        if( _instance == null )
        {
            GameObject go = FindFirstObjectByType<Manager>().gameObject;

            if (go == null)
            {
                go = new GameObject { name = "@Manager" };
                go.AddComponent<Manager>();
            }
            DontDestroyOnLoad(go);
            _instance = go.GetComponent<Manager>();
        }
    }
    
}