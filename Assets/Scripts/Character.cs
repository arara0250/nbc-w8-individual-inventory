using System.Collections.Generic;

public class Character
{
    public string CharacterID { get; private set; }
    public int Level { get; private set; }
    public int Experience { get; private set; }
    public int RequiredExp { get; private set; }
    public int Gold { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Speed { get; private set; }

    public List<Item> Inventory { get; private set; }

    public List<Item> EquippedItems { get; private set; }

    public Character(string id, int level, int gold, int hp, int att, int def, int spd, List<Item> inven)
    {
        CharacterID = id;
        Level = level;
        Experience = 0;
        RequiredExp = level * 100;
        Gold = gold;
        Health = hp;
        Attack = att;
        Defense = def;
        Speed = spd;
        Inventory = inven;
        EquippedItems = new List<Item>();
    }

    private void LevelUp()
    {
        if (Experience < RequiredExp) return;

        Experience -= RequiredExp;
        Level++;
        RequiredExp = Level * 100;
    }

    public void Heal(int amount)
    {
        Health += amount;
    }

    public void EarnExp(int amount)
    {
        Experience += amount;
        LevelUp();
        UIManager.Instance.UIMainMenu.SetLevelInfo(this);
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void Equip(Item item)
    {
        if (item.ItemData.itemType == ItemType.Consumable) return;

        switch (item.ItemData.equipType)
        {
            case EquipmentType.Attack:
                Attack += item.ItemData.amount;
                break;
            case EquipmentType.Defense:
                Defense += item.ItemData.amount;
                break;
            case EquipmentType.Speed:
                Speed += item.ItemData.amount;
                break;
        }

        item.EquipItem();
        EquippedItems.Add(item);
    }

    public void UnEquip(Item item)
    {
        if (item.IsEquipped == false) return;

        switch (item.ItemData.equipType)
        {
            case EquipmentType.Attack:
                Attack -= item.ItemData.amount;
                break;
            case EquipmentType.Defense:
                Defense -= item.ItemData.amount;
                break;
            case EquipmentType.Speed:
                Speed -= item.ItemData.amount;
                break;
        }

        item.UnEquipItem();
        EquippedItems.Remove(item);
    }
}
