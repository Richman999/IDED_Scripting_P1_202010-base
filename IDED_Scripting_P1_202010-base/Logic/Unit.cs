using System;
namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Unit
    {
        public int BaseAtk { get; protected set; }
        public int BaseDef { get; protected set; }
        public int BaseSpd { get; protected set; }

        public int MoveRange { get; protected set; }
        public int AtkRange { get; protected set; }

        public float BaseAtkAdd { get; protected set; }
        public float BaseDefAdd { get; protected set; }
        public float BaseSpdAdd { get; protected set; }

        public float Attack { get; protected set; }
        public float Defense { get; protected set; }
        public float Speed { get; protected set; }

        protected Position CurrentPosition;
        Random randomice = new Random();
        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            if (_atk < 0)
            {
                BaseAtk = 0;
            }if (_atk >255)
            {
                BaseAtk = 255;
            }
            else
            {
                BaseAtk = _atk;
            }
            if(_def < 0)
            {
                BaseDef = 0;
            }if(_def > 255)
            {

                BaseDef = 255;
            }
            else
            {
                BaseDef = _def;
            }
            if(_spd< 0)
            {
                BaseSpd = 0;
            }
            if (_spd > 255)
            {
                BaseSpd = 255;
            }
            else
            {
                BaseSpd = _spd;
            }
            if (_moveRange <= 0)
            {
                MoveRange = 1;
            }
            if (_moveRange > 10)
            {
                MoveRange = 10;
            }
            else
            {
                MoveRange = _moveRange;
            }


            switch (_unitClass)
            {
                case EUnitClass.Imp:
                    AtkRange = 1;
                    BaseAtkAdd = 1;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    break;
                case EUnitClass.Orc:
                    AtkRange = 1;
                    BaseAtkAdd = 4;
                    BaseDefAdd = 2;
                    BaseSpdAdd = -2;
                    break;
                case EUnitClass.Dragon:
                    BaseAtkAdd = 5;
                    BaseDefAdd = 3;
                    BaseSpdAdd = 2;
                    AtkRange = 5;
                    break;
            }

            int rnd1 = randomice.Next();
            int rnd2 = randomice.Next();

            CurrentPosition = new Position(rnd1,rnd2);

            Attack = (BaseAtk + ((BaseAtk / 100 ) *BaseAtkAdd));
            Defense = (BaseDef + ((BaseDef / 100 ) *BaseDefAdd));
            Speed = (BaseSpd + ((BaseSpd / 100 ) *BaseSpdAdd));

            if(Attack < 255)
            {
                Attack = 255;
            }
            if(Defense < 255)
            {
                Defense = 255;
            }
            if(Speed < 255)
            {
                Speed = 255;
            }
        }

        public virtual bool Interact(Unit otherUnit)
        {
            bool yes = false;
            switch (UnitClass)
            {
                case EUnitClass.Squire:
                    if (otherUnit.UnitClass != EUnitClass.Villager)
                    {
                        yes = true;
                    }
                    break;
                case EUnitClass.Soldier:
                    if (otherUnit.UnitClass != EUnitClass.Villager)
                    {
                        yes = true;
                    }
                    break;
                case EUnitClass.Ranger:
                    if (otherUnit.UnitClass != EUnitClass.Mage || otherUnit.UnitClass != EUnitClass.Dragon)
                    {
                        yes = true;
                    }
                    break;
                case EUnitClass.Mage:
                    if (otherUnit.UnitClass != EUnitClass.Mage)
                    {
                        yes = true;
                    }
                    break;
                case EUnitClass.Imp:
                    if (otherUnit.UnitClass != EUnitClass.Dragon)
                    {
                        yes = true;
                    }
                    break;
                case EUnitClass.Orc:
                    if (otherUnit.UnitClass != EUnitClass.Dragon)
                    {
                        yes = true;
                    }
                    break;
                case EUnitClass.Dragon:
                    yes = true;
                    break;
            }
            return yes;
        }

        public virtual bool Interact(Prop prop)
        {
            bool yes = false;
            if (UnitClass == EUnitClass.Villager)
            {

                switch (prop.PropType)
                {
                    case EPropType.Chest:
                        yes = true;
                        break;
                    case EPropType.Obstacle:
                        yes = true;
                        break;
                    case EPropType.Trap:
                        yes = true;
                        break;
                    case EPropType.Forage:
                        yes = true;
                        break;
                }
            }
            return yes;
        }


        public bool Move(Position targetPosition)
        {
            bool yes = false;
            int comparacionX;
            int comparacionY;
            int normalImproX;
            int normalImproY;

            if (targetPosition.y == CurrentPosition.y || targetPosition.x != CurrentPosition.x)
            {
                if (targetPosition.x >= 0)
                {
                    normalImproX = targetPosition.x * -1;
                }
                else
                {
                    normalImproX = targetPosition.x;
                }
                comparacionX = (normalImproX - CurrentPosition.x);
                if (comparacionX == MoveRange || comparacionX > MoveRange)
                {
                    yes = true;
                    CurrentPosition.x = targetPosition.x;
                }
            }if (targetPosition.x == CurrentPosition.x || targetPosition.y != CurrentPosition.y)
            {
                if (targetPosition.y >= 0)
                {
                    normalImproY = targetPosition.y * -1;
                }
                else
                {
                    normalImproY = targetPosition.y;
                }
                comparacionY = (normalImproY - CurrentPosition.y);
                if (comparacionY == MoveRange || comparacionY > MoveRange)
                {
                    yes = true;
                    CurrentPosition.y = targetPosition.y;
                }                                                                               //Creo que me pegue la enredada del año y no necesitaba la primera parte, pero lo dejo por si algo
            }if(targetPosition.x != CurrentPosition.x && targetPosition.y != CurrentPosition.y)
            {
                if (targetPosition.y >= 0)
                {
                    normalImproY = targetPosition.y * -1;
                }
                else
                {
                    normalImproY = targetPosition.y;
                }
                if (targetPosition.x >= 0)
                {
                    normalImproX = targetPosition.x * -1;
                }else
                {
                    normalImproX = targetPosition.x;
                }
                comparacionY = (normalImproY - CurrentPosition.y);
                comparacionX = (normalImproX - CurrentPosition.x);
                if (comparacionY >= MoveRange && comparacionX <= MoveRange)
                {
                    yes = true;
                    CurrentPosition.y = targetPosition.y;
                    CurrentPosition.x = targetPosition.x;
                }
            }

            return yes;
        }
    }
}