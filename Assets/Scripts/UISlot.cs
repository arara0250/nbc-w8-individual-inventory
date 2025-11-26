using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI equipText;
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Button slotButton;

    private int slotIndex;
    private Item currentItem;

    public event Action<Item> OnSlotClicked;

    private void Start()
    {
        slotButton.onClick.AddListener(() => OnSlotClicked?.Invoke(currentItem));
    }

    public void SetIndex(int index)
    {
        slotIndex = index;
    }

    public void SetItem(Item item)
    {
        currentItem = item;
        UpdateSlotUI();
    }

    void UpdateSlotUI()
    {
        if (currentItem == null)
        {
            itemIcon.gameObject.SetActive(false);
            equipText.gameObject.SetActive(false);
            quantityText.gameObject.SetActive(false);
        }
        else
        {
            itemIcon.gameObject.SetActive(true);
            itemIcon.sprite = currentItem.ItemData.itemIcon;

            if (currentItem.IsEquipped)
                equipText.gameObject.SetActive(true);
            else
                equipText.gameObject.SetActive(false);

            if (currentItem.ItemData.canStack && currentItem.Quantity > 0)
            {
                quantityText.text = $"x{currentItem.Quantity}";
                quantityText.gameObject.SetActive(true);
            }
        }
    }
}
