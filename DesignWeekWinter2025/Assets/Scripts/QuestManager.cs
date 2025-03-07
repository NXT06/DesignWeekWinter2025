using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    private int progress = 0;
    public int totalPieces = 5;
    public GameObject[] gemSlots = new GameObject[4]; 

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void AddProgress()
    {
        gemSlots[progress].SetActive(true); 
        progress++;
        Debug.Log("Progress: " + progress + "/" + totalPieces);

        if (progress >= totalPieces) WinGame();
    }

    void WinGame()
    {
        SceneManager.LoadScene("End Screen");
    }
}
