using UnityEngine;

public class InventoryMode : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerRotator mouseLook;
    private bool inventoryModeON = false;
    
    void Update()
    {
        InputChecker();               
    }

    void InputChecker()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
         InventoryModeActivator();

        if (Input.GetMouseButtonDown(0))
            PickUp();
    }

    void EnterInventoryMode()
    {
        inventoryModeON = true;

        playerMovement.enabled = false;
        mouseLook.enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }

    void ExitInventoryMode()
    {
        inventoryModeON = false;

        playerMovement.enabled = true;
        mouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void InventoryModeActivator()
    {
        if (!inventoryModeON)
        {
            EnterInventoryMode();
        }
        else if (inventoryModeON)
        {
            ExitInventoryMode();
        }
    }

    void PickUp()
    {
        if (inventoryModeON)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {             
                hit.collider.TryGetComponent(out BaseInteractable target);
                if (target == null) return;
                target.Interact();
            }
        }                                   
    }
}
