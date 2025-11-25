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

    void Start()
    {
        exitButton.onClick.AddListener(CloseInventory);

        InitInventoryUI();
    }

    private void CloseInventory()
    {
        UIManager.Instance.UIMainMenu.OpenMainMenu();
    }

    void InitInventoryUI()
    {
        for (int i = 0; i < slotCount; i++)
        {
            Instantiate(slotPrefab, slotParent);
        }
    }
}
