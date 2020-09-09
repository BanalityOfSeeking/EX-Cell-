using Game.Components;
using Game.Entities;
using PubSub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game.Components
{
    public class BodySystem 
    {
        public TextBodyTemplate TextBody { get; internal set; }

        public BodySystem() 
        {
            FillBody();
        }

        public HeadComponent Head { get; internal set; }
        public ChestComponent Chest { get; internal set; }
        public LeftArmComponent LeftArm { get; internal set; }
        public RightArmComponent RightArm { get; internal set; }
        public LeftLegComponent LeftLeg { get; internal set; }
        public RightLegComponent RightLeg { get; internal set; }

        public void FillBody()
        {
            Hub.Default.Subscribe<HeadComponent>(head => Head = head);
            Hub.Default.Subscribe<ChestComponent>(chest => Chest = chest);
            Hub.Default.Subscribe<LeftArmComponent>(lefty => LeftArm = lefty);
            Hub.Default.Subscribe<RightArmComponent>(righty => RightArm = righty);
            Hub.Default.Subscribe<LeftLegComponent>(lleg => LeftLeg = lleg);
            Hub.Default.Subscribe<RightLegComponent>(rleg => RightLeg = rleg);
        }
  
    }
}