using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevel : MonoBehaviour
{
    public float delaySecond = 2;
    public string nameScene = "Level0";

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            collider.gameObject.SetActive(false);
            ModeSelects();
        }
    }
    public void ModeSelects()
    {
        StartCoroutine(LoadAfterDelay());
    }

    IEnumerator LoadAfterDelay()
    {
        yield return new WaitForSeconds(delaySecond);

        SceneManager.LoadScene(nameScene);
    }
}
