using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AM
{
    public class SiteInformationHandler : MonoBehaviour
    {
        static int counter = 0;
        public Sprite[] SiteImages;
        public Image SiteImageSprite;
        private AudioSource source;


        public static bool nextButton = false;


        public TextMeshProUGUI textComponent;
        public string[] lines;
        //public List<string> lines;
        public float textSpeed;
        public Collider interact_Collider;
        private int index;
        InputHander inputhandler;

        private void OnEnable()
        {
            inputhandler = GetComponent<InputHander>();
            textComponent.text = string.Empty;
            StartDialogue();
            SiteImageSprite.GetComponent<Image>();
            //lines = new List<string>();
        }

        private void Start()
        {
            source = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

            if (nextButton)
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

            if (index < SiteImages.Length)
            {
                SiteImageSprite.sprite = SiteImages[index];
                SiteImageSprite.preserveAspect = true;
                nextButton = false;
            }
            

        }

        void StartDialogue()
        {
            //interact_Collider.enabled = false;
            index = 0;
            StartCoroutine(TypeLine());
        }

        IEnumerator TypeLine()
        {
            foreach (char c in lines[index].ToCharArray())
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
                //textComponent.text = string.Empty;
                //gameObject.SetActive(false);
                //interact_Collider.enabled = true;
                QuestTracker.changeSiteInformationPageStatus();
                
                //index = 0;
            }
        }

    }
}