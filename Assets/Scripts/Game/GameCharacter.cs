using UnityEngine;
using System.Collections;

public class GameCharacter {


    private GameItem _leftLeg;
    private GameItem _rightLeg;
    private GameItem _leftArm;
    private GameItem _rightArm;
    private GameAttributes _attributes;
    private GameAttributes _base;
    private GameAttributes _damage;
    private GameItem[] _itens = new GameItem[4];

    private GameSkill[] _attacks = new GameSkill[4];
    private GameSkill[] _specials = new GameSkill[4];

    private bool _ready;
    private float _timer;

    private string _name;
    private int _sprite;
    private Vector2 _position;



    public bool EquipItem(GameItem itm)
    {
        for (int i = 0; i < 4; i++)
        {
            if (_itens[i] == null)
            {
                _itens[i] = itm;
                GlobalItens.RemoveFromInventory(itm);
                return true;
            }
        }
        return false;

    }
    
    public void EquipEquipment(GameItem itm, EquipmentType type)
    {
        switch (type)
        {
            case EquipmentType.LeftArm:
                _leftArm = itm;
                _attacks[0] = itm.attack;
                _specials[0] = itm.special;

                break;
            case EquipmentType.RightArm:
                _rightArm = itm;
                _attacks[1] = itm.attack;
                _specials[1] = itm.special;

                break;
            case EquipmentType.LeftLeg:
                _leftLeg = itm;
                _attacks[2] = itm.attack;
                _specials[2] = itm.special;

                break;
            case EquipmentType.RightLeg:
                _rightLeg = itm;
                _attacks[3] = itm.attack;
                _specials[3] = itm.special;

                break;
        }

        GlobalItens.RemoveFromInventory(itm);
    }

    public void RemoveEquippedEquipment(EquipmentType pos)
    {
        switch (pos)
        {

            case EquipmentType.LeftArm:

                GlobalItens.AddToInventory(_leftArm);
                _leftArm = null;
                _attacks[0] = null;
                _specials[0] = null;

                break;
            case EquipmentType.RightArm:

                GlobalItens.AddToInventory(_rightArm);
                _rightArm = null;
                _attacks[1] = null;
                _specials[1] = null;

                break;
            case EquipmentType.LeftLeg:

                GlobalItens.AddToInventory(_leftLeg);
                _leftLeg = null;
                _attacks[2] = null;
                _specials[2] = null;

                break;
            case EquipmentType.RightLeg:
                
                GlobalItens.AddToInventory(_rightLeg);
                _rightLeg = null;
                _attacks[3] = null;
                _specials[3] = null;

                break;
        }
    }

    public void RemoveEquippedItem(GameItem itm, int pos)
    {

        if (_itens[pos] != null && _itens[pos] == itm)
        {
            GlobalItens.AddToInventory(_itens[pos]);
            _itens[pos] = null;
        }
    }

    public void RestartTimer()
    {
        _ready = false;
        _timer = 0;
    }

    public bool UpdateTimer()
    {
        if (_ready)
        {
            return true;
        }

        _timer += Time.deltaTime;
        if (_timer > _attributes.time)
        {
            _timer = _attributes.time;
            _ready = true;
            return true;
        }

        return false;
    }


    public Vector2 position
    {
        get { return _position; }
        set { _position = value; }
    }
    public int sprite
    {
        get { return _sprite; }
        set { _sprite = value; }
    }

    public string name
    {
        get { return _name; }
        set { _name = value; }
    }
    public bool ready
    {
        get { return _ready; }
        set { _ready = value; }
    }
    public float timer
    {
        get { return _timer; }
        set { _timer = value; }
    }
    public GameSkill[] attacks
    {
        get { return _attacks; }
        set { _attacks = value; }
    }
    public GameSkill[] specials
    {
        get { return _specials; }
        set { _specials = value; }
    }
    public GameItem[] itens
    {
        get { return _itens; }
        set { _itens = value; }
    }
    public GameAttributes attributes
    {
        get { return _attributes; }
        set { _attributes = value; }
    }
    public GameItem leftLeg
    {
        get { return _leftLeg; }
        set { _leftLeg = value; }
    }
    public GameItem rightLeg
    {
        get { return _rightLeg; }
        set { _rightLeg = value; }
    }
    public GameItem leftArm
    {
        get { return _leftArm; }
        set { _leftArm = value; }
    }
    public GameItem rightArm
    {
        get { return _rightArm; }
        set { _rightArm = value; }
    }
    /**********************************************************************************************/
}
