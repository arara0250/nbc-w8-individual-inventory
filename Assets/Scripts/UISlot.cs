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

    // 아이템 슬롯 (본인) 에 저장된 아이템에 맞는 아이콘 및 텍스트를 표시하는 함수
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

            // 장착템 : 장착 표시
            if (currentItem.IsEquipped)
                equipText.gameObject.SetActive(true);
            else
                equipText.gameObject.SetActive(false);

            // 소비템 : 개수 표시
            if (currentItem.ItemData.canStack && currentItem.Quantity > 0)
            {
                quantityText.text = $"x{currentItem.Quantity}";
                quantityText.gameObject.SetActive(true);
            }
        }
    }
}
