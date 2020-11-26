using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator anim;
    public Health healthScript;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void ThisLevel()
    {
        if (healthScript.health <= 0)
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        anim.SetTrigger("Start");

        // Pauses coroutine for 1 amount of seconds before continuing on
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

}
