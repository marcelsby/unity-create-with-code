using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    public int maxHunger;
    public int currentHunger;
    public HungerBar hungerBar;

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
