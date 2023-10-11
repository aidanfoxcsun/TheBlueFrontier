using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Image[] images;
    public Transform parentAfterDrag;
    GameManager gameManager;
    AudioManager audioManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
        audioManager = AudioManager.instance;
        images = GetComponentsInChildren<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        foreach(Image image in images)
        {
            image.raycastTarget = false;
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        audioManager.PlayPencilSound();
        transform.SetParent(parentAfterDrag);
        foreach (Image image in images)
        {
            image.raycastTarget = true;
        }
        gameManager.FillSlotTypes();
        
    }
}
