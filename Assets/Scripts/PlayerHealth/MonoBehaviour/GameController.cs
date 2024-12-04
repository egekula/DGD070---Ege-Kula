using Entitas;
using UnityEngine;

public class GameController : MonoBehaviour {
    private Systems _systems;

    void Start() {
        var contexts = Contexts.sharedInstance;

        _systems = new Feature("Player Health Feature")
            .Add(new PlayerHealthFeature(contexts)); 

        _systems.Initialize();
    }

    void Update() {
        _systems.Execute();
        _systems.Cleanup();
    }
}