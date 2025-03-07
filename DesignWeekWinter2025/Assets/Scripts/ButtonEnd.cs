using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame()
    {
        Debug.Log("new scene");
        SceneManager.LoadScene("SampleScene");
    }

    public void StartGame()
    {
       // Debug.Log("new scene");
        SceneManager.LoadScene("Start Screen");
    }
}
