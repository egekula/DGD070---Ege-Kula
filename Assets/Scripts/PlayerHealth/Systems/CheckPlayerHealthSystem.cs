using Entitas;
using UnityEngine; // Mathf için gerekli

public class CheckPlayerHealthSystem : IExecuteSystem {
    private readonly GameContext _context;

    public CheckPlayerHealthSystem(Contexts contexts) {
        _context = contexts.game; // Game context
    }

    public void Execute() {
        var entities = _context.GetEntities(GameMatcher.PlayerHealth);
        foreach (var e in entities) {
            // PlayerDamaged kontrolü
            if (e.isPlayerDamaged) {
                e.ReplacePlayerHealth(Mathf.Max(0, e.playerHealth.value - 10)); // Sağlığı düşür
                e.isPlayerDamaged = false; // Durumu sıfırla
            }

            // PlayerHealed kontrolü
            if (e.isPlayerHealed) {
                e.ReplacePlayerHealth(Mathf.Min(100, e.playerHealth.value + 10)); // Sağlığı artır
                e.isPlayerHealed = false; // Durumu sıfırla
            }
        }
    }
}