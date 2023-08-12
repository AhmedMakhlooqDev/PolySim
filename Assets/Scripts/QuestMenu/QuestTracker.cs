using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AM
{
    public class QuestTracker : MonoBehaviour
    {
        public GameObject siteDetailsMenu;
        static bool siteDetailsMenuStatus = false;
        public static int textFinishedInt = 1000;

        private void Awake()
        {
            //siteDetailsMenu = GameObject.Find("SiteInformationPanel");
        }
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            siteDetailsMenu.SetActive(siteDetailsMenuStatus);
        }

        private void OnTriggerEnter(Collider gameCube)
        {
            GameObject childRef = this.gameObject.transform.GetChild(1).gameObject;
            childRef.SetActive(true);
            if (QuestList.currentQuest != null)
            {
                if (QuestList.currentQuest.id == this.gameObject.tag)
                {
                    QuestList.questCompletedInt = int.Parse(this.gameObject.tag);
                    QuestMenuHandler.objectiveCompletedHandler(1);
                    Waypoint.HideWaypoint();
                }
            }

            siteDetailsMenuStatus = true;
            siteDetailsMenu.SetActive(siteDetailsMenuStatus);

        }

        private void OnTriggerExit(Collider other)
        {
            GameObject childRef = this.gameObject.transform.GetChild(1).gameObject;
            childRef.SetActive(false);
            siteDetailsMenuStatus = false;
            siteDetailsMenu.SetActive(siteDetailsMenuStatus);
        }

        public static void changeSiteInformationPageStatus() {
            siteDetailsMenuStatus = !siteDetailsMenuStatus;
        }

    }
}