using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 전체 아이템 데이터베이스
/// </summary>

[CreateAssetMenu(menuName = "New ItemDatabase")]
public class ItemDatabase : ScriptableObject
{
    
    [SerializeField] private List<ItemData> allItems;     // Inspector 에서 ItemData 들 연결

    private Dictionary<string, ItemData> itemDict;

    public void Init()
    {
        itemDict = new Dictionary<string, ItemData>();

        foreach (ItemData item in allItems)
            itemDict[item.itemName] = item;
    }

    public ItemData GetItemData(string itemName)
    {
        // null 방지
        if (itemDict == null)
            Init();

        if (itemDict.ContainsKey(itemName))
            return itemDict[itemName];
        
        else
            return null;
    }
}
