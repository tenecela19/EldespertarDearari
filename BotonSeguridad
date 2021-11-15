using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonSeguridad : MonoBehaviour
{
    #region Singleton
    private static BotonSeguridad _instance;
    public static BotonSeguridad Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BotonSeguridad>();
            }

            return _instance;
        }
    }
    #endregion
    public const string NumeroSeguridad= "830";
    public string key = "";
    public static string[] numbers = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
    public Text[] Botones_Texto;
    public bool IsDone = false;
    public static bool CandadoDesbloqueado;
    public GameObject PuertaNormal;
    public GameObject PuertConLlave;
    // Update is called once per frame
    void Update()
    {
        if (IsDone == false)
        {
            KeyUnlock();

        }
    }

    public void ActualizarBotones()
    {
        key = Botones_Texto[0].text + Botones_Texto[1].text + Botones_Texto[2].text;
    }
    public void KeyUnlock()
    {
        if (key == NumeroSeguridad)
        {
            CandadoDesbloqueado = true;
            PuertaNormal.SetActive(true);
            PuertConLlave.SetActive(false);    
            FindObjectOfType<AudioManager>().Play("Activado");
            StartCoroutine(WaitToReturn());
            IsDone = true;
        }
    }
    IEnumerator WaitToReturn()
    {
        FindObjectOfType<Return>().gameObject.GetComponent<Image>().enabled = false;
        yield return new WaitForSecondsRealtime(2f);
        FindObjectOfType<Return>().gameObject.GetComponent<Image>().enabled = true;
        Return.Instance.ReturnToGame();
        yield return null;
    }
}
