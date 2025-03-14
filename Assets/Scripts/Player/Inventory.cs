using System;
using System.Collections.Generic;

namespace DungeonCrawler.Player {
    public class Inventory {
        public List<string> Items { get; private set; } = new List<string>();

        /// <summary>
        /// Adiciona um item ao inventário.
        /// </summary>
        public void AddItem(string item) {
            Items.Add(item);
            Console.WriteLine($"{item} adicionado ao inventário.");
        }

        /// <summary>
        /// Remove um item do inventário.
        /// </summary>
        public void RemoveItem(string item) {
            if (Items.Remove(item)) {
                Console.WriteLine($"{item} removido do inventário.");
            } else {
                Console.WriteLine($"{item} não encontrado no inventário.");
            }
        }
    }
}