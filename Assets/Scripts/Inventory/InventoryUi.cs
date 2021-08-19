using UnityEngine;

public class InventoryUi : MonoBehaviour
{  
    [SerializeField] private InventorySlotUI[] inventorySlotUI;
    public InventorySlotUI[] InventorySlotUI => inventorySlotUI;
}
