using UnityEngine;

public class GameScene : Scene
{
    private void Start()
    {
        Init();
    }

    protected override void Init()
    {
        base.Init();
        SceneType = Define.Scene.Game;
    }

    public override void Clear()
    {
        
    }
}
