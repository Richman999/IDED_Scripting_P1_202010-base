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

        public EUnitClass UnitClass { get; protected set; }

        public Unit(EUnitClass _unitClass, int _atk, int _def, int _spd, int _moveRange)
        {
            UnitClass = _unitClass;
            BaseAtk = _atk;
            BaseDef = _def;
            BaseSpd = _spd;
            MoveRange = _moveRange;
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
                    AtkRange = 5;
                    BaseAtkAdd = 5;
                    BaseDefAdd = 3;
                    BaseSpdAdd = 2;
                    break;
            }
            Attack = CalculoPorcentualEstadistico(BaseAtk, BaseAtkAdd);
            Defense = CalculoPorcentualEstadistico(BaseDef, BaseDefAdd);
            Speed = CalculoPorcentualEstadistico(BaseSpd, BaseSpdAdd);
        }

        public virtual bool Interact(Unit otherUnit)
        {
            return false;
        }

        public virtual bool Interact(Prop prop) => false;

        public bool Move(Position targetPosition) => false;

        public float CalculoPorcentualEstadistico(int bas, float porcent)
        {
            float a;
            float sumPor;
            sumPor = ((bas / 100) * porcent);
            a = bas + sumPor;
            if(a <= 255)
            {
                return a;
            }if(a >= 255)
            {
                return 255;
            }else
            {
                return 0;
            }

        }
        public float CalculoPorcentualEstadistico(int bas, float porcent, float potencial)
        {
            float a;
            float sumPor;
            float sumPot;
            sumPot = ((bas / 100) * potencial);
            sumPor = ((bas / 100) * porcent);
            a = bas + sumPor + sumPot;
            if (a <= 255)
            {
                return a;
            }
            if (a >= 255)
            {
                return 255;
            }
            else
            {
                return 0;
            }
        }
    }
}