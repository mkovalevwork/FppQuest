using UnityEngine;

public class DoorHandler : MonoBehaviour
{
    [SerializeField] private int numberOfDoors;
    private int activeNumberOfCorrectDoors;

    [SerializeField] private GameObject winTextGO;

    public void AddCorrectDoor()
    {
        activeNumberOfCorrectDoors++;
        if (activeNumberOfCorrectDoors >= numberOfDoors )
        {
            winTextGO.SetActive(true);
        }
    }
}
