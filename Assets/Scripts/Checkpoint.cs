using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private DiceRoll diceRoll = DiceRoll.D6;
    private DiceRollSystem system = new();

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            var result = system.Roll(diceRoll);
            Debug.Log(result);
        }
    }
}