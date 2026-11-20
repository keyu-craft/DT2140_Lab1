# DT2140 Lab 1 — Image-based AR with Vuforia

Unity project for DT2140 Lab 1. The application recognizes two
custom image targets in the same webcam session and anchors different 3D
content to each target.

## Group

- Members:
  - Keyu Liu
  - Yihuan Ma
    
## Features

- Two custom Image Targets tracked simultaneously
- A Cube on the first target and a Sphere on the second
- Mouse input in Webcam Play Mode and pointer-compatible touch input
- Physics raycasting through object colliders
- A new object color on every selection
- Audio feedback on selection

## Versions

- Unity: `6000.0.85f2`
- Render pipeline: Built-In Render Pipeline
- Vuforia Engine: `11.4.4`
- Unity Input System: `1.20.0`

## Project structure

- `Assets/Scenes/Lab1.unity` — main lab scene
- `Assets/Scripts/PointerRaycaster.cs` — converts pointer presses into 3D rays
- `Assets/Scripts/ARInteractable.cs` — changes color and plays audio
- `Assets/StreamingAssets/Vuforia` — imported target databases
- `Assets/Editor/Vuforia/ImageTargetTextures/Image` — custom target previews

## Setup

1. Install Unity `6000.0.85f2` or a compatible Unity `6000.0` LTS editor.
2. Obtain the course-provided Vuforia Engine `11.4.4` package.
3. Place `com.ptc.vuforia.engine-11.4.4.tgz` in the `Packages` directory.
4. Open the project in Unity and allow package import/compilation to finish.
5. Create a Vuforia Basic License in the Vuforia Developer Portal.
6. Open Vuforia Configuration and enter your own App License Key.
7. Set Play Mode Type to Webcam and select a camera device.
8. Open `Assets/Scenes/Lab1.unity` and enter Play Mode.

The repository intentionally contains no Vuforia License Key.

## How it works

Vuforia matches camera features against the local device database and updates
the corresponding Image Target transform. The Cube and Sphere are children of
their Image Targets, so they follow the tracked pose. `PointerRaycaster` casts
a ray from the AR Camera through the pointer position. When the ray hits a
collider, it calls `ARInteractable.Activate()`, which advances the object's hue
and restarts its audio source.

## Demonstration checklist

- [x] Both custom Image Targets can be tracked in the same run
- [x] Each target displays different 3D content
- [x] A mouse click selects the intended object
- [x] Each selection changes the object's appearance and plays audio
- [x] Add group member names
- [x] Record distance, viewing-angle, and lighting observations
- [x] Verify target-image and sound-effect licenses before making the repository public

## Evaluation observations

Complete these fields with measurements from the final test:

- **Distance:**
  The measurements are approximate. Target A (Cube) remained stable from approximately 15 cm to 130 cm and completely lost tracking at approximately 150 cm. Target B (Sphere) remained stable from approximately 30 cm to 160 cm and completely lost tracking at approximately 210 cm.

Target B performed better at longer distances, possibly because its high-contrast visual features remained easier to distinguish when the target occupied a smaller area of the camera image. At very close distances, tracking became difficult when the camera could no longer see enough of the complete target.
- **Viewing angle:**
  Target A began to jitter heavily when rotated approximately 45 degrees away from a front-facing position. Target B began to jitter heavily at approximately 30 degrees.

A consistent tracking-loss angle could not be measured because the point of failure varied between attempts. This suggests that tracking stability was influenced not only by the viewing angle, but also by rotation speed, motion blur, lighting, and the number of visible image features.
- **Lighting:** TODO

## Asset credits

Add the source, creator, URL, and license for both target images and both sound
effects before making this repository public.
