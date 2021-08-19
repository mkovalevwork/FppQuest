using UnityEngine;

public class Pickable : BaseInteractable
{
    [SerializeField] private BaseItem item;
    private InventoryUi inventory;

    private void Start() 
        => SetupVariables();

    void SetupVariables()
        => inventory = GameObject.FindGameObjectWithTag("InventoryHandler").GetComponent<InventoryUi>();

    public override void Interact()
    {
        foreach(InventorySlotUI slot in inventory.InventorySlotUI)
        {
            if (slot.Item != null) continue;
            slot.SetPickableReference(this);
            slot.SetItemUpdateUI(item);
            gameObject.SetActive(false);
            break;
        }
    }
}