using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCam : MonoBehaviour
{
    public GameObject player;
    static bool mapIsOpen;

    // Update is called once per frame
    void Update()
    {

        if (!mapIsOpen)
        {
            this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z);
        }
    }

    public static void mapOpen(bool isOpen)
    {
        mapIsOpen = isOpen;
    }



}
