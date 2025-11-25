using UnityEngine;

public class Character
{
    public string CharacterID { get; private set; }
    public int Level { get; private set; }
    public int Gold { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }
    public int Defense { get; private set; }
    public int Speed { get; private set; }

    public Character(string id, int level, int gold, int hp, int att, int def, int spd)
    {
        CharacterID = id;
        Level = level;
        Gold = gold;
        Health = hp;
        Attack = att;
        Defense = def;
        Speed = spd;
    }
}
