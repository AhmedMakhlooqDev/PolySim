using UnityEngine;
using UnityEngine.UI;
public class ItemTooltip : MonoBehaviour
{
    [SerializeField] Text itemName;
    [SerializeField] Text itemDesc; 

    public void Showtooltip(Item item)
    {
        itemName.text = item.name;
        itemDesc.text = item.ItemDescription;
        gameObject.SetActive(true);
    }

    public void Hidetooltip()
    {
        gameObject.SetActive(false);
    }
}
