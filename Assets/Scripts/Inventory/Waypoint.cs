using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoint : MonoBehaviour
{
    public Image indicator;
    static public Transform target;
    public Text distance;
    //public GameObject gameObject;
    static public string GOname;
    public int X1,X2;
    public int Y1, Y2;
    static public GameObject waypoint;
    public GameObject WP;


    private void Start()
    {
        //indicator.enabled = false;
        //distance.enabled = false;
        target = GameObject.Find("NPC_TEST_01").transform;
        waypoint = WP;

        HideWaypoint();
        //target = gameObject.transform;
    }
    private void Update()
    {
        float minX = indicator.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;

        float minY = indicator.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.height - minY;

        
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        if(Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            //target is behind player
            if (pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        indicator.transform.position = pos;
        distance.text = ((int)Vector3.Distance(target.position, transform.position)).ToString() + " m";

        //Debug.Log(pos.ToString());

        //if (pos.x > X1 && pos.x < X2 && pos.y < Y2 && pos.y >= Y1)
        //{
        //    Debug.Log("in center");
        //    var tempColor = indicator.color;
        //    tempColor.a = 0.3f;
        //    indicator.color = tempColor;
        //}
        //else
        //{
        //    var tempColor = indicator.color;
        //    tempColor.a = 1f;
        //    indicator.color = tempColor;
        //}

    }

    //static public void setname(string name)
    //{
    //    GOname = name;
    //    setTarget();
    //}
    public static void setTarget(string name)
    {
        
        if (name.Trim() != "")
        {
            target = GameObject.Find(name).transform;
            ShowWaypoint();
        }
    }

    public static void HideWaypoint()
    {
        waypoint.SetActive(false);
        Debug.Log("hidden");
    }

    public static void ShowWaypoint()
    {
        waypoint.SetActive(true);
    }

    public static void ShowHideWaypoint()
    {
        waypoint.SetActive(waypoint.activeSelf);
    }
}
