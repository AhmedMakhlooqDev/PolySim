using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialRotation : MonoBehaviour
{

    public Transform player;

    // Update is called once per frame
    void Update()
    {
        var lookpos = transform.position - player.position;
        lookpos.y = 0;
        this.transform.rotation = Quaternion.LookRotation(lookpos);
    }
}
