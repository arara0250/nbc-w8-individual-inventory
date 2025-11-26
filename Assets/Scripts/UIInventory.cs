using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private int slotCount;

    private List<UISlot> slots = new List<UISlot>();
    private ItemData selectedItem;

    void Start()
    {
        exitButton.onClick.AddListener(CloseInventory);
    }

    private void CloseInventory()
    {
        UIManager.Instance.UIMainMenu.OpenMainMenu();
    }

    public void InitInventoryUI()
    {
        for (int i = 0; i < slotCount; i++)
        {
            UISlot slot = Instantiate(slotPrefab, slotParent);
            slot.SetIndex(i);
            slots.Add(slot);
        }
    }

    public void RefreshInventoryUI(Character Player)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < Player.Inventory.Count)
                slots[i].SetItem(Player.Inventory[i]);
            else
                slots[i].SetItem(null);
        }
    }
}
