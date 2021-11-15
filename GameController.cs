using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Singleton
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameController>();
            }

            return _instance;
        }
    }
    #endregion
    public GameObject WinGame;
    public GameObject TextoFinal;
    [HideInInspector]
    public bool Win = false;
    public GameObject TextoComienzo;
    public GameObject FinalJuegoDemo;
    public bool Level2 = false;
    // Start is called before the first frame update
    void Start()
    {
        FinalJuegoDemo.SetActive(false);
        TextoComienzo.SetActive(true);
       FindObjectOfType<FirstPersonController>().enabled = false;

    }

    // Update is called once per frame
   public void Update()
    {

        HasWinGame();
    }
    void HasWinGame()
    {
        if (Win)
        {
            FindObjectOfType<AudioManager>().Play("FinalMusic");
            FindObjectOfType<AudioManager>().Stop("MusicaAmbiente");
                Return.Instance.gameObject.SetActive(true);
                StartCoroutine(WaitForAnimal());
        }
    }

    IEnumerator WaitForAnimal()
    {
        if(Level2 == true)
        {
            WinGame.SetActive(true);
            TextoFinal.SetActive(true);
            Return.Instance.gameObject.SetActive(false);
            FindObjectOfType<FirstPersonController>().enabled = false;
            yield return new WaitForSecondsRealtime(3f);
            FinalJuegoDemo.SetActive(true);
            yield return null;
        }
        else
        {
            Return.Instance.gameObject.SetActive(false);
            FindObjectOfType<FirstPersonController>().enabled = false;
            yield return new WaitForSecondsRealtime(3f);
            WinGame.SetActive(true);
            TextoFinal.SetActive(true);
            yield return null;
        }

    }
}
