using System;

namespace EXCell
{
    public struct AttackEventComponent //: IAttackEventHandler
    {
        public delegate void DmgDelegate(HealthComponent sender, ref HealthComponent reciever);

        public event DmgDelegate DoDamageEvent;

        public void OnDamageEvent(HealthComponent sender, ref HealthComponent reciever)
        {
            DmgDelegate handler = DoDamageEvent;
            if (handler != null)
            {
                handler(sender, ref reciever);
            }
        }
    }
}

