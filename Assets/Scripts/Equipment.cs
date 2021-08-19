using UnityEngine;
using System;

public class Equipment : MonoBehaviour
{
    [SerializeField] private Transform equipLocation;

    private GameObject currentlyInHand;
    public GameObject CurrentlyInHand => currentlyInHand;

    private BaseItem currentlyEquipped;
    public BaseItem CurrentlyEquiped => currentlyEquipped;

    public event Action OnCurrentlyInHandDestroy;

    public void SetCurrentlyInHand(BaseItem equipable)
    {
        if(currentlyInHand != null) return;
        currentlyEquipped = equipable;
        GameObject tempObject = Instantiate(equipable.ItemPrefab, equipLocation);
        tempObject.transform.localEulerAngles = new Vector3(0, 180, 0);
        currentlyInHand = tempObject;
    }

    public void UnequipCurrentlyInHand()
    {
        if (currentlyInHand == null) return;
        Destroy(currentlyInHand);
        currentlyInHand = null;
    }

    public void UnequipCurrentlyInHand(BaseItem itemInHand)
    {        
        if (currentlyInHand == null) return;
        if(currentlyEquipped.Equals(itemInHand))
        {
            UnequipCurrentlyInHand();
        }
    }

    public void DestroyCurrentlyInHand()
    {
        Destroy(currentlyInHand);
        currentlyEquipped = null;
        OnCurrentlyInHandDestroy?.Invoke();
    }
}
