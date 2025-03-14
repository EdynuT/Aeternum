using System;

namespace DungeonCrawler.Player {
    public class PlayerController {
        public float Speed { get; set; } = 5.0f;
        public float PositionX { get; private set; }
        public float PositionY { get; private set; }

        /// <summary>
        /// Atualiza a posição do jogador com base na entrada do console.
        /// </summary>
        public void Update() {
            Console.WriteLine("Pressione W/A/S/D para mover o personagem:");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch(keyInfo.Key) {
                case ConsoleKey.W:
                    PositionY += Speed;
                    break;
                case ConsoleKey.S:
                    PositionY -= Speed;
                    break;
                case ConsoleKey.A:
                    PositionX -= Speed;
                    break;
                case ConsoleKey.D:
                    PositionX += Speed;
                    break;
                default:
                    Console.WriteLine("Tecla não mapeada para movimento.");
                    break;
            }
            Console.WriteLine($"Posição atual: ({PositionX}, {PositionY})");
        }
    }
}