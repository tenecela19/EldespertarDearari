using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FosilItem : MonoBehaviour, IDropHandler
{


    public Sprite[] imagenesFosil;
    public GameObject EffectExplosion;
    public GameObject Dialogo;
    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag != null)
        {
            CambioFosil(eventData);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    void CambioFosil(PointerEventData eventData)
    {
        DragAndDrop drag = eventData.pointerDrag.GetComponent<DragAndDrop>();
        
        switch (drag.CambioFosil)
        {
            case DragAndDrop.FosilCambioHerramienta.IMartillo:
                drag.TriggerDialogue();
                gameObject.GetComponent<Image>().sprite = imagenesFosil[0];
                Destroy(eventData.pointerDrag.gameObject);
                FindObjectOfType<AudioManager>().Play("Martillo");
                break;
            case DragAndDrop.FosilCambioHerramienta.Identista:
                if (gameObject.GetComponent<Image>().sprite == imagenesFosil[0])
                {
                    gameObject.GetComponent<Image>().sprite = imagenesFosil[1];
                    Destroy(eventData.pointerDrag.gameObject);
                    drag.TriggerDialogue();
                    FindObjectOfType<AudioManager>().Stop("Martillo");
                    FindObjectOfType<AudioManager>().Play("Dentista");

                }
                break;         

            case DragAndDrop.FosilCambioHerramienta.Iresanador:
                if (gameObject.GetComponent<Image>().sprite == imagenesFosil[1])
                {
                  gameObject.GetComponent<Image>().sprite = imagenesFosil[2];
                  Destroy(eventData.pointerDrag.gameObject);
                    drag.TriggerDialogue();
                    FindObjectOfType<AudioManager>().Stop("Dentista");
                    FindObjectOfType<AudioManager>().Stop("Martillo");
                    FindObjectOfType<AudioManager>().Play("Resonador");
                }

                break;
            case DragAndDrop.FosilCambioHerramienta.Ibrocha:
                if (gameObject.GetComponent<Image>().sprite == imagenesFosil[2])
                {
                    FindObjectOfType<AudioManager>().Stop("Dentista");
                    FindObjectOfType<AudioManager>().Stop("Resonador");
                    FindObjectOfType<AudioManager>().Stop("Martillo");
                    FindObjectOfType<AudioManager>().Play("Brocha");
                    gameObject.GetComponent<Image>().sprite = imagenesFosil[3];
                    Destroy(eventData.pointerDrag.gameObject);
                    GameController.Instance.Win = true;

                }
                break;

        }
    }

}
