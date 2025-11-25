using UnityEngine;

/// <summary>
/// 아이템 정적 데이터 (런타임에 변하지 않는 정보들)
/// </summary>
public enum AbilityType
{
    Health,
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
    public bool canStack; 

    [Header("Ability Info")]
    public AbilityType type;
    public int amount;
}
