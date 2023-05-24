using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int speed;
    [SerializeField] private int maxHealth;
    [SerializeField] private int damage;
    [SerializeField] private int armor;

    public void StopTranslate()
    {
        transform.Translate(0, 0, 0);
    }
    public void StopMovingTowards()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public int Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public int Armor
    {
        get { return armor; }
        set { armor = value; }
    }
}
