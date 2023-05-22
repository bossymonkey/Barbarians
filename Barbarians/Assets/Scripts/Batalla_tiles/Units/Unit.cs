using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float health;
    [SerializeField] private readonly string unitType;
    [SerializeField] private float speed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;
    [SerializeField] private float armor;
    KeyValuePair<int, int> TilePosition;

    public void Start()
    {
        health = maxHealth;
    }
    public void StopTranslate()
    {
        transform.Translate(0, 0, 0);
    }
    public void StopMovingTowards()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    public float Health
    {
        get { return health; }
        set { health = value; }
    }
    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    public float Damage
    {
        get { return damage; }
        set { damage = value; }
    }
    public float Armor
    {
        get { return armor; }
        set { armor = value; }
    }
}
