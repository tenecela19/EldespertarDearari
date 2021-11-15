using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cajonera : MonoBehaviour
{
    public static bool ActivarCajon = false;
    public GameObject Llave;
    public bool Once = true;
    public GameObject Dialogo;
    public BoxCollider Estuche;
    public BoxCollider ShowingUICajon;
    bool HasWin;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<BoxCollider>().enabled = ActivarCajon;
    }

    // Update is called once per frame
    void Update()
    {

        if (Llave == null)
        {
            ActivarCajon = true;
            ShowingUICajon.enabled = false;
            if (Once == true)
            {
                GetComponent<BoxCollider>().enabled = true;
                    FindObjectOfType<AudioManager>().Play("Tomar");
                Once = false;
            }
        }
    }
    public void DeteccionDeFosil(bool IsTheCorrectFosil)
    {
        if (ActivarCajon)
        {
            if (!HasWin)
            {
                Dialogo.SetActive(false);
                if (IsTheCorrectFosil)
                {
                    FindObjectOfType<AudioManager>().Play("Correcto");
                    Dialogo.SetActive(true);
                    GetComponent<ShowUI>().dialogue.sentences[0] = "¡Este es el fósil que busco! Ahora solo falta guardarlo en algún lugar";
                    FindObjectOfType<DialogueManager>().StartDialogue(GetComponent<ShowUI>().dialogue);                                                                                
                    GetComponent<BoxCollider>().enabled = false;
                    GameObject.FindGameObjectWithTag("Fosiles").SetActive(false);
                    HasWin = true;
                    Estuche.enabled = true;

                }
                else
                {
                    FindObjectOfType<AudioManager>().PlayContinued("Error");

                    Dialogo.SetActive(true);
                    GetComponent<ShowUI>().dialogue.sentences[0] = "Me parece que no es este...";
                    FindObjectOfType<DialogueManager>().StartDialogue(GetComponent<ShowUI>().dialogue);
                }
            }

        }
        GetComponent<ShowUI>().dialogue.sentences[0] = "Me pregunto cuál es el que busco...";

    }
}
