using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    public int maxHealth;
    public int health;

    private void Start()
    {
        health = maxHealth;
    }
}
