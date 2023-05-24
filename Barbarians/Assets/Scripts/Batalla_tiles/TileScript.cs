using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using Unity.VisualScripting;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    [SerializeField]private GameObject unit;
    [SerializeField]private int tileposx;
    [SerializeField]private int tileposy;
    [SerializeField]private GameObject target = null;
    private readonly KeyValuePair<int, int> FORWARD = new KeyValuePair<int, int>(1, 0);
    private readonly KeyValuePair<int, int> BACKWARD = new KeyValuePair<int, int>(-1, 0);
    private readonly KeyValuePair<int, int> UPWARD = new KeyValuePair<int, int>(0, 1);
    private readonly KeyValuePair<int, int> DOWNWARD = new KeyValuePair<int, int>(0, -1);
    private readonly KeyValuePair<int, int> UPFORWARD = new KeyValuePair<int, int>(1, 1);
    private readonly KeyValuePair<int, int> UPBACKWARD = new KeyValuePair<int, int>(-1, 1);
    private readonly KeyValuePair<int, int> DOWNFORWARD = new KeyValuePair<int, int>(1, -1);
    private readonly KeyValuePair<int, int> DOWNBACKWARD = new KeyValuePair<int, int>(-1, -1);

    private void OnEnable()
    {
        GameObject instanceUnit = null;
        if (unit != null)
        {
            instanceUnit = Instantiate(unit,new Vector3(transform.position.x,transform.position.y,(transform.position.z-((float)tileposy/10))), Quaternion.identity);
            instanceUnit.transform.parent = gameObject.transform;
            if (instanceUnit.CompareTag("demon"))
            {
                //Debug.Log("demonio a llegado a la casilla " + tileposx + "," + tileposy);

                BattleController.instance.DemonTiles.Add(TileController.instance.Tiles[tileposx, tileposy]);
            }
            else if (instanceUnit.CompareTag("barbarian"))
            {
                //Debug.Log("humano a llegado a la casilla " + tileposx + "," + tileposy);
                BattleController.instance.HumanTiles.Add(TileController.instance.Tiles[tileposx, tileposy]);
            }
        }
    }
    private void OnDisable()
    {
        if (unit != null)
        {
            if (unit.CompareTag("demon"))
            {
                //Debug.Log("demonio a abandonado la casilla " + tileposx + "," + tileposy);
                BattleController.instance.DemonTiles.Remove(TileController.instance.Tiles[tileposx, tileposy]);
            }
            else if (unit.CompareTag("barbarian"))
            {
                //Debug.Log("humano a abandonado la casilla " + tileposx + "," + tileposy);
                BattleController.instance.HumanTiles.Remove(TileController.instance.Tiles[tileposx, tileposy]);
            }
            Destroy(gameObject.transform.GetChild(0).gameObject);
            unit = null;
        }
    }
    public void Attack()
    {
        Debug.Log("el target tiene "+ target.GetComponent<TileScript>().unit.GetComponent<Unit>().Health + " de vida");
        int finaldmg;
        finaldmg = unit.GetComponent<Unit>().Damage - target.GetComponent<TileScript>().unit.GetComponent<Unit>().Armor;
        if(finaldmg < 1) {finaldmg = 1;}
        if (unit.CompareTag("demon") && unit.name == "Diablillo")
        {
            //unit.GetComponent<Imp>().anim.SetTrigger("atacando");
        }
        else if (unit.CompareTag("barbarian") && unit.name == "Guerrero")
        {
            //unit.GetComponent<Warrior>().anim.SetTrigger("atacando");
        }
        Debug.Log(unit.name + "ha ataca a " + target.GetComponent<TileScript>().unit.name + " causando " + finaldmg + " de daño, y tiene " + target.GetComponent<TileScript>().unit.GetComponent<Unit>().Health + "de vida");
        target.GetComponent<TileScript>().unit.GetComponent<Unit>().Health -= finaldmg;
        Debug.Log(target.GetComponent<TileScript>().unit.name + " se queda con " + target.GetComponent<TileScript>().unit.GetComponent<Unit>().Health + " de vida");
        if(target.GetComponent<TileScript>().unit.GetComponent<Unit>().Health < 1)
        {
            target.GetComponent<TileScript>().enabled = false;
        }
    }
    private bool CheckEnemyInTile(KeyValuePair<int,int> position)
    {
        try
        {
            if (TileController.instance.Tiles[tileposx + position.Key, Tileposy + position.Value].GetComponent<TileScript>().unit != null &&
                    !TileController.instance.Tiles[tileposx + position.Key, Tileposy + position.Value].GetComponent<TileScript>().unit.CompareTag(unit.tag))
            {
                target = TileController.instance.Tiles[tileposx + position.Key, Tileposy + position.Value];
                return true;
            }
            else return false;
        }
        catch
        {
            return false;
        }
    }
    public bool CheckEnemyinRange()
    {
        if (Random.Range(0f, 1f) > 0.5f)
        {
            if (CheckEnemyInTile(FORWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(UPFORWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(UPWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(UPBACKWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(BACKWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(DOWNBACKWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(DOWNWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(DOWNFORWARD))
            {
                return true;
            }
            else return false;

        }
        else
        {
            if (CheckEnemyInTile(FORWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(DOWNFORWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(DOWNWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(DOWNBACKWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(BACKWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(UPBACKWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(UPWARD))
            {
                return true;
            }
            if (CheckEnemyInTile(UPFORWARD))
            {
                return true;
            }
            else return false;
        }
    }
    public KeyValuePair<int,int> GetMove()
    {
        int xj = target.GetComponent<TileScript>().Tileposx;
        int yj = target.GetComponent<TileScript>().Tileposy;

        int x;
        int y;

        if (xj == tileposx)
        {
            x = 0;
        }
        else if(xj > tileposx)
        {
            x = 1;
        }
        else
        {
            x = -1;
        }
        if (yj == tileposy)
        {
            y = 0;
        }
        else if (yj > tileposy)
        {
            y = 1;
        }
        else
        {
            y = -1;
        }
        return new KeyValuePair<int, int>(x, y);
    } 
    public void GetTarget(List<GameObject> enemies)
    {
        int distancia = -1;
        KeyValuePair<int, int> position1;
        KeyValuePair<int, int> position2;
        position1 = new KeyValuePair<int, int>(
            GetComponentInParent<TileScript>().Tileposx,
            GetComponentInParent<TileScript>().Tileposy
            );

        foreach (GameObject enemy in enemies)
        {
            if (distancia < 0)
            {
                target = enemy;
                position2 = new KeyValuePair<int, int>(
                    enemy.GetComponentInParent<TileScript>().Tileposx,
                    enemy.GetComponentInParent<TileScript>().Tileposx);
                distancia = Chebyshev(position1, position2);
            }
            else
            {
                position2 = new KeyValuePair<int, int>(
                    enemy.GetComponentInParent<TileScript>().Tileposx,
                    enemy.GetComponentInParent<TileScript>().Tileposx);
                if (distancia < Chebyshev(position1, position2))
                {
                    target = enemy;
                    distancia = Chebyshev(position1, position2);
                }
            }
        }
        Debug.Log(unit.name + " tiene como objetivo " + target.GetComponent<TileScript>().Tileposx + "," + target.GetComponent<TileScript>().Tileposy);
    }
    public int Chebyshev(KeyValuePair<int, int> position1, KeyValuePair<int, int> position2)
    {
        return Mathf.Max(Mathf.Abs((position2.Key - position1.Key)), Mathf.Abs((position2.Value - position1.Value)));
    }
    public void MoveTo(KeyValuePair<int, int> coords)
    {
        KeyValuePair<int, int> _coords;
        if (CheckMove(coords))
        {
            //Debug.Log("soy " + unit.name + " y me muevo: " + coords.Key + "," + coords.Value);
            Move(coords);
        }
        else if (IsStraightMove(coords))
        {
            if(coords.Key == 0)
            {
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    _coords = new(coords.Key + 1, coords.Value);
                    if (CheckMove(_coords))
                    {
                        //Debug.Log("soy " + unit.name + " y me muevo: " + _coords.Key + "," + _coords.Value);
                        Move(_coords);
                    }
                    else
                    {
                        _coords = new(coords.Key - 1, coords.Value);
                        if (CheckMove(_coords))
                        {
                            //Debug.Log("soy " + unit.name + " y me muevo: " + _coords.Key + "," + _coords.Value);
                            Move(_coords);
                        }
                    }
                }
                else
                {
                    _coords = new(coords.Key -1, coords.Value);
                    if (CheckMove(_coords))
                    {
                        //Debug.Log("soy " + unit.name + " y me muevo: " + _coords.Key + "," + _coords.Value);
                        Move(_coords);
                    }
                    else
                    {
                        _coords = new(coords.Key +1, coords.Value);
                        if (CheckMove(_coords))
                        {
                            //Debug.Log("soy " + unit.name + " y me muevo: " + _coords.Key + "," + _coords.Value);
                            Move(_coords);
                        }
                    }
                }
            }
            else
            {
                if (Random.Range(0f, 1f) > 0.5f)
                {
                    _coords = new(coords.Key, coords.Value + 1);
                    if (CheckMove(_coords))
                    {
                        //Debug.Log("soy " + unit.name + " y me muevo: " +_coords.Key + "," + _coords.Value);
                        Move(_coords);
                    }
                    else
                    {
                        _coords = new(coords.Key, coords.Value - 1);
                        if (CheckMove(_coords))
                        {
                            //Debug.Log("soy " + unit.name + " y me muevo: " +_coords.Key + "," + _coords.Value);
                            Move(_coords);
                        }
                    }
                }
                else
                {
                    _coords = new(coords.Key, coords.Value - 1);
                    if (CheckMove(_coords))
                    {
                        //Debug.Log("soy " + unit.name + " y me muevo: " +_coords.Key + "," + _coords.Value);
                        Move(_coords);
                    }
                    else
                    {
                        _coords = new(coords.Key, coords.Value + 1);
                        if (CheckMove(_coords))
                        {
                            //Debug.Log("soy " + unit.name + " y me muevo: " +_coords.Key + "," + _coords.Value);
                            Move(_coords);
                        }
                    }
                }
            }
        }
        else
        {
            if (Random.Range(0f, 1f) > 0.5f)
            {
                _coords = new(0, coords.Value);
                if (CheckMove(_coords))
                {
                    //Debug.Log("soy " + unit.name + " y me muevo: " + _coords.Key + "," + _coords.Value);
                    Move(_coords);
                }
                else
                {
                    _coords = new(coords.Key, 0);
                    if (CheckMove(_coords))
                    {
                        //Debug.Log("soy " + unit.name + " y me muevo: " + _coords.Key + "," + _coords.Value);
                        Move(_coords);
                    }
                }
            }
            else
            {
                _coords = new(coords.Key, 0);
                if (CheckMove(_coords))
                {
                    //Debug.Log("soy " + unit.name + " y me muevo: " + _coords.Key + "," + _coords.Value);
                    Move(_coords);
                }
                else
                {
                    _coords = new(0, coords.Value);
                    if (CheckMove(_coords))
                    {
                        //Debug.Log("soy " + unit.name + " y me muevo: " + _coords.Key + "," + _coords.Value);
                        Move(_coords);
                    }
                }
            }
        }
    }
    private bool CheckMove(KeyValuePair<int,int> coords)
    {
        try
        {
            if (TileController.instance.Tiles[tileposx+coords.Key, tileposy+coords.Value].GetComponent<TileScript>().enabled)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }
    private bool IsStraightMove(KeyValuePair<int,int> coords)
    {
        if((Mathf.Abs(coords.Key) + Mathf.Abs(coords.Value)) == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Move(KeyValuePair<int, int> coords)
    {
        
        TileController.instance.Tiles[tileposx + coords.Key, tileposy + coords.Value].GetComponent<TileScript>().Unit = unit;
        TileController.instance.Tiles[tileposx + coords.Key, tileposy + coords.Value].GetComponent<TileScript>().enabled = true;
        gameObject.GetComponent<TileScript>().enabled = false;
    }
    public int Tileposx
    {
        get { return tileposx; }
        set { tileposx = value; }
    }
    public int Tileposy
    {
        get { return tileposy; }
        set { tileposy = value; }
    }
    public GameObject Unit
    {
        get { return unit; }
        set { unit = value; }
    }
    public GameObject Target
    {
        get { return target; }
        set { target = value; }
    }
}
