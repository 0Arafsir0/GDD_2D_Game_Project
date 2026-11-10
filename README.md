# 2D Action Platformer Game

A 2D action-platformer game developed using **Unity and C#** as part of the Game Design and Development course. The game features player movement, jumping, arrow-based combat, enemy AI, collectibles, health management, environmental hazards, and interactive gameplay mechanics.

## Game Overview

The player explores a 2D platform-based environment, fights enemies, collects gems and health items, and avoids environmental hazards. The objective is to survive, overcome enemies, and progress through the game environment.

## Features

- **Player Movement:** Horizontal movement, jumping, and directional flipping.
- **Combat System:** Arrow-based projectile attacks.
- **Enemy AI:** Enemy patrol, player detection, chasing, and attacking.
- **Health System:** Player and enemy health management.
- **Collectibles:** Gems for scoring and hearts for health recovery.
- **Environmental Hazards:** Water collision detection and player death.
- **Animation System:** Player and enemy movement, attack, hurt, and death animations.
- **Camera Effects:** Cinemachine camera shake during important gameplay events.
- **Visual Effects:** Explosion, damage indicators, and collection effects.
- **Game Over System:** Game Over screen with a restart option.

## Technologies Used

| Technology | Purpose |
|---|---|
| Unity | Game engine |
| C# | Gameplay programming |
| Unity 2D Physics | Movement and collision detection |
| Rigidbody2D | Physics-based jumping |
| Animator | Character animations |
| Unity Input System | Keyboard input |
| Cinemachine | Camera management and shake effects |
| Tilemap / 2D Assets | Environment and level design |

## Controls

| Input | Action |
|---|---|
| A / Left Arrow | Move left |
| D / Right Arrow | Move right |
| Space | Jump |
| Left Mouse Button | Attack / Shoot arrow |

## Gameplay Mechanics

### Player System
The player controller handles movement, jumping, animation transitions, directional flipping, projectile attacks, and health management.

### Enemy AI
Enemies use patrol movement, ground detection, and player detection to determine their behaviour. When the player enters the detection range, enemies chase and attack.

### Combat System
The player shoots arrows using a projectile-based attack system. Arrows can damage enemies upon collision. Enemies can also damage the player through direct attacks and enemy projectiles.

### Health and Collectibles
The player starts with 10 health points. Enemy attacks decrease health, while heart collectibles restore health. Gem collectibles increase the total gem count.

### Game Over System
The player dies when health reaches zero or when touching water. The death sequence includes disabling player controls, hiding the player sprite, camera shake, and an explosion effect before displaying the Game Over screen.

## Getting Started

### Requirements
- Unity Hub
- Unity Editor (compatible with the project's Unity version)
- Visual Studio or Visual Studio Code (recommended for C# development)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/0Arafsir0/GDD_2D_Game_Project.git
   ```

2. Open Unity Hub.
3. Select **Add > Add project from disk**.
4. Select the cloned project folder.
5. Open the project using a compatible Unity Editor version.
6. Open the main game scene.
7. Press the **Play** button to run the game.


## Project Structure

The project is organized around Unity scenes, scripts, animations, prefabs, and game assets.

```text
Assets/
├── Animations/
├── Audio/
├── Materials/
├── Prefabs/
├── Scenes/
├── Scripts/
├── Sprites/
└── UI/
```

## Learning Outcomes

Through this project, I gained practical experience with:

- 2D game development using Unity.
- C# scripting and object-oriented programming.
- Player input and movement systems.
- Rigidbody2D and collision detection.
- Animator controllers and animation events.
- Basic enemy AI and behaviour.
- Projectile-based combat mechanics.
- UI implementation and scene management.
- Camera effects using Cinemachine.
- Integrating multiple gameplay systems into a complete game.

## Future Improvements

- Multiple playable levels.
- Additional enemy types and behaviours.
- More weapons and combat mechanics.
- Sound effects and background music.
- Improved level design and visual effects.
- Main menu and settings system.
- Save system and high-score tracking.

## Author

**MD ARAFAT SIRAJ**

Computer Science and Engineering  
Premier University, Chattogram, Bangladesh

- GitHub: [@0Arafsir0](https://github.com/0Arafsir0)
- LinkedIn: [@arafsir](https://www.linkedin.com/in/arafsir/)

## License

This project was developed for academic and educational purposes. Please check the licenses of individual assets before reusing or redistributing them.
