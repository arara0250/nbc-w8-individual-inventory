using UnityEngine;

public class Item
{
    /// <summary>
    /// 아이템 동적 데이터 (아이템 객체별? 런타임에 변할 수 있는 정보들)
    /// </summary>
    public ItemData ItemData { get; private set; }
    public int Quantity { get; private set; }
    public bool IsEquipped { get; private set; }

    public Item(ItemData data, int qty=1)
    {
        ItemData = data;
        Quantity = qty;
        IsEquipped = false;
    }

    public void AddQuantity(int qty)
    {
        Quantity += qty;
    }

    private void RemoveQuantity(int qty=1)
    {
        Quantity = Mathf.Max(0, Quantity - qty);
    }

    public void EquipItem()
    {
        IsEquipped = true;
    }

    public void UnEquipItem()
    {
        IsEquipped = false;
    }

    public void UseConsumable()
    {
        if (ItemData.itemType == ItemType.Equipment) return;

        Character player = GameManager.Instance.Player;

        switch (ItemData.consumeType)
        {
            case ConsumableType.Health:
                player.Heal(ItemData.amount);
                break;
            case ConsumableType.Experience:
                player.EarnExp(ItemData.amount);
                break;
        }

        RemoveQuantity();
    }
}
