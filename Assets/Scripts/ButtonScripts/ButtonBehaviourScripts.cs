using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviourScripts : MonoBehaviour
{
    [SerializeField]
    GameObject currentUI;
    [SerializeField]
    GameObject loadingUI;
    [SerializeField]
    GameObject loadingFill;
    AsyncOperation _operation;
    public void Restart()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void LoadGameScene()
    {
        currentUI.SetActive(false);
        loadingUI.SetActive(true);
        _operation = SceneManager.LoadSceneAsync(1);
        _operation.allowSceneActivation = false;
        StartCoroutine(nameof(FollowProgress));
    }
    private IEnumerator FollowProgress()
    {
        yield return new WaitForSeconds(0.01f);
        RectTransform rectTransform = loadingFill.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(11000 - (_operation.progress * 10000 + _operation.progress * 1000), rectTransform.sizeDelta.y);
        if (_operation.progress < 0.9f)
            StartCoroutine(nameof(FollowProgress));
        else
            _operation.allowSceneActivation = true;

    }
    public void ExitGame()
    {
        Application.Quit();
        EditorApplication.ExitPlaymode();
    }
}
