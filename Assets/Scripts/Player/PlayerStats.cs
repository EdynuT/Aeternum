using System;

namespace DungeonCrawler.Player {
    public class PlayerStats {
        public int Health { get; set; } = 100;
        public int Mana { get; set; } = 50;
        public int Stamina { get; set; } = 75;

        /// <summary>
        /// Aplica dano ao jogador e verifica se está morto.
        /// </summary>
        public void TakeDamage(int damage) {
            Health -= damage;
            Console.WriteLine($"Dano: {damage}. Vida restante: {Health}");
            if (Health <= 0) {
                Console.WriteLine("Jogador morto!");
                // Aqui você pode integrar uma transição para GameOver, por exemplo.
            }
        }
    }
}