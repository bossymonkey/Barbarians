using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private float health;
    [SerializeField] private readonly string unitType;
    [SerializeField] private float speed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float damage;
    [SerializeField] private float armor;

    public void Start()
    {
        health = maxHealth;
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
    public float AttackSpeed
    {
        get { return attackSpeed; }
        set { attackSpeed = value; }
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
