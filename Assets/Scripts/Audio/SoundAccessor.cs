using UnityEngine;
using UnityEngine.EventSystems;

public class SoundAccessor : MonoBehaviour,
    IPointerEnterHandler,
    IPointerClickHandler
{
    [SerializeField]
    private SoundID hoverSound;
    
    [SerializeField]
    private SoundID clickSound;

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.Instance.PlaySound2D(hoverSound);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SoundManager.Instance.PlaySound2D(clickSound);
    }
}