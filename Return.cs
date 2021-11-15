using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{
    #region Singleton
    private static Return _instance;
    public static Return Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<Return>();
            }

            return _instance;
        }
    }
    #endregion
    public GameObject Dialogo;

    public void ReturnToGame()
    {
        if (GameObject.FindGameObjectWithTag("UI").activeSelf == true)
        {
            
            Dialogo.SetActive(false);
            GameObject.FindGameObjectWithTag("UI").SetActive(false);
            FirstPersonController.Instance.cameraCanMove = true;
            FirstPersonController.Instance.lockCursor = true;
            Time.timeScale = 1;
            foreach (AudioSource item in FindObjectsOfType<AudioSource>())
            {
                if(item.loop == false)
                {
                    item.Stop();
                }
              
                
            }
            FirstPersonController.Instance.CanSeeInteractuar = false;
            FirstPersonController.Instance.PressButtonOnce = true;
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("Boton");

        }

        }


    }


