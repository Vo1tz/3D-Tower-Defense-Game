using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class buttonhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static buttonhover bhinstance;

    public RectTransform Button;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("expand");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Button.GetComponent<Animator>().Play("deflate");
    }

    public void deflateManual()
    {
        Button.GetComponent<Animator>().Play("deflate");
    }
}
