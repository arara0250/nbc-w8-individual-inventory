using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private int slotCount;

    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescText;

    private List<UISlot> slots = new List<UISlot>();
    private Item selectedItem;

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
            slot.OnSlotClicked += HandleSlotClicked;
            slots.Add(slot);
        }
    }

    private void HandleSlotClicked(Item item)
    {
        if (item == null)
        {             
            itemNameText.text = "";
            itemDescText.text = "";
            return;
        }

        selectedItem = item;
        itemNameText.text = item.ItemData.itemName;
        itemDescText.text = item.ItemData.itemDescription;
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

        itemNameText.text = "";
        itemDescText.text = "";
    }
}
