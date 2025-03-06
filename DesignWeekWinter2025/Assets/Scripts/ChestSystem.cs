using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class ChestSystem : MonoBehaviour
{
    [Header("Settings")]
    public string correctCombination = "1234";
    private bool playerNearby, isUnlocked = false, isOpening = false;

    private static ChestSystem activeChest;
    private static GameObject chestHUD, chestUnlockHUD;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI[] digitTexts;
    [SerializeField] private Image chestUnlockSprite;
    [SerializeField] private Sprite chestClosed, chestHalfOpen, chestOpen;
    [SerializeField] private AudioSource chestSound;

    private int[] currentCombination = new int[4] { 0, 0, 0, 0 };
    private int selectedDigit = 0;

    void Start()
    {
        if (chestHUD == null) chestHUD = GameObject.Find("ChestHUD");
        if (chestUnlockHUD == null) chestUnlockHUD = GameObject.Find("ChestUnlockHUD");

        if (chestHUD) chestHUD.SetActive(false);
        if (chestUnlockHUD) chestUnlockHUD.SetActive(false);

        chestUnlockSprite.sprite = chestClosed;
    }

    void Update()
    {
        playerNearby = Physics.OverlapSphere(transform.position, 5f, LayerMask.GetMask("Player")).Length > 0;

        if (playerNearby && activeChest != this && !isOpening)
        {
            activeChest = this;
            chestHUD.SetActive(true);
        }
        else if (!playerNearby && activeChest == this && !isOpening)
        {
            activeChest = null;
            chestHUD.SetActive(false);
        }

        if (!isUnlocked) HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.A)) selectedDigit = Mathf.Max(0, selectedDigit - 1);
        if (Input.GetKeyDown(KeyCode.D)) selectedDigit = Mathf.Min(3, selectedDigit + 1);
        if (Input.GetKeyDown(KeyCode.W)) currentCombination[selectedDigit] = (currentCombination[selectedDigit] + 1) % 10;
        if (Input.GetKeyDown(KeyCode.S)) currentCombination[selectedDigit] = (currentCombination[selectedDigit] == 0) ? 9 : currentCombination[selectedDigit] - 1;

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
        if (string.Join("", currentCombination) == correctCombination && !isUnlocked)
        {
            isUnlocked = true;
            StartCoroutine(PlayChestUnlockAnimation());
        }
    }

    IEnumerator PlayChestUnlockAnimation()
    {
        if (chestUnlockSprite == null || chestUnlockHUD == null)
        {
            Debug.LogError("ChestUnlockSprite or ChestUnlockHUD is not assigned!");
            yield break; // Exit if either reference is missing
        }

        chestUnlockHUD.SetActive(true);
        chestSound.Play();

        chestUnlockSprite.sprite = chestClosed;
        yield return new WaitForSeconds(1.6f);

        chestUnlockSprite.sprite = chestHalfOpen;
        yield return new WaitForSeconds(1.6f);

        chestUnlockSprite.sprite = chestOpen;
        yield return new WaitForSeconds(1.6f);

        chestUnlockHUD.SetActive(false);
    }

}
