using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image itemIcon;
    [SerializeField] private TextMeshProUGUI equipText;
    [SerializeField] private Button slotButton;
    
    [SerializeField] private int slotIndex;

    public void SetIndex(int index)
    {
        slotIndex = index;
    }

    void SetItem()
    {

    }

    void RefreshUI()
    {

    }
}
