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

    public void SetCharacterInfo(Character Player)
    {
        idText.text = Player.CharacterID;
        levelText.text = Player.Level.ToString();
        goldText.text = Player.Gold.ToString();
    }
}
