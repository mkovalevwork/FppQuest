using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    [Header("References")]
    public Image itemImage;
    [SerializeField] private Equipment playerEquipment;

    private BaseItem item;
    public BaseItem Item => item;

    private Pickable pickableReference;

    private void OnDisable()
    {
        playerEquipment.OnCurrentlyInHandDestroy -= ResetSlot;
    }

    private void Start()
    {
        if (item == null) return;
        itemImage.sprite = item.SpriteIcon;
    }

    public void SetPickableReference(Pickable pickable)
    {
        pickableReference = pickable;
    }

    public void SetItemUpdateUI(BaseItem item)
    {
        this.item = item;
        itemImage.sprite = item.SpriteIcon;
    }

    public void ResetSlot()
    {
        item = null;
        pickableReference = null;
        itemImage.sprite = null;
    }

    public void UseItem()
    {
        if (item == null) return;
        playerEquipment.OnCurrentlyInHandDestroy += ResetSlot;
        item.Use(playerEquipment.gameObject);
    }

    public void DropItem()
    {       
        playerEquipment.UnequipCurrentlyInHand(item);
             
        pickableReference.gameObject.SetActive(true);
        pickableReference.gameObject.transform.localPosition 
            = playerEquipment.transform.localPosition;
      
        item = null;           
        itemImage.sprite = null;
    }
}
