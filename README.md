# Cube-Factory

This unity asset instantiates, keeps track of and removes cubes based on player input.

## Installation

This repository is a drop-in script, not a Unity project. There is no scene, no
`Assets/` folder and no package manifest here — only the single `MonoBehaviour` in
`src/`.

1. Copy `src/CubeFactory.cs` into the `Assets/` folder of an existing Unity project.
2. Let Unity finish compiling; the `CubeFactory` component becomes available.

## Setup

1. Create a cube prefab (for example, from a built-in `Cube` GameObject).
2. Add an empty GameObject to the scene.
3. Attach the `CubeFactory` component to it.
4. Assign the cube prefab to the component's **Cube Prefab** field in the Inspector.

The **Cube Prefab** field has no default value. If it is left unassigned, pressing
`E` spawns nothing and writes an error to the Console naming the field to assign.

## Controls

| Key | Action |
|-----|--------|
| `E` | Spawns a cube and adds it to the tracked list |
| `R` | Destroys one tracked cube, if any remain |

Both keys are handled in `Update()` and are read once per key press, not per frame
held.

## Behaviour

- Every cube is spawned at the world origin, `(0, 0, 0)`. Spawning several cubes
  therefore produces a stack of overlapping cubes at the same point rather than a
  visible spread.
- `R` removes the **oldest** cube still tracked, not the most recently spawned one.
- Pressing `R` with no cubes tracked does nothing.
- After each spawn and each removal, a labelled message naming the action and the
  resulting cube count is written to the Console — for example
  `CubeFactory: spawned cube, count is now 1`.
- Pressing `E` while **Cube Prefab** is unassigned logs an error naming the field
  and leaves the tracked list unchanged.

## Inspector fields

| Field | Type | Purpose |
|-------|------|---------|
| `cubePrefab` | `GameObject` | The prefab instantiated on each spawn. Must be assigned. |
| `cubes` | `List<GameObject>` | The cubes currently tracked. Populated at runtime; assigning it in the Inspector is not expected. |

## License

Licensed under the Stephenson Software Non-Commercial License (Stephenson-NC). See
[LICENSE](LICENSE).
