using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AM
{
    public class QuestTestItem : MonoBehaviour
    {

        public GameObject cube;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter(Collider other)
        {
            QuestList.questCompletedInt = 3;
        }
    }
}