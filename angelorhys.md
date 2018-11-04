# Rhys Angelo-Jones
**Username:** angelorhys  
**Role:** Bear  
**Primary Responsibility:** AI and Combat 


## Code Discussion
### Parts worked On
* Inventory Logic - All
* AI Framework - Most
* NPC Follow Behaviour - All
* NPC Avoid Behavior - Most
* Camera - Most
* Player Controller - Some (mainly related to combat and death)
* Player Attack Hit Detection - All
* Item Launchers - All
* Item Aimer - All
* Sound Effects - Some (Hit, death, and gate sounds) 

### Most Interesting Code and Most Proud Of
The (framework for the NPC AI)[https://github.com/yisianlim/Chronicles_Of_Eden/blob/master/Assets/Scripts/AI/NPCAI.cs]. From the begninning I wanted to make this part of the project as easy to extend as possible, to allow us to implement relatively elaborate behaviors simply. This piece of code make good use of scriptable objects to implement a strategy pattern that allows behaviors to be plugged in and swapped out quickly.

## Reflection
### What I have Learned
I was already pretty familair with Unity before this course, so I didn't learn much in the way of techncal skills. The only new Unity feature I can think of that I did learn was animation events, which I used to easily time hits with animations in combat.

I learned a bit of (kinematic physics)[https://github.com/yisianlim/Chronicles_Of_Eden/blob/master/Assets/Scripts/Util/Calculations.cs] to facilitate (item aiming)[https://github.com/yisianlim/Chronicles_Of_Eden/blob/master/Assets/Scripts/Inventory/Equipable%20Items/Aimable%20Items/RangedItemAimer.cs], which I feel could come in handy in future game development.

### Most Important Takeaway
Well written code does not necessarily equal a quality game. I know this probably sounds obvious, but I feel I spent a lot of time making the AI system as well structured as possible, but when it came to using it to create encounters in the game, it was stil difficult to make them engaging - particularly in regards to combat - something that can be achieved with much simpler code.
