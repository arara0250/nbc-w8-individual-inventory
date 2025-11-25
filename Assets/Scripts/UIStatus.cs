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
}
