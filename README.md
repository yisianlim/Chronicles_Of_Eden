# LimYiSian_AngeloJonesRhys_ChroniclesOfEden_P2

## Outline
The player progesses through our prototype by solving various problems in sequence that will each make the next part of the map accessible.
The problems invlove using equipable items to both manipulate the environment, as well as leverage behaviors of enemies.

## Imported Assets
Explosion Effect: https://assetstore.unity.com/packages/essentials/asset-packs/unity-particle-pack-73777

## How to Play
### Running
The game should just be able to be run my opening the .exe file on Windows and .app file on Mac.

### Controls
WASD to move.
Right click to attack with sword.
Left Click to use currenly equiped item.
E to pickup Item.
1 - 9 to equip corresponding item in items slot.

### Progression
1) Find the box of bombs - interact with it to pick it up. (You may need to fight some enemies to get to it.)
2) Use a bomb against the wooden wall to destory it.
3) There will now be too many enemies to fight - make them run away by throwing bombs.
4) Go through the gate - it will close behind you.
5) Head to where there is a closed gate, and an enemy on a ledge.
6) Throw the a bomb at the enemy and it will run backwards towards the switch, and open the gate.
END OF PROTOTYPE


## Most Challenging Parts
### Rhys
The behavior of the the enemies provided the most interesting challenge. It was not just enough to have them move directly away from the target, as that direction may have an obstacle in the way. I had to utilised raycasting to determine if the most direct direction was the best direction, and then find the next best direction if that was not the case. What it came down to was determing which direction would get NPC the furthest away from the target.
