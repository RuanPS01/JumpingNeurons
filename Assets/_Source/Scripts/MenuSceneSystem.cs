using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneSystem : MonoBehaviour
{
    [SerializeField]
    GameObject loadingPanel;

    [SerializeField]
    GameObject mainMenuPanel;

    public void ChangeScene(string sceneName)
    {
        StartCoroutine(LoadingToChangeScene(sceneName));
    }

    IEnumerator LoadingToChangeScene(string sceneName)
    {
        loadingPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }

    public void ExitOfApplication()
    {
        Application.Quit();
    }
}
