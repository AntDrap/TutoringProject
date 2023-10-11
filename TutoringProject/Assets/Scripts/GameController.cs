using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int BoltAmount;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UIBehavior.instance.UpdateBolts(BoltAmount);
    }

    public void ChangeBoltAmount(int amount)
    {
        BoltAmount = Mathf.Max(0, (BoltAmount + amount));
        UIBehavior.instance.UpdateBolts(BoltAmount);
    }
}