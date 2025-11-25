using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private Button exitButton;

    void Start()
    {
        exitButton.onClick.AddListener(CloseInventory);
    }

    private void CloseInventory()
    {
        UIManager.Instance.UIMainMenu.OpenMainMenu();
    }
}
