using UnityEngine;
using TMPro;

public class ChestSystem : MonoBehaviour
{
    [Header("Settings")]
    public string correctCombination = "1234"; //combination for the lock
    private bool playerNearby;
    private bool isUnlocked = false;

    private static ChestSystem activeChest;
    private static GameObject chestHUD;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI[] digitTexts; //digits

    private int[] currentCombination = new int[4] { 1, 1, 1, 1 }; //start at 1111
    private int selectedDigit = 0;

    void Start()
    {
        if (chestHUD == null) chestHUD = GameObject.Find("ChestHUD");
        if (chestHUD) chestHUD.SetActive(false); //hide hud
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("Player"));
        playerNearby = hitColliders.Length > 0;

        if (playerNearby && activeChest != this)
        {
            activeChest = this;
            chestHUD.SetActive(true);
        }

        if (!playerNearby && activeChest == this)
        {
            activeChest = null;
            chestHUD.SetActive(false);
        }

        if (!isUnlocked) HandleInput();
    }

    void HandleInput()
    {

        //input code for each control
        if (Input.GetKeyDown(KeyCode.A)) selectedDigit = Mathf.Max(0, selectedDigit - 1);
        if (Input.GetKeyDown(KeyCode.D)) selectedDigit = Mathf.Min(3, selectedDigit + 1);
        if (Input.GetKeyDown(KeyCode.W)) currentCombination[selectedDigit] = (currentCombination[selectedDigit] % 9) + 1;
        if (Input.GetKeyDown(KeyCode.S)) currentCombination[selectedDigit] = (currentCombination[selectedDigit] == 1) ? 9 : currentCombination[selectedDigit] - 1;

        UpdateDisplay();
        CheckCombination();
    }

    void UpdateDisplay()
    {
        for (int i = 0; i < 4; i++)
        {
            digitTexts[i].text = currentCombination[i].ToString();
            digitTexts[i].color = (i == selectedDigit) ? Color.yellow : Color.white;
        }
    }

    void CheckCombination()
    {
        string enteredCombination = string.Join("", currentCombination);
        if (enteredCombination == correctCombination && !isUnlocked)
        {
            isUnlocked = true;
            chestHUD.SetActive(false);
            QuestManager.Instance.AddProgress(); //progress objective in the other script
        }
    }
}
