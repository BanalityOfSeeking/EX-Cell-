			
Goals & Todo:
Add ArchType ComponentRoleManager, integrate with ComponentManager(remove base ComponentManager)

Work out how a Camera could work in a console game.
(double buffer => render world => localize view of world via viewport concept 

Reduce Code copying if functionality needed 2 times write in a function. 

Understand how I can group and optimize the bad code and make better good code design choices. 


			Game Start Flow

			*Initialize Resources*
init I/O System
Character Selection screen => Character Stat Screen => World Start => Init Stage System =>
=> Request Entities => Assign ArchType To Entities => Assign this entities ArchType to its base components 
(ComponentArchTypeManager) <=set loot  here for monsters, no loot system except for exchange or data.
 => place player & monsters => generate scene around player and monster locations
=> AI?? | IO => animate Bodies (BodyAnimationSystem) 
?? more stuff... yet to think of.. 
 
initialization complete => Stage restart at animate bodies.
                              

StageSystem(Requirements for ECS flow from here) will be Main Game loop the main loop area.