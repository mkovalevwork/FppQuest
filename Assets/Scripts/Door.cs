using UnityEngine;
using System;

public class Door : MonoBehaviour
{
    [SerializeField] private DoorHandler doorHandler;

    [SerializeField] private BaseItem requiredKey;
    public BaseItem RequiredKey => requiredKey;

    public event Action OnCorrectKey;
    public event Action OnWrongKey;

    private Renderer r_door;

    private void Start()
    {
        r_door = GetComponent<Renderer>();
        SetDefaultColor();
    }
    
    private void OnEnable()
    {
        OnCorrectKey += CorrectKey;               
        OnWrongKey += WrongKey;
    }

    private void OnDisable()
    {
        OnCorrectKey -= CorrectKey;
        OnWrongKey -= WrongKey;
    }

    public void CorrectKey()
    {
        ChangeObjectColor(Color.green);
        doorHandler.AddCorrectDoor();
        
    }

    public void WrongKey()
    {
        ChangeObjectColor(Color.red);
        Invoke("SetDefaultColor", 0.5f);
    }

    private void SetDefaultColor()
    {
        ChangeObjectColor(Color.gray);
    }

    private void ChangeObjectColor(Color color) 
        => r_door.material.color = color;
    

    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.TryGetComponent(out Equipment equipment);
        if (equipment == null) return;

        BaseItem tempWeapon = equipment?.CurrentlyEquiped;
        if (tempWeapon == null) return;

        if (tempWeapon.ItemName == requiredKey.ItemName)
        {
            equipment.DestroyCurrentlyInHand();
            OnCorrectKey?.Invoke();
            return;
        }

        OnWrongKey?.Invoke();
    }
}
