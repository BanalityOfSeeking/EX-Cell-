			
Goals & Todo:
Add ArchType ComponentRoleManager, integrate with ComponentManager(remove base ComponentManager)

Work out how a Camera could work in a console game.
(double buffer => render world => localize view of world via viewport concept 

Reduce Code copying if functionality needed 2 times write in a function. 

Understand how I can group and optimize the bad code and make better good code design choices. 


			Game Start Flow

Character Selection screen => Character Stat Screen => World Start 
=> Request Entities => Add ArchType To Entities => Add components to entities (ComponentArchTypeManager)
=> fill Components Bodies (BodyArchSystem) => fill Weapons Components (WeaponArchSystem) => LootSystem
=> fill environment => place player & monster (init IOSystem , Init Camera / ViewPort (system) (x,y, fixed z)no clue yet ) => 
?? more stuff... yet to think of.. 
 
initialization complete => Stage Start
                              

StageSystem(Requirements for ECS flow from here) will be Main Game loop the main loop area.