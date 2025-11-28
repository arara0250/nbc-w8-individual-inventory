using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{    
    [Header("Status UI")]
    [SerializeField] private Button statusButton;

    [Header("Inventory UI")]
    [SerializeField] private Button inventoryButton;

    [Header("Character Info")]
    [SerializeField] private TextMeshProUGUI idText;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private Image expBar;
    [SerializeField] private TextMeshProUGUI expText;

    private void Start()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }

    public void OpenMainMenu()
    {
        statusButton.gameObject.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
        UIManager.Instance.UIStatus.gameObject.SetActive(false);
        UIManager.Instance.UIInventory.gameObject.SetActive(false);
    }

    private void OpenStatus()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        UIManager.Instance.UIStatus.SetStatusInfo(GameManager.Instance.Player);
        UIManager.Instance.UIStatus.gameObject.SetActive(true);
        UIManager.Instance.UIInventory.gameObject.SetActive(false);
    }

    private void OpenInventory()
    {
        statusButton.gameObject.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        UIManager.Instance.UIStatus.gameObject.SetActive(false);
        UIManager.Instance.UIInventory.RefreshInventoryUI(GameManager.Instance.Player);
        UIManager.Instance.UIInventory.gameObject.SetActive(true);
    }

    // UIMainMenu 에서 보이는 캐릭터 정보 (ID, 골드, 레벨, 경험치) 만 세팅
    public void SetCharacterInfo(Character Player)
    {
        idText.text = Player.CharacterID;
        goldText.text = Player.Gold.ToString();
        SetLevelInfo(Player);
    }

    public void SetLevelInfo(Character Player)
    {
        levelText.text = Player.Level.ToString();
        expBar.fillAmount = (float)Player.Experience / Player.RequiredExp;
        expText.text = $"{Player.Experience} / {Player.RequiredExp}";
    }
}
