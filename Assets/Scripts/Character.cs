using System.Collections.Generic;

public class Character
{
    public string CharacterID { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Speed { get; private set; }

    public List<Item> Inventory { get; private set; }

    public Character(string id, int level, int gold, int hp, int att, int def, int spd, List<Item> inven)
    {
        CharacterID = id;
        Level = level;
        Gold = gold;
        Health = hp;
        Attack = att;
        Defense = def;
        Speed = spd;
        Inventory = inven;
    }

    public void AddItem(Item item)
    {
        Inventory.Add(item);
    }

    public void Equip(Item item)
    {
        if (item.ItemData.type == AbilityType.Health) return;

        switch (item.ItemData.type)
        {
            case AbilityType.Attack:
                Attack += item.ItemData.amount;
                break;
            case AbilityType.Defense:
                Defense += item.ItemData.amount;
                break;
            case AbilityType.Speed:
                Speed += item.ItemData.amount;
                break;
        }

        item.EquipItem();
    }

    public void UnEquip(Item item)
    {
        if (item.IsEquipped == false) return;

        switch (item.ItemData.type)
        {
            case AbilityType.Attack:
                Attack -= item.ItemData.amount;
                break;
            case AbilityType.Defense:
                Defense -= item.ItemData.amount;
                break;
            case AbilityType.Speed:
                Speed -= item.ItemData.amount;
                break;
        }

        item.UnEquipItem();
    }
}
