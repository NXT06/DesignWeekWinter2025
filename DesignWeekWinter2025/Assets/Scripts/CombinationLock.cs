using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombinationLock : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string correctCombination = "1234";

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI[] digitTexts; // 4 UI Text elements for each digit

    private int[] currentCombination = new int[4] { 1, 1, 1, 1 }; // Default 1111
    private int selectedDigit = 0;
    private bool isUnlocked = false;

    void Update()
    {
        if (isUnlocked) return;

        // Move between digits
        if (Input.GetKeyDown(KeyCode.A)) selectedDigit = Mathf.Max(0, selectedDigit - 1);
        if (Input.GetKeyDown(KeyCode.D)) selectedDigit = Mathf.Min(3, selectedDigit + 1);

        // Change digit values
        if (Input.GetKeyDown(KeyCode.W)) currentCombination[selectedDigit] = (currentCombination[selectedDigit] % 9) + 1;
        if (Input.GetKeyDown(KeyCode.S)) currentCombination[selectedDigit] = (currentCombination[selectedDigit] == 1) ? 9 : currentCombination[selectedDigit] - 1;

        // Update UI
        UpdateDisplay();

        // Check combination
        if (Input.GetKeyDown(KeyCode.Return)) CheckCombination();
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
        if (enteredCombination == correctCombination)
        {
            isUnlocked = true;
            Debug.Log("Lock Opened!");
            // Add unlock event logic here
        }
        else
        {
            Debug.Log("Incorrect Combination");
        }
    }
}
