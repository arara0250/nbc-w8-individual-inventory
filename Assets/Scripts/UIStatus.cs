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
        attAddText.text = "";
        defAddText.text = "";
        spdAddText.text = "";

        healthText.text = Player.Health.ToString();
        attackText.text = Player.Attack.ToString();
        defenseText.text = Player.Defense.ToString();
        speedText.text = Player.Speed.ToString();

        if (Player.EquippedItems.Count == 0) return;

        foreach (Item item in Player.EquippedItems)
        {
            switch (item.ItemData.type)
            {
                case AbilityType.Attack:
                    attAddText.text = $"(+{item.ItemData.amount})";
                    break;
                case AbilityType.Defense:
                    defAddText.text = $"(+{item.ItemData.amount})";
                    break;
                case AbilityType.Speed:
                    spdAddText.text = $"(+{item.ItemData.amount})";
                    break;
                default:
                    break;
            }
        }
    }
}
