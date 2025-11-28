using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button exitButton;

    [Header("Info Texts")]
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI attAddText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI defAddText;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI spdAddText;

    void Start()
    {
        exitButton.onClick.AddListener(CloseStatus);
    }

    private void CloseStatus()
    {
        UIManager.Instance.UIMainMenu.OpenMainMenu();
    }

    public void SetStatusInfo(Character Player)
    {
        // 장착 아이템에 의한 status 수치 변화 표시 텍스트 초기화
        attAddText.text = "";
        defAddText.text = "";
        spdAddText.text = "";

        healthText.text = Player.Health.ToString();
        attackText.text = Player.Attack.ToString();
        defenseText.text = Player.Defense.ToString();
        speedText.text = Player.Speed.ToString();

        // 장착한 아이템이 없다면, 그대로 return
        if (Player.EquippedItems.Count == 0) return;

        // 장착 아이템에 의한 status 수치 변화 표시
        foreach (Item item in Player.EquippedItems)
        {
            switch (item.ItemData.equipType)
            {
                case EquipmentType.Attack:
                    attAddText.text = $"(+{item.ItemData.stat})";
                    break;
                case EquipmentType.Defense:
                    defAddText.text = $"(+{item.ItemData.stat})";
                    break;
                case EquipmentType.Speed:
                    spdAddText.text = $"(+{item.ItemData.stat})";
                    break;
                default:
                    break;
            }
        }
    }
}
