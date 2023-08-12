using UnityEngine;

public class ItemInteract : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] Inventory inventory;

    private bool isInRange;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInRange)
            {
                inventory.AddItem(item);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInRange = false;
    }

}
