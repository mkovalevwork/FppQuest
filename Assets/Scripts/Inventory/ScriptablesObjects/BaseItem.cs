using UnityEngine;

public abstract class BaseItem : ScriptableObject
{
    [SerializeField] private string itemName;
    public string ItemName => itemName;
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private Sprite spriteIcon;

    public GameObject ItemPrefab => itemPrefab;
    public Sprite SpriteIcon => spriteIcon;

    public abstract void Use(GameObject entity);
}
