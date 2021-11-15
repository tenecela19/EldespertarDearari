using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScene : MonoBehaviour
{
    #region Singleton
    private static ChangeScene _instance;
    public static ChangeScene Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ChangeScene>();
            }

            return _instance;
        }
    }
    #endregion

    public void Scene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void WaitForSceneToInvoke(string name) { 
        StartCoroutine(InvokeScene(name));
    }
    public void QuitGame()
    {
        Application.Quit();
    }
     IEnumerator InvokeScene(string name)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }
}
