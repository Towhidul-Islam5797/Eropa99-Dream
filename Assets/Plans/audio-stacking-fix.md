# Project Overview
- **Game Title**: Gem Hunter & Slot Machine Hub
- **High-Level Concept**: A dual-mode Android game hub featuring a classic Match-3 puzzle game ("Gem Hunter") and a Casino Slot Machine simulation ("Slot Machine"), selectable from a shared Main Menu.
- **Players**: Single player.
- **Inspiration / Reference Games**: Candy Crush Saga, classic slot machines.
- **Tone / Art Direction**: Vibrant, cartoonish, aquatic-themed fantasy.
- **Target Platform**: Android.
- **Screen Orientation / Resolution**: Portrait (MainMenu and Gem Hunter) / Landscape (Slot Machine).
- **Render Pipeline**: Universal Render Pipeline (URP).

# Game Mechanics
## Core Gameplay Loop
- Players start in the unified Main Menu (Portrait) and choose between:
  1. **Gem Hunter**: A match-3 game mode where players complete objectives by swapping gems, earning stars, coins, and lives. Includes level progression.
  2. **Slot Machine**: A reels-based spin game (Landscape) where players bet coins and win payouts based on matching symbol configurations.

## Controls and Input Methods
- Standard touch inputs via the Unity New Input System. Menu interactions, gem swapping, and slot reel spin button presses.

# UI
- **Main Menu**: Unified UI with buttons to select either game mode.
- **Gem Hunter**: Level selection grid, in-game grid layout with score HUD, moves remaining, and return settings.
- **Slot Machine**: Reel spinner panel, bet control inputs, and win animation overlays.

# Key Asset & Context
- **Assets/Scenes/MainMenu.unity**: Hub scene containing `[MainMenuAudio]` which plays the default background music `music_harp_peaceful_loop`.
- **Assets/SlotterGaul/V2.0/Scripts/Scenes/SceneLoader.cs**: Handles transitions between the main hub and game modes. Currently contains hardcoded outdated scene names (`"Main"`, `"SMV2_Level1"`).
- **Assets/GemHunterMatch/Scripts/InitLoader.cs**: Scene loader component in Gem Hunter's loading scene. Currently hardcoded to load the nonexistent `"Main"` scene.
- **Assets/GemHunterMatch/Scripts/UI/UIHandler.cs**: Matches and level selection transitions, also containing hardcoded loads for `"Main"`.
- **Assets/GemHunterMatch/Scripts/GameManager.cs**: Match-3 game manager. Does not destroy duplicate game objects on load, resulting in leaks, and continues playing music if not cleaned up.
- **Assets/SlotterGaul/V2.0/Scripts/Managers/SlotAudioManager.cs**: Slot machine audio manager which is a `DontDestroyOnLoad` singleton.

# Implementation Steps

### Step 1: Fix Singleton Leak & Lifecycle in GameManager
- **Description**: Modify `Assets/GemHunterMatch/Scripts/GameManager.cs` to correctly implement the singleton pattern:
  - Reset `s_IsShuttingDown = false` on `Awake()`.
  - Destroy duplicate instances of `GameManager` in `Awake()` to prevent game object leaks.
- **Assigned role**: developer
- **Dependencies**: None
- **Parallelizable**: Yes

### Step 2: Fix Hardcoded Outdated Scene Names in SceneLoader, InitLoader, and UIHandler
- **Description**: Update the hardcoded scene names across loaders to match the actual build settings scene names:
  - In `Assets/SlotterGaul/V2.0/Scripts/Scenes/SceneLoader.cs`:
    - Set `SlotSceneName = "SlotMachine"`
    - Set `GemHunterSceneName = "LoadingScene"`
  - In `Assets/GemHunterMatch/Scripts/InitLoader.cs`:
    - Change target scene from `"Main"` to `"LevelSelection"`.
  - In `Assets/GemHunterMatch/Scripts/UI/UIHandler.cs` (lines 171 & 200):
    - Change target scene from `"Main"` to `"LevelSelection"`.
- **Assigned role**: developer
- **Dependencies**: None
- **Parallelizable**: Yes

### Step 3: Implement Audio Cleanup when Returning to Main Menu
- **Description**: Modify the `GoToMainMenu()` method in `Assets/SlotterGaul/V2.0/Scripts/Scenes/SceneLoader.cs` to locate and destroy any persistent game audio/manager instances (`GameManager` and `SlotAudioManager`) before loading the `MainMenu` scene. This instantly stops their background music and prevents audio duplication/stacking with `[MainMenuAudio]`.
- **Assigned role**: developer
- **Dependencies**: Step 1 & Step 2
- **Parallelizable**: No

# Verification & Testing
## Automated/Manual Verification Steps
1. **Scene Transition Test (Slot Machine)**:
   - Play from `MainMenu` scene.
   - Click "Play Slots" -> Transition to Slot Machine (Landscape, slot music starts).
   - Click "Back" -> Transition to Main Menu (Portrait).
   - **Verification**: Only the main menu music plays; the slot machine music is fully stopped, and no duplicate audio source exists.
2. **Scene Transition Test (Gem Hunter)**:
   - Play from `MainMenu` scene.
   - Click "Play GemHunter" -> LoadingScene -> Level Selection (Gem Hunter music starts).
   - Select Level 1 -> Play -> Return to Level Selection.
   - Click "Back" -> Transition to Main Menu.
   - **Verification**: Only the main menu music plays; Gem Hunter music is stopped, and no duplicate/stacked audio is playing.
3. **Repeated Entry Test**:
   - Repeat transitions multiple times to ensure no duplicate `GameManager` or `SlotAudioManager` game objects leak in the hierarchy.
