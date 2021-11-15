using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Computer_controller : MonoBehaviour
{
    public GameObject PanelPreguntas;
    public GameObject[] Preguntas;
    public Text[] textoPreguntas;
    public string[] RespuestasPreguntas;
    public GameObject MenuDeComputer;
    public GameObject Notas;
    public Text Codigo;
    public GameObject ErrorCode;
    public GameObject computerUI;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(computerUI != null)
        {
            if (computerUI.activeSelf == false)
            {
                ErrorCode.SetActive(false);
            }
        }

    }

    public void ActivarPreguntas()
    {
        PanelPreguntas.SetActive(true);
        Preguntas[0].SetActive(true);
    }
    public void ActivarNotasdeCodigo()
    {
        Notas.SetActive(true);
        Codigo.text = Candado_Controller.Instance.code;
    }
    public void OpenText()
    {
        if(textoPreguntas[0].text.ToLower() == RespuestasPreguntas[0].ToLower()){
            MenuDeComputer.SetActive(true);
            GameController.Instance.Win = true;
            FindObjectOfType<AudioManager>().Play("Correcto");
            FindObjectOfType<AudioManager>().Stop("Computer");

               
        }
        
    }
    public void NextQuestion(int numPregunta)
    {
        switch (numPregunta)
        {
            case 0:
                
                if(textoPreguntas[0].text.ToLower() == RespuestasPreguntas[0].ToLower())
                {
                    FindObjectOfType<AudioManager>().Play("Correcto");
                    Preguntas[0].SetActive(false);
                    Preguntas[1].SetActive(true);
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Incorrecto");

                }
                break;

            case 1:
                if (textoPreguntas[1].text.ToLower() == RespuestasPreguntas[1].ToLower())
                {
                    FindObjectOfType<AudioManager>().Play("Correcto");
                    Preguntas[1].SetActive(false);
                    Preguntas[2].SetActive(true);
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Incorrecto");

                }
                break;
            case 2:
                if (textoPreguntas[2].text.ToLower() == RespuestasPreguntas[2].ToLower())
                {
                    FindObjectOfType<AudioManager>().Play("Correcto");
                    Preguntas[2].SetActive(false);
                    PanelPreguntas.SetActive(false);
                    MenuDeComputer.SetActive(true);
                }
                else
                {
                    FindObjectOfType<AudioManager>().Play("Incorrecto");

                }
                break;

            default:
                PanelPreguntas.SetActive(false);
                Preguntas[0].SetActive(false);
                Preguntas[1].SetActive(false);
                Preguntas[2].SetActive(false);
                break;
        }
    }
}
