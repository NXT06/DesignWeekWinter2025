using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public static int progress = 0;
    public static int totalPieces = 4;

    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    private void Start()
    {
        progress = 0;
    }

    public static void AddProgress()
    {
        progress++;
        Debug.Log("Progress: " + progress + "/" + totalPieces);
    }

    public static void WinGame()
    {
        SceneManager.LoadScene("End Screen");
    }
}
