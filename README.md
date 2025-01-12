# Unity Chunk Loading System

A lightweight and efficient chunk loading system implemented in Unity, designed to optimize performance by dynamically loading and unloading terrain segments based on player proximity.

## Demo

▶️ [Watch the demonstration video](https://www.youtube.com/watch?v=x8vTvRrBjhM)

## Features

- Dynamic chunk loading/unloading based on player distance
- Configurable activation distance and check interval
- Optimized performance through coroutine-based distance checking
- Simple integration with existing Unity projects
- First-person player controller with smooth movement
- Procedurally placed grass and flowers for terrain decoration

## Technical Implementation

The system uses Unity's GameObject management to control terrain chunks:

- Chunks are organized in parent GameObjects for easy management
- Distance calculations use Vector3.Distance for accuracy
- Coroutine-based checking system to reduce performance overhead
- Configurable parameters for easy customization:
  - `activationDistance`: Distance at which chunks become active/inactive
  - `checkInterval`: Time between distance checks
  - `player`: Reference to the player object for distance calculations

## Setup Instructions

1. Create your terrain chunks and organize them under parent GameObjects
2. Attach the ChunkLoader script to an empty GameObject in your scene
3. Assign references in the Unity Inspector:
   - Player GameObject
   - Array of chunk parent GameObjects
4. Configure activation distance and check interval as needed

## Code Structure

### ChunkLoader.cs
Handles the dynamic loading/unloading of terrain chunks:
```csharp
public class ChunkLoader : MonoBehaviour
{
    public GameObject player;
    public GameObject[] chunkParents;
    public float activationDistance = 50.0f;
    public float checkInterval = 1;
    ...
}
```


## Requirements

- Unity 2020.3 or later
- Basic understanding of Unity GameObject management
