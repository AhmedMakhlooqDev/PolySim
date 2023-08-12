using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapControls : MonoBehaviour
{

    public GameObject minimap;
    public GameObject fullmap;
    //public RawImage map;
    //public Image map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            ////map.transform.position = new Vector2 (Screen.width *0.5f, Screen.height * 0.5f);
            //////map.transform.localScale = new Vector2(5,5);
            ////mapView.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1500);
            ////mapView.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 750);
            ////mapCam.orthographicSize = 250;
            ////mapCam.transform.position = new Vector3(0, map.transform.position.y, -100);
            //////map.rectTransform.anchoredPosition.Set(1,0);
            //////mapB.rectTransform.anchoredPosition.Set(1,0);
            ////map.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1510);
            ////map.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 760);
            //////mapB.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1500);
            //////mapB.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1500);

            ////// map.rectTransform.anchoredPosition =

            ////MapCam.mapOpen(true);
            ///

            minimap.SetActive(false);
            fullmap.SetActive(true);
            
        }
        else
        {
            ////map.transform.position = new Vector2(width, height);
            //////map.transform.localScale = new Vector2(1,1);
            ////mapCam.orthographicSize = 47.5f;
            ////mapView.rectTransform.sizeDelta = new Vector2(170, 170);
            ////map.rectTransform.sizeDelta = new Vector2(178, 178);
            ////MapCam.mapOpen(false);
            minimap.SetActive(true);
            fullmap.SetActive(false);
        }
    }
}
