using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Character Player { get; private set; }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);

        Instance = this;
    }

    private void Start()
    {
        SetData();
    }

    void SetData()
    {
        Player = new Character
        (   
            id: "arara",
            level: 1,
            gold: 500,
            hp: 100,
            att: 10,
            def: 7,
            spd: 5
        );

        UIManager.Instance.UIMainMenu.SetCharacterInfo(Player);
        UIManager.Instance.UIStatus.SetStatusInfo(Player);
    }
}
