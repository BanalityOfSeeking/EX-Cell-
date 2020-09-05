using System;

namespace EXCell
{
    public struct AttackEventComponent : IComponentType
    {
        public int ParentId { get; set; }
        public int ChildId { get; set; }

        public delegate void DmgDelegate(ref AttackEventComponent sender, ref HealthComponent reciever);

        public event DmgDelegate DoDamageEvent;

        public void OnDamageEvent(ref AttackEventComponent sender, ref HealthComponent reciever)
        {
            DmgDelegate handler = DoDamageEvent;
            if (handler != null)
            {
                handler(ref sender, ref reciever);
            }
        }
    }
}

