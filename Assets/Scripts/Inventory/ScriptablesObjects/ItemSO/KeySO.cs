using UnityEngine;

[CreateAssetMenu(fileName = "ChestInfo", menuName = "Gameplay/New Key")]
public class KeySO : BaseItem
{
    public override void Use(GameObject entity)
    {
        entity.TryGetComponent(out Equipment equip);
        if (equip == null) return;

        if (equip.CurrentlyInHand != null) return;
       
        equip.SetCurrentlyInHand(this);
    }
}
