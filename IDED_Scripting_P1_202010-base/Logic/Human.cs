namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {

            if(_atk >= 255)
            {
                _atk = 255;
            }
            if(_def >= 255)
            {
                _def = 255;
            }
            if(_spd >= 255)
            {
                _spd = 255;
            }
            switch (_unitClass)
            {
                case EUnitClass.Villager:
                    UnitClass = _unitClass;
                    BaseAtk = 0;
                    BaseDef = 0;
                    BaseSpd = _spd;
                    BaseAtkAdd = 0;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    break;
                case EUnitClass.Squire:
                    UnitClass = _unitClass;
                    AtkRange = 1;
                    BaseAtk = _atk;
                    BaseDef = _def;
                    BaseSpd = _spd;
                    BaseAtkAdd = 2;
                    BaseDefAdd = 1;
                    BaseSpdAdd = 0;
                    break;
                case EUnitClass.Soldier:
                    UnitClass = _unitClass;
                    AtkRange = 1;
                    BaseAtk = _atk;
                    BaseDef = _def;
                    BaseSpd = _spd;
                    BaseAtkAdd = 3;
                    BaseDefAdd = 2;
                    BaseSpdAdd = 1;
                    break;
                case EUnitClass.Ranger:
                    UnitClass = _unitClass;
                    AtkRange = 3;
                    BaseAtk = _atk;
                    BaseDef = _def;
                    BaseSpd = _spd;
                    BaseAtkAdd = 1;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 3;
                    break;
                case EUnitClass.Mage:
                    UnitClass = _unitClass;
                    AtkRange = 3;
                    BaseAtk = _atk;
                    BaseDef = _def;
                    BaseSpd = _spd;
                    BaseAtkAdd = 3;
                    BaseDefAdd = 1;
                    BaseSpdAdd = -1;
                    break;
                case EUnitClass.Imp:
                    _unitClass = EUnitClass.Villager;
                    break;
                case EUnitClass.Orc:
                    _unitClass = EUnitClass.Villager;
                    break;
                case EUnitClass.Dragon:
                    _unitClass = EUnitClass.Villager;
                    break;
                default:
                    _unitClass = EUnitClass.Villager;
                    break;
            }
            if(_potential >= 10)
            {
                _potential = 10;
            }else
            {
                Potential = _potential;
            }

            Attack = CalculoPorcentualEstadistico(BaseAtk, BaseAtkAdd);
            Defense = CalculoPorcentualEstadistico(BaseDef, BaseDefAdd);
            Speed = CalculoPorcentualEstadistico(BaseSpd, BaseSpdAdd);

        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            if(UnitClass == EUnitClass.Squire && newClass == EUnitClass.Soldier)
            {
                UnitClass = newClass;
            }
            if (UnitClass == EUnitClass.Ranger && newClass == EUnitClass.Mage)
            {
                UnitClass = newClass;
            }
            return false;
        }
        public override bool Interact(Prop prop)
        {
            if (UnitClass == EUnitClass.Villager)
            {

                return true;
            }
            else
            {
                return false;
            }

        }
    }
}