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

    public void EquipItem()
    {
        IsEquipped = true;
    }

    public void UnEquipItem()
    {
        IsEquipped = false;
    }
}
