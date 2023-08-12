using UnityEngine;
using UnityEngine.UI;

namespace AM {
    public class InventoryInput : MonoBehaviour
    {

        [SerializeField] GameObject inventoryGameObject;
        [SerializeField] KeyCode[] toggleInventoryKeys;

        public GameObject waypoint;
        public GameObject handler;
        void Update()
        {
            for (int i = 0; i < toggleInventoryKeys.Length; i++)
            {
                if (Input.GetKeyDown(toggleInventoryKeys[i]))
                {
                    if (Time.timeScale == 0)
                    {
                        Time.timeScale = 1;
                    }
                    else
                    {
                        Time.timeScale = 0;
                    }
                    inventoryGameObject.SetActive(!inventoryGameObject.activeSelf);
                    waypoint.SetActive(!waypoint.activeSelf);
                    break;
                }
            }
        }
    }
}