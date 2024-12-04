using Entitas;
using UnityEngine;

public class ChangePlayerHealthSystem : IExecuteSystem {
    private readonly GameContext _context;

    public ChangePlayerHealthSystem(Contexts contexts) {
        _context = contexts.game; // Game context
    }

    public void Execute() {
        var entities = _context.GetEntities(GameMatcher.PlayerHealth);
        foreach (var e in entities) {
            if (Input.GetKeyDown(KeyCode.D)) {
                e.isPlayerDamaged = true; // PlayerDamaged ekle
            }

            if (Input.GetKeyDown(KeyCode.H)) {
                e.isPlayerHealed = true; // PlayerHealed ekle
            }
        }
    }
}