using Game.Components;
using System.Collections.Generic;
using System.Linq;

namespace Game.Components
{
    public class ChestComponent : IEquipment, Item, IComponentType, IChestComponent
    {
        public EquipId Id { get; set; }
        public char Item { get; set; }
        public ComponentTypes ComponentId => ComponentTypes.Chest;
    }
}
namespace Game.Systems
{
    public static class GameBodySystem
    {
        public static void RegisterBody(int entityId)
        {
            if(ComponentManager.TryGetEntityComponents(entityId, out IList<IComponentType> components))
            {
                foreach (var component in components.Where(x => x != null))
                {

                    switch (component?.ComponentId)
                    {
                        case ComponentTypes.Head:
                            {

                                ((HeadComponent)component).Id = ((HeadComponent)component).Id ?? EquipmentSystem.ApplyRule(((HeadComponent)component).Id, EquipType.Helmets);                  
                            }
                            break;
                        case ComponentTypes.LeftArm :
                            {

                                ((LeftArmComponent)component).Id = ((LeftArmComponent)component).Id ?? EquipmentSystem.ApplyRule(((LeftArmComponent)component).Id, EquipType.Weapons);
                            }
                            break;
                        case ComponentTypes.RightArm:
                            {

                                ((RightArmComponent)component).Id = ((RightArmComponent)component).Id ?? EquipmentSystem.ApplyRule(((RightArmComponent)component).Id, EquipType.Weapons);
                            }
                            break;
                        case ComponentTypes.Chest:
                            {
                                ((ChestComponent)component).Id = ((ChestComponent)component).Id ?? EquipmentSystem.ApplyRule(((ChestComponent)component).Id, EquipType.Armors);
                                    
                            }
                            break;
                        case ComponentTypes.LeftLeg:
                            {

                                ((LeftLegComponent)component).Id = ((LeftLegComponent)component).Id ?? EquipmentSystem.ApplyRule(((LeftLegComponent)component).Id, EquipType.LegGuards);

                            }
                            break;
                        case ComponentTypes.RightLeg:
                            {
                               ((RightLegComponent)component).Id = ((RightLegComponent)component).Id ?? EquipmentSystem.ApplyRule(((RightLegComponent)component).Id, EquipType.LegGuards);
                            }
                            break;
                        default: break;
                    }
                }
            }
        }
    }
}