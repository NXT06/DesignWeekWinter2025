using UnityEngine;
using TMPro;

public class CombinationLock : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private string correctCombination = "1234";

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI[] digitTexts;
    private int[] currentCombination = new int[4] { 0, 0, 0, 0 }; //default 0000
    private int selectedDigit = 0;
    private bool isUnlocked = false;

    void Update()
    {
        if (isUnlocked) return;

        //move between digits
        if (Input.GetKeyDown(KeyCode.A)) selectedDigit = Mathf.Max(0, selectedDigit - 1);
        if (Input.GetKeyDown(KeyCode.D)) selectedDigit = Mathf.Min(3, selectedDigit + 1);

        //change digit values (now from 0 to 9)
        if (Input.GetKeyDown(KeyCode.W)) currentCombination[selectedDigit] = (currentCombination[selectedDigit] + 1) % 10; //loop back to 0 after 9
        if (Input.GetKeyDown(KeyCode.S)) currentCombination[selectedDigit] = (currentCombination[selectedDigit] == 0) ? 9 : currentCombination[selectedDigit] - 1; //go from 0 to 9

        UpdateDisplay();

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
        }
        else
        {
            Debug.Log("Incorrect Combination");
        }
    }
}
