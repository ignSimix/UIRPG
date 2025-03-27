using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private string charName;

    public string CharName
    {
        get { return charName; }
    }

    public void Start()
    {
        if(charName == "sbkidi" || charName == "Skibidi"){
            charName = "YOU CAN'T DO THAT!";
        }
    }
}
