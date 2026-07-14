# Project Overview 
- **Game Title**: Eropa99 Dream
- **High-Level Concept**: A high-quality hub/launcher game that provides a portal to two main sub-games: "Gem Hunter" (a portrait match-3 game) and "Slot Machine" (a landscape slot game), set in a beautiful underwater coral themed environment with an animated mermaid.
- **Players**: Single Player
- **Inspiration / Reference Games**: Slot games, Match-3 puzzles (e.g. Candy Crush)
- **Tone / Art Direction**: Vibrant underwater world, stylized colorful corals, and cute cartoon characters.
- **Target Platform**: Android (Mobile)
- **Screen Orientation / Resolution**: Portrait (`1080x1920` default) for Main Menu & Gem Hunter, transitioning to Landscape (`1920x1080`) for Slot Machine.
- **Render Pipeline**: Universal Render Pipeline (URP)

# Game Mechanics 
## Core Gameplay Loop
Players open the game to a Portrait Main Menu where they can select either "Play Gem Hunter" or "Play Slots". Clicking either launches the corresponding sub-game, dynamically adjusting the screen orientation. Players can also toggle and configure audio levels via a Settings popup panel.
## Controls and Input Methods
Standard mobile touch gestures. Buttons for navigation, sliders for settings, drag/swapping gestures in Match-3, and taps to spin the slots.

# UI
The Main Menu UI features:
- **Game Play Buttons**: Two prominent square card-style buttons placed side-by-side in the lower-middle screen area.
- **Utility Buttons**: Settings button at the bottom-left corner and Quit button at the bottom-right corner.
- **Settings Popup Panel**: A centered, non-collapsing audio control panel containing volume slider labels, sliders, and a close button.

# Key Asset & Context
- **Scene File**: `Assets/Scenes/MainMenu.unity`
- **Main Canvas**: `MainMenuCanvas` (under `ScreenSpaceOverlay` mode)
- **UI Elements to Modify**:
  - `MainMenuCanvas` (CanvasScaler component)
  - `PlayGemHunterButton` (RectTransform component)
  - `PlaySlotsButton` (RectTransform component)
  - `SettingsButton` (RectTransform component)
  - `QuitButton` (RectTransform component)
  - `SettingsPanel` (RectTransform component)
  - `MainVolumeSlidertxt` / `MusicVolumeSlidertxt` / `SFXVolumeSlidertxt` (RectTransform & Text components)
  - `MainVolumeSlider` / `MusicVolumeSlider` / `SFXVolumeSlider` (RectTransform components)
  - `CloseButton` (RectTransform component)

# Implementation Steps

### Step 1: Initialize Scene Loading
- **Description**: Open the MainMenu scene in Edit Mode inside the Unity Editor via an automation script to ensure programmatically precise edits.
- **Assigned role**: developer
- **Dependencies**: None
- **Parallelizable**: No

### Step 2: Configure CanvasScaler for Portrait Orientation
- **Description**: Modify `MainMenuCanvas`'s `CanvasScaler` properties to use portrait reference dimensions (`1080x1920`) instead of the incorrect landscape settings.
  - Scale Mode: `ScaleWithScreenSize`
  - Reference Resolution: `(1080, 1920)`
  - Screen Match Mode: `MatchWidthOrHeight`
  - Match Width/Height: `0.5`
- **Assigned role**: developer
- **Dependencies**: Step 1
- **Parallelizable**: No

### Step 3: Align Game Play Buttons (Gem Hunter & Slots)
- **Description**: Anchor both buttons to the center of the portrait canvas and position them side-by-side below the upper half of the screen (retaining space for the background art).
  - **`PlayGemHunterButton`**:
    - Anchors: `min=(0.5, 0.5)`, `max=(0.5, 0.5)`
    - Pivot: `(0.5, 0.5)`
    - Position: `(-220, -150)`
    - Size: `(316, 316)`
  - **`PlaySlotsButton`**:
    - Anchors: `min=(0.5, 0.5)`, `max=(0.5, 0.5)`
    - Pivot: `(0.5, 0.5)`
    - Position: `(220, -150)`
    - Size: `(316, 316)`
- **Assigned role**: developer
- **Dependencies**: Step 2
- **Parallelizable**: No

### Step 4: Reposition Utility Buttons (Settings & Quit)
- **Description**: Re-anchor the Settings and Quit buttons to the bottom corners of the screen to ensure they stay on screen and responsive on any aspect ratio device.
  - **`SettingsButton`** (Bottom-Left corner):
    - Anchors: `min=(0.0, 0.0)`, `max=(0.0, 0.0)`
    - Pivot: `(0.0, 0.0)`
    - Position: `(50, 50)`
    - Size: `(80, 80)`
  - **`QuitButton`** (Bottom-Right corner):
    - Anchors: `min=(1.0, 0.0)`, `max=(1.0, 0.0)`
    - Pivot: `(1.0, 0.0)`
    - Position: `(-50, 50)`
    - Size: `(80, 80)`
- **Assigned role**: developer
- **Dependencies**: Step 2
- **Parallelizable**: No

### Step 5: Redesign Settings Panel for Responsive Scaling
- **Description**: Currently, `SettingsPanel` is stretched with huge margins that make it collapse/disappear on narrow screens. We will change it to center-anchored with a fixed size so it scales perfectly on all devices.
  - **`SettingsPanel`**:
    - Anchors: `min=(0.5, 0.5)`, `max=(0.5, 0.5)`
    - Pivot: `(0.5, 0.5)`
    - Position: `(0, 0)`
    - Size: `(500, 500)`
- **Assigned role**: developer
- **Dependencies**: Step 2
- **Parallelizable**: No

### Step 6: Layout Settings Panel Child Elements
- **Description**: Clean up the anchors and positioning of volume sliders, labels, and the close button inside the `SettingsPanel` to align beautifully.
  - **`CloseButton`**:
    - Anchors: `min=(0.5, 1.0)`, `max=(0.5, 1.0)` (Top Center)
    - Pivot: `(0.5, 0.5)`
    - Position: `(0, -40)`
    - Size: `(60, 60)`
  - **Volume Texts** (`MainVolumeSlidertxt`, `MusicVolumeSlidertxt`, `SFXVolumeSlidertxt`):
    - Anchors: `min=(0.5, 0.5)`, `max=(0.5, 0.5)`
    - Pivot: `(0.5, 0.5)`
    - Positions: `(-120, 80)` for Main, `(-120, 0)` for Music, `(-120, -80)` for SFX
    - Size: `(200, 40)`
  - **Volume Sliders** (`MainVolumeSlider`, `MusicVolumeSlider`, `SFXVolumeSlider`):
    - Anchors: `min=(0.5, 0.5)`, `max=(0.5, 0.5)`
    - Pivot: `(0.5, 0.5)`
    - Positions: `(100, 80)` for Main, `(100, 0)` for Music, `(100, -80)` for SFX
    - Size: `(200, 24)`
- **Assigned role**: developer
- **Dependencies**: Step 5
- **Parallelizable**: No

### Step 7: Mark Dirty and Save Scene
- **Description**: Save the modified MainMenu scene and mark it dirty so Unity registers all RectTransform and CanvasScaler changes.
- **Assigned role**: developer
- **Dependencies**: Steps 3, 4, 6
- **Parallelizable**: No

# Verification & Testing
1. **Resolution Test**: Programmatically or manually check the UI elements in the Unity Game view under different aspect ratios:
   - Portrait 9:16 (1080x1920)
   - Portrait 19.5:9 (1080x2340 - Modern long screen)
   - Tablet 3:4 (1536x2048)
   Verify that all buttons are fully visible, aligned, and there are no overlapping or off-screen elements.
2. **Button Functionality Check**: Verify in Play Mode that:
   - Clicking `PlayGemHunterButton` correctly loads the LoadingScene (Portrait).
   - Clicking `PlaySlotsButton` correctly loads the SlotMachine scene (Landscape).
   - Clicking `SettingsButton` opens the Settings popup.
   - Sliders in Settings correctly adjust audio volume levels.
   - Clicking `CloseButton` closes the Settings popup.
   - Clicking `QuitButton` exits the game.
