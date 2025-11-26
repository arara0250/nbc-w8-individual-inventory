using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button exitButton;
    [SerializeField] private Button useButton;
    private TextMeshProUGUI useButtonText;

    [Header("Slot Settings")]
    [SerializeField] private UISlot slotPrefab;
    [SerializeField] private Transform slotParent;
    [SerializeField] private int slotCount;

    [Header("Item Info")]
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescText;

    private List<UISlot> slots = new List<UISlot>();
    private Item selectedItem;

    void Start()
    {
        exitButton.onClick.AddListener(CloseInventory);

        useButton.onClick.AddListener(OnClickUseButton);
        useButtonText = useButton.GetComponentInChildren<TextMeshProUGUI>();
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

        if (item.ItemData.itemType == ItemType.Consumable)
            useButtonText.text = "사용";
        else
            useButtonText.text = item.IsEquipped ? "해제" : "장착";
    }

    private void OnClickUseButton()
    {
        if (selectedItem == null) return;

        Character player = GameManager.Instance.Player;

        // 소비 아이템이면, 사용
        if (selectedItem.ItemData.itemType == ItemType.Consumable)
        {
            selectedItem.UseConsumable();

            if (selectedItem.Quantity <= 0)
            {
                player.Inventory.Remove(selectedItem);
                selectedItem = null;
            }
        }

        // 장비 아이템이면, 장착/해제
        else
        {
            if (selectedItem.IsEquipped)
                player.UnEquip(selectedItem);
            else
                player.Equip(selectedItem);
        }

        RefreshInventoryUI(player);

        HandleSlotClicked(selectedItem);
    }
}
