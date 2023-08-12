using AM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class QuestMenuHandler : MonoBehaviour
{
    public GameObject objectiveText;

    public GameObject questMenu;
    private static bool questMenuStatus = false;

    public GameObject questDetailsMenu;
    private static bool questDetailsMenuStatus = false;
    public GameObject scrollViewMenu;
    private static bool scrollViewMenuStatus = true;

    public GameObject questNameUI;
    public GameObject questDescUI;

    public GameObject player;
    public GameObject pauseMenu;
    public GameObject pauseMenuOptions;
    public GameObject pauseMenuButtons;

    public Camera mainCamera;
    public GameObject cameraHolder;
    public Camera pauseMenuCamera;
    public GameObject waypointGameObject;
    public GameObject miniMapGameObject;
    public static bool pauseMenuStatus = false;
    private static bool pauseMenuOptionsStatus = false;
    private static bool pauseMenuButtonsStatus = true;
    

    public AudioSource music;

    public static int objectiveCompleted = 1000;
    public static int questAdded = 1000;

    public GameObject objectiveBar;

    

    private void Awake()
    {
        objectiveBar.SetActive(false);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.J) && pauseMenuStatus == false)
        {
            changeMenu();

            InputHander x = player.GetComponent<InputHander>();
            if (x != null)
            {
                x.enabled = !x.enabled;
            }

            if (objectiveText.GetComponent<UnityEngine.UI.Text>().text == "Quest Completed" || objectiveText.GetComponent<UnityEngine.UI.Text>().text == "New Quest Added")
            {
                objectiveText.GetComponent<UnityEngine.UI.Text>().text = "";
                objectiveBar.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape) && questMenuStatus == false)
        {
            pauseGame();
            InputHander x = player.GetComponent<InputHander>();
            if (x != null)
            {
                x.enabled = !x.enabled;
            }
        }

        if (pauseMenuStatus == false || questMenuStatus == false)
        {
            InputHander x = player.GetComponent<InputHander>();
            if (x.enabled == false)
            {
                x.enabled = true;
            }
            
        }

        if (pauseMenuStatus == true || questMenuStatus == true)
        {
            cameraHolder.SetActive(false);
            pauseMenuCamera.enabled = true;
            miniMapGameObject.SetActive(false);
        }
        else
        {
            cameraHolder.SetActive(true);
            pauseMenuCamera.enabled = false;
            miniMapGameObject.SetActive(true);
        }

        questMenu.SetActive(questMenuStatus);

        if (objectiveCompleted != 1000)
        {
            objectiveText.GetComponent<UnityEngine.UI.Text>().text = "Quest Completed";
            objectiveCompleted = 1000;
        }

        if (questAdded != 1000)
        {
            objectiveText.GetComponent<UnityEngine.UI.Text>().text = "New Quest Added: " + QuestList.quests[questAdded - 1].questName;
            objectiveBar.SetActive(true);
            questAdded = 1000;
        }


        scrollViewMenu.SetActive(scrollViewMenuStatus);
        questDetailsMenu.SetActive(questDetailsMenuStatus);
        addQuestDetails();

        pauseMenu.SetActive(pauseMenuStatus);
        pauseMenuOptions.SetActive(pauseMenuOptionsStatus);
        pauseMenuButtons.SetActive(pauseMenuButtonsStatus);
    }

    public static void changeMenu() {
        questMenuStatus = !questMenuStatus;
    }


    public static void pauseGame()
    {
        pauseMenuStatus = !pauseMenuStatus;

        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else {
            Time.timeScale = 1;
        }
    }

    public void resumeButtonClicked() {

        pauseMenuStatus = !pauseMenuStatus;

        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public static void viewQuestDescription()
    {
        scrollViewMenuStatus = !scrollViewMenuStatus;
        questDetailsMenuStatus = !questDetailsMenuStatus;
    }

    public void addQuestDetails() {
        if (questDetailsMenuStatus == true)
        {
            questNameUI.GetComponent<UnityEngine.UI.Text>().text = QuestList.currentQuest.questName.ToString();
            questDescUI.GetComponent<UnityEngine.UI.Text>().text = QuestList.currentQuest.questDesc.ToString();
        }
    }

    public void backFromQuestDescription()
    {
        scrollViewMenuStatus = !scrollViewMenuStatus;
        questDetailsMenuStatus = !questDetailsMenuStatus;
    }

    public void startQuest()
    {
        Waypoint.ShowHideWaypoint();
        scrollViewMenuStatus = !scrollViewMenuStatus;
        questDetailsMenuStatus = !questDetailsMenuStatus;
        changeMenu();
        setCurrentObjective();
        Waypoint.setTarget(QuestList.currentQuest.GameObjectname);
        GameObject.Find(QuestList.currentQuest.GameObjectname).transform.GetChild(0).gameObject.SetActive(true);
    }

    public void setCurrentObjective() {

        if (QuestList.currentQuest != null)
        {
            objectiveBar.SetActive(true);
            objectiveText.GetComponent<UnityEngine.UI.Text>().text = QuestList.currentQuest.questName.ToString();
        }

        if (QuestList.currentQuest == null)
        {
            objectiveBar.SetActive(false);
            objectiveText.GetComponent<UnityEngine.UI.Text>().text = "";
        }

    }

    public void cancelButtonClicked() {
        scrollViewMenuStatus = !scrollViewMenuStatus;
        questDetailsMenuStatus = !questDetailsMenuStatus;
        changeMenu();
        QuestList.currentQuest = null;
        setCurrentObjective();
    }


    public void NextButtonClicked()
    {
        SiteInformationHandler.nextButton = true;
    }

    public static void objectiveCompletedHandler(int num) {
        objectiveCompleted = num;
    }

    public void optionsClicked() {
        pauseMenuButtonsStatus = !pauseMenuButtonsStatus;
        pauseMenuOptionsStatus = !pauseMenuOptionsStatus;
    }

    public void lowVolume() {
        music.volume = 0.02f;
    }
    public void medVolume()
    {
        music.volume = 0.1f;
    }
    public void hiVolume()
    {
        music.volume = 0.19f;
    }

    public void lowSense()
    {
        CameraHandler.lookSpeed = 0.03f;
        optionsClicked();
        resumeButtonClicked();
    }
    public void medSense()
    {
        CameraHandler.lookSpeed = 0.06f;
        optionsClicked();
        resumeButtonClicked();
    }
    public void hiSense()
    {
        CameraHandler.lookSpeed = 0.11f;
        optionsClicked();
        resumeButtonClicked();
    }

}
