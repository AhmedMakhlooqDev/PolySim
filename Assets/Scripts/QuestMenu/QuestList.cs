using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AM
{
    public class QuestList : MonoBehaviour
    {
        //public GameObject questCompletedPanel;
        public GameObject QuestContainer;
        public GameObject parent;
        public static List<QuestItem> quests;
        public static QuestItem currentQuest;

        public static int questCompletedInt = 1000;
        public static int questAddedInt = 1000;

        private void Awake()
        {
            quests = new List<QuestItem> {
                new QuestItem("1", "Wahat Al-Bashayer", "Go to wahat albashayer Restaurant located near building 19", false,"BashayerCube"),
                new QuestItem("2", "Building 19", "Visit building 19 behind Wahat Al-Bashayer Restaurant", false,"B19Cube"),
                new QuestItem("3", "Student Information Center", "Visit Student Information Center ( Building 8 ) located on the left of building 19", false,"B8Cube"),//hide
                new QuestItem("4", "Health and Wellness Center", "Travel to building 16, also known as Health and Wellness center located at southeast of building 19", false,"B16Cube"),
                new QuestItem("5", "Building 26", "Building 26 is located west of building 8 and on the left of building 19", false,"B26Cube"),
                new QuestItem("6", "CEC Office", "Go to the office of Carrer and employment Center ( CEC ) Next to building 26", false,"CECCube"),
                new QuestItem("7", "Building 36", "Visit Building 36 which is located in the far west of building 19", false,"B36Cube"),//hide
                new QuestItem("8", "Building 11", "Building 11 can be found is next to building 36", false,"B11Cube"),
                new QuestItem("9", "ICT Services", "Go to Building 9 is located in front of building 8", false,"B9Cube"),
                new QuestItem("10", "Building 5", "Visit Building 5 which is behind building 8", false,"B5Cube"),//hide
                new QuestItem("11", "The Mosque", "Travel to Building 18 ( The mosque ) that is located behind building 19", false,"B18Cube"),
                new QuestItem("12", "Building 10", "Go to Building 10 that can be found next to building 9", false,"B10Cube"),//hide
                new QuestItem("13", "Bahrain Hall", "Visit Building 12 that can be found in front of building 26 ", false,"B12Cube"),
            };
        }

        // Start is called before the first frame update
        void Start()
        {
            //add all quests to the menu
            //hide quests
            getAllQuests();

            //uncomment to hide quest

            //parent.transform.GetChild(1).gameObject.SetActive(false);
            parent.transform.GetChild(2).gameObject.SetActive(false);
            //parent.transform.GetChild(3).gameObject.SetActive(false);
            //parent.transform.GetChild(4).gameObject.SetActive(false);
            //parent.transform.GetChild(5).gameObject.SetActive(false);
            //parent.transform.GetChild(6).gameObject.SetActive(false);
            parent.transform.GetChild(7).gameObject.SetActive(false);
            //parent.transform.GetChild(8).gameObject.SetActive(false);
            //parent.transform.GetChild(9).gameObject.SetActive(false);
            parent.transform.GetChild(10).gameObject.SetActive(false);
            //parent.transform.GetChild(11).gameObject.SetActive(false);
            //parent.transform.GetChild(12).gameObject.SetActive(false);


            //questCompletedPanel.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            //if a quest is completed the varaible "questCompletedInt" can be called from
            //any class to mark a quest as completed and re initialize the value back to 1000
            if (questCompletedInt != 1000)
            {
                questCompleted(questCompletedInt);
                //questCompletedPanel.SetActive(true);
                questCompletedInt = 1000;
            }

            //if a quest should be added, the varaible "questAddedInt" can be called from
            //any class to mark a quest as completed and re initialize the value back to 1000
            if (questAddedInt != 1000)
            {
                questAdded(questAddedInt);
                questAddedInt = 1000;
            }

            //this line will disable the default quest container prefab 
            QuestContainer.SetActive(false);
        }

        //this function will get all the qests and 
        void getAllQuests() {

            foreach (var qItem in quests)
            {

                if (qItem.completed == false)
                {
                    GameObject quest = Instantiate(QuestContainer, parent.transform.position, parent.transform.rotation, parent.transform);
                    GameObject questName = quest.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    GameObject button = quest.transform.GetChild(0).gameObject;
                    questName.GetComponent<UnityEngine.UI.Text>().text = qItem.questName.ToString();
                    button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate () { questSelected(qItem.questName, qItem.GameObjectname, qItem); });
                }
                else
                {
                    GameObject quest = Instantiate(QuestContainer, parent.transform.position, parent.transform.rotation, parent.transform);
                    GameObject questName = quest.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
                    GameObject button = quest.transform.GetChild(0).gameObject;
                    questName.GetComponent<UnityEngine.UI.Text>().text = qItem.questName.ToString();
                    button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(delegate () { questSelected("Done",qItem.GameObjectname,qItem); });
                    button.GetComponent<UnityEngine.UI.Button>().interactable = false;
                }
            }
        }

        //TODO change this quest in a way to enable and disable two game objects

        //this function should be responsible for setting the current objective

        //this function takes the quest name as parameter and sets the current objective in the ui
        //then automatically closes the quest menu for the user
        void questSelected(string questName, string GOname,QuestItem quest)
        {

            if (questName.Trim().ToLower() != "Done".Trim().ToLower())
            {
                //QuestMenuHandler.currentObjective = questName;
                QuestMenuHandler.viewQuestDescription();
                currentQuest = quest;
            }
            else
            {
                QuestMenuHandler.changeMenu();
            }

            
        }

        //this function is responsible for setting a quest as completed by taking the quest ID
        //by taking the quest id and setting the child object id as uninteractable button
        public void questCompleted(int id) {
            GameObject childRef = parent.transform.GetChild(id).gameObject.transform.GetChild(0).gameObject;
            if (parent.transform.childCount > 0)
            {
                childRef.GetComponent<UnityEngine.UI.Button>().interactable = false;
            }
            //TO-DO add code to remove current objective
            currentQuest = null;
        }

        //this function is responsible for adding a quest by taking the quest ID
        //by taking the quest id and setting a quest child object as active
        public void questAdded(int id)
        {
            GameObject childRef = parent.transform.GetChild(id).gameObject.transform.GetChild(0).gameObject;
            if (parent.transform.childCount > 0)
            {
                parent.transform.GetChild(id).gameObject.SetActive(true);
                
            }

        }

    }

    public class QuestItem
    {
        public string id = "";
        public string questName = "";
        public string questDesc = "";
        public bool completed = false;
        public string GameObjectname = "";

        public QuestItem(string id, string questName, string questDesc, bool completed, string GOname)
        {
            this.id = id;
            this.questName = questName;
            this.questDesc = questDesc;
            this.completed = completed;
            this.GameObjectname = GOname;
        }
    }
}

