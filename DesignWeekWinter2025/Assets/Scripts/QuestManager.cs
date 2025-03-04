using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    private int progress = 0;
    public int totalPieces = 5;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddProgress()
    {
        progress++;
        Debug.Log("Progress: " + progress + "/" + totalPieces);
        if (progress >= totalPieces) WinGame();
    }

    void WinGame()
    {
        Debug.Log("You win!");
    }
}
