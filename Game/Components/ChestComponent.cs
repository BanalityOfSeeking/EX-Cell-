using Game.Components;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace Game.Components
{
    public class ChestComponent : IEquipment, Item, IComponentType, IChestComponent
    {
        public EquipId Id { get; set; }
        public char[] Item { get; set; }
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
                                ((HeadComponent)component).Item = new char[2];
                                ((HeadComponent)component).Item[0] = '0';
                                ((HeadComponent)component).Item[1] = '\'';
                            }
                            break;
                        case ComponentTypes.LeftArm :
                            {

                                ((LeftArmComponent)component).Id = ((LeftArmComponent)component).Id ?? EquipmentSystem.ApplyRule(((LeftArmComponent)component).Id, EquipType.Weapons);
                                ((LeftArmComponent)component).Item = new char[2];
                                ((LeftArmComponent)component).Item[0] = '/';
                                ((LeftArmComponent)component).Item[1] = '|';

                            }
                            break;
                        case ComponentTypes.RightArm:
                            {

                                ((RightArmComponent)component).Id = ((RightArmComponent)component).Id ?? EquipmentSystem.ApplyRule(((RightArmComponent)component).Id, EquipType.Weapons);
                                ((RightArmComponent)component).Item = new char[2];
                                ((RightArmComponent)component).Item[0] = '\\';
                                ((RightArmComponent)component).Item[1] = '|';
                            }
                            break;
                        case ComponentTypes.Chest:
                            {
                                ((ChestComponent)component).Id = ((ChestComponent)component).Id ?? EquipmentSystem.ApplyRule(((ChestComponent)component).Id, EquipType.Armors);
                                ((ChestComponent)component).Item = new char[3];
                                ((ChestComponent)component).Item[0] = '|';
                                ((ChestComponent)component).Item[1] = '_';
                                ((ChestComponent)component).Item[2] = '|';
                            }
                            break;
                        case ComponentTypes.LeftLeg:
                            {

                                ((LeftLegComponent)component).Id = ((LeftLegComponent)component).Id ?? EquipmentSystem.ApplyRule(((LeftLegComponent)component).Id, EquipType.LegGuards);
                                ((LeftLegComponent)component).Item = new char[2];
                                ((LeftLegComponent)component).Item[0] = '/';
                                ((LeftLegComponent)component).Item[1] = '|';
                            }
                            break;
                        case ComponentTypes.RightLeg:
                            {
                                ((RightLegComponent)component).Id = ((RightLegComponent)component).Id ?? EquipmentSystem.ApplyRule(((RightLegComponent)component).Id, EquipType.LegGuards);
                                ((RightLegComponent)component).Item = new char[2];
                                ((RightLegComponent)component).Item[0] = '\\';
                                ((RightLegComponent)component).Item[1] = '|';
                            }
                            break;
                        default: break;
                    }
                }
            }
        }
    }
}