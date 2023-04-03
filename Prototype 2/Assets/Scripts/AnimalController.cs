using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public int CurrentHunger { get { return currentHunger; } }
    public int maxHunger;
    public HungerBar hungerBar;
    private int currentHunger;

    // Start is called before the first frame update
    void Start()
    {
        currentHunger = maxHunger;
        hungerBar.SetMaxHunger(maxHunger);
    }

    // Update is called once per frame
    public void DecreaseHunger(int hungerToDecrease)
    {
        var decreasedHunger = currentHunger - hungerToDecrease;

        currentHunger = decreasedHunger;
        hungerBar.SetHunger(decreasedHunger);
    }
}
