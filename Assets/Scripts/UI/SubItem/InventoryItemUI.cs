using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItemUI : UI
{
    enum ItemObject
    {
        ItemIcon,
        ItemNameText
    }

    string _name;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        Bind<GameObject>(typeof(ItemObject));
        
        Get<GameObject>((int)ItemObject.ItemNameText).GetComponent<Text>().text = _name;
        Get<GameObject>((int)ItemObject.ItemIcon).BindEvent((PointerEventData) => Debug.Log(_name));

    }
    public void SetInfo(string name)
    {
        _name = name;
    }
}