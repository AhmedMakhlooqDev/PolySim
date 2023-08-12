using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointCollide : MonoBehaviour
{
    public Image indicator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "center")
        {
            var tempColor = indicator.color;
            tempColor.a = 0.3f;
            indicator.color = tempColor;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "center")
        {
            var tempColor = indicator.color;
            tempColor.a = 1f;
            indicator.color = tempColor;
        }
    }
}
