using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviourScripts : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
