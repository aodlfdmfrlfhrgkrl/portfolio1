using UnityEngine;

public class InventoryUI : SceneUI
{
    enum UIObject
    {
        GridPanel
    }

    public override void Init()
    {
        base.Init();

        Bind<GameObject>(typeof(UIObject));

        GameObject gridPanel = Get<GameObject>((int)UIObject.GridPanel);
        foreach (Transform child in gridPanel.transform)
            Manager.Resource.Destroy(child.gameObject);

        for (int i = 0; i < 8; i++)
        {
            GameObject item = Manager.UI.MakeSubItem<InventoryItemUI>(gridPanel.transform).gameObject;
            InventoryItemUI invenItem = item.GetOrAddComponent<InventoryItemUI>();
            invenItem.SetInfo($"집행검{i}번");
        }
    }
    }