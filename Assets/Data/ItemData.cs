using UnityEngine;

/// <summary>
/// 아이템 정적 데이터 (런타임에 변하지 않는 정보들)
/// </summary>

public enum ItemType
{
    Consumable,
    Equipment
}

public enum ConsumableType
{
    None,
    Health,
    Experience
}

public enum EquipmentType
{
    None,
    Attack,
    Defense,
    Speed
}

[CreateAssetMenu(fileName = "ItemData_", menuName ="New ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Display Info")]
    public string itemName;
    public string itemDescription;
    public Sprite itemIcon;
     
    [Header("Item Info")]
    public ItemType itemType;
    public bool canStack;

    [Header("Consumable")]
    public ConsumableType consumeType;
    public int amount;

    [Header("Equipment")]
    public EquipmentType equipType;
    public int stat;
}
