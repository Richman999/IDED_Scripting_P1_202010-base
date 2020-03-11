namespace IDED_Scripting_P1_202010_base.Logic
{
    public class Human : Unit
    {
        public float Potential { get; set; }

        public Human(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange, float _potential)
            : base(_unitClass, _atk, _def, _spd, _moveRange)
        {
            Potential = _potential;
            switch (_unitClass)
            {
                case EUnitClass.Villager:
                    BaseAtk = 0;
                    BaseDef = 0;
                    BaseSpd = 0;
                    BaseAtkAdd = 0;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    AtkRange = 0;
                    break;
                case EUnitClass.Squire:
                    BaseAtkAdd = 2;
                    BaseDefAdd = 1;
                    BaseSpdAdd = 0;
                    AtkRange = 1;
                    break;
                case EUnitClass.Soldier:
                    BaseAtkAdd = 3;
                    BaseDefAdd = 2;
                    BaseSpdAdd = 1;
                    AtkRange = 1;
                    break;
                case EUnitClass.Ranger:
                    BaseAtkAdd = 1;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 3;
                    AtkRange = 3;
                    break;
                case EUnitClass.Mage:
                    BaseAtkAdd = 3;
                    BaseDefAdd = 1;
                    BaseSpdAdd = -1;
                    AtkRange = 3;
                    break;
                case EUnitClass.Imp:
                    UnitClass = EUnitClass.Villager;
                    BaseAtk = 0;
                    BaseDef = 0;
                    BaseSpd = 0;
                    BaseAtkAdd = 0;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    AtkRange = 0;
                    break;
                case EUnitClass.Orc:
                    UnitClass = EUnitClass.Villager;
                    BaseAtk = 0;
                    BaseDef = 0;
                    BaseSpd = 0;
                    BaseAtkAdd = 0;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    AtkRange = 0;
                    break;
                case EUnitClass.Dragon:
                    UnitClass = EUnitClass.Villager;
                    BaseAtk = 0;
                    BaseDef = 0;
                    BaseSpd = 0;
                    BaseAtkAdd = 0;
                    BaseDefAdd = 0;
                    BaseSpdAdd = 0;
                    AtkRange = 0;
                    break;
            }

            Attack = (BaseAtk + ((BaseAtk / 100) * BaseAtkAdd) + (BaseAtk/100) * Potential);
            Defense = (BaseDef + ((BaseDef / 100) * BaseDefAdd)+(BaseAtk / 100) * Potential);
            Speed = (BaseSpd + ((BaseSpd / 100) * BaseSpdAdd)+(BaseAtk / 100) * Potential);

            if (Attack < 255)
            {
                Attack = 255;
            }
            if (Defense < 255)
            {
                Defense = 255;
            }
            if (Speed < 255)
            {
                Speed = 255;
            }
        }

        public virtual bool ChangeClass(EUnitClass newClass)
        {
            bool yes = false;
            switch (UnitClass)
            {
                case EUnitClass.Squire:
                    if (newClass == EUnitClass.Soldier)
                    {
                        UnitClass = newClass;
                        yes = true;
                    }
                    break;
                case EUnitClass.Soldier:
                    if (newClass == EUnitClass.Squire)
                    {
                        UnitClass = newClass;
                        yes = true;
                    }
                    break;
                case EUnitClass.Ranger:
                    if (newClass == EUnitClass.Mage)
                    {
                        UnitClass = newClass;
                        yes = true;
                    }
                    break;
                case EUnitClass.Mage:
                    if (newClass == EUnitClass.Ranger)
                    {
                        UnitClass = newClass;
                        yes = true;
                    }
                    break;
            }
            return yes;
        }
    }
}