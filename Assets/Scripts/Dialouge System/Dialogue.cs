using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace AM
{
    public class Dialogue : MonoBehaviour
    {
        public TextMeshProUGUI textComponent;
        public string[] lines;
        public float textSpeed;
        public Collider interact_Collider;
        private int index;
        InputHander inputhandler;
        private AudioSource source;

        public int addQuestInt = 1000;
        

        // Start is called before the first frame update
        void Start()
        {
            source = GetComponent<AudioSource>();
            inputhandler = GetComponent<InputHander>();
            textComponent.text = string.Empty;
            StartDialogue();
        }

        

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }

        void StartDialogue()
        {
            interact_Collider.enabled = false;
            index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine()
        {
            foreach (char c  in lines[index].ToCharArray())
            {
                
                textComponent.text += c;
                yield return new WaitForSeconds(textSpeed);
                
            }
        }

        void NextLine()
        {
            source.Play();
            if (index < lines.Length - 1)
            {
                index++;
                textComponent.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {               
                gameObject.SetActive(false);
                interact_Collider.enabled = true;
                if (addQuestInt != 1000)
                {
                    addNewQuest(addQuestInt);
                    QuestMenuHandler.questAdded = addQuestInt;
                }
                
            }
        }

        public static void addNewQuest(int questID)
        {
            QuestList.questAddedInt = questID;
        }

    }

}

