using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);

        Instance = this;
    }

    public Character Player { get; private set; }

    [SerializeField] private ItemDatabase itemDB;
    public ItemDatabase ItemDB => itemDB;   

    private void Start()
    {
        SetData();
    }

    void SetData()
    {
        ItemDB.Init();

        List<Item> initInven = new List<Item>() 
        { 
            new Item(ItemDB.GetItemData("초보자의 검")),
            new Item(ItemDB.GetItemData("HP 포션"), 3)
        };

        Player = new Character
        (
            id: "arara",
            level: 1,
            gold: 500,
            hp: 100,
            att: 10,
            def: 7,
            spd: 5,
            inven: initInven
        );

        UIManager.Instance.UIMainMenu.SetCharacterInfo(Player);
        UIManager.Instance.UIStatus.SetStatusInfo(Player);
    }
}
