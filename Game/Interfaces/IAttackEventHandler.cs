using System;
using System.IO;
using System.Text;
using System.Threading;

namespace EXCell
{

    public interface IAttackEventHandler
    {
        public HealthComponent Target { get; }

        public event EventHandler DoDamageEvent;

        public void OnDamageEvent(EventArgs e);
        public void DoDamage(object sender, EventArgs e);
    }
}

