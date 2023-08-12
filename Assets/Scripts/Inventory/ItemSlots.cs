using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlots : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] Image image;
    [SerializeField] ItemTooltip tooltip;

    private Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
             
            if (_item == null)
            {
                image.enabled = false;

            }
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

 


    private void OnValidate()
    {
        if(image == null)
        {
            image = GetComponent<Image>(); 
        }
        
        if(tooltip == null)
        {
            tooltip = FindObjectOfType<ItemTooltip>();
        }
    }

    public void OnPointerEnter (PointerEventData eventData)
    {
        tooltip.Showtooltip(Item);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.Hidetooltip();
    }
}
