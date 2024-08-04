using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class CustomButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage;
    public Sprite defaultSprite;
    public Sprite hoverSprite;
    public Sprite pressedSprite;
    public TMP_Text buttonText; // Reference to the text component
    public Vector3 textMoveOffset = new Vector3(0, -10, 0); // Offset for text movement

    private Vector3 originalTextPosition;

    void Start()
    {
        if (buttonImage == null)
        {
            buttonImage = GetComponent<Image>();
        }
        if (buttonText != null)
        {
            originalTextPosition = buttonText.rectTransform.anchoredPosition;
        }
        buttonImage.sprite = defaultSprite;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = defaultSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            buttonImage.sprite = pressedSprite;
            if (buttonText != null)
            {
                buttonText.rectTransform.anchoredPosition = originalTextPosition + textMoveOffset;
            }
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            buttonImage.sprite = buttonImage.sprite == hoverSprite ? hoverSprite : defaultSprite;
            if (buttonText != null)
            {
                buttonText.rectTransform.anchoredPosition = originalTextPosition;
            }
        }
    }
}
