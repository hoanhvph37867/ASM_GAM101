using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ResetGame()
    {
        GameObject.Find("PanelEndGame").SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void WinGame()
    {
        GameObject.Find("PanelWinGame").SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
