//   └── SessionLoop     ← owns a single game session (new/load)
// SessionLoop ← exists for one playthrough (new game or loaded game)
using UnityEngine;

public class SessionLoop {
    private readonly WorldMap _world;
    private readonly WorldRenderer _renderer;
    // private readonly TurnLoop _turnLoop;

    public SessionLoop(WorldMap world, WorldRenderer renderer) {
        _world = world;
        _renderer = renderer;
        // _turnLoop = new TurnLoop();
        _renderer.Initialize(world);
    }

    public void Initialize()
    {
        // Initialize WorldRendering, ComponentLayout, UI etc.
        _renderer.Initialize(_world);
        
    }
    public void Tick()
    {
        
    }

    public void ProcessNextTurn() {
        // _turnLoop.Execute(_world);
        _renderer.Sync(_world);
    }

    public void End() {
        // _renderer.Teardown();
    }
}
