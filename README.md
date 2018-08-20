# LimYiSian_AngeloJonesRhys_ChroniclesOfEden_P2

## Outline
The player progesses through our prototype by solving various problems in sequence that will each make the next part of the map accessible.
The problems invlove using equipable items to both manipulate the environment, as well as leverage behaviors of enemies.

## Imported Assets
Explosion Effect: https://assetstore.unity.com/packages/essentials/asset-packs/unity-particle-pack-73777

## Most Challenging Parts
### Rhys
The behavior of the the enemies provided the most interesting challenge. It was not just enough to have them move directly away from the target, as that direction may have an obstacle in the way. I had to utilised raycasting to determine if the most direct direction was the best direction, and then find the next best direction if that was not the case. What it came down to was determing which direction would get NPC the furthest away from the target.
