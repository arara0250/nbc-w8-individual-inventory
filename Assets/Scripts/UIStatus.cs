using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStatus : MonoBehaviour
{
    [SerializeField] private Button exitButton;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private TextMeshProUGUI attackText;
    [SerializeField] private TextMeshProUGUI defenseText;
    [SerializeField] private TextMeshProUGUI speedText;

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
        healthText.text = Player.Health.ToString();
        attackText.text = Player.Attack.ToString();
        defenseText.text = Player.Defense.ToString();
        speedText.text = Player.Speed.ToString();
    }
}
