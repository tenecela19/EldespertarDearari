using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region Singleton
    private static DragAndDrop _instance;
    public static DragAndDrop Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<DragAndDrop>();
            }

            return _instance;
        }
    }
    #endregion
    [SerializeField] private Canvas canvas;
    private CanvasGroup canvasGroup;
    public enum FosilCambioHerramienta { Identista, Ibrocha, Iresanador, IMartillo }
    public FosilCambioHerramienta CambioFosil;
    private RectTransform rectTransform;
    public Transform ResetPosition;
    public Dialogue dialogo;
    public GameObject DialogoTexto;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void TriggerDialogue()
    {
        DialogoTexto.SetActive(true);
        FindObjectOfType<DialogueManager>().StartDialogue(dialogo);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        DialogoTexto.SetActive(false);
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (gameObject != null)
        {
            transform.position = ResetPosition.position;
        }

        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}


