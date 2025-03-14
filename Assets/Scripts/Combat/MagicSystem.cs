using System;
using DungeonCrawler.Models;
using DungeonCrawler.Core;

namespace DungeonCrawler {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Bem-vindo ao DungeonCrawler!");

            // Exemplo de criação de personagem usando CharacterCreation
            var characterCreator = new CharacterCreation();
            try {
                // Aqui você pode coletar os dados do jogador ou utilizar valores fixos para teste
                characterCreator.CreateCharacter("Hero", "Guerreiro", 5, 5);
            }
            catch(Exception ex) {
                Console.WriteLine("Erro na criação do personagem: " + ex.Message);
            }

            // Exemplo de inicialização do GameManager
            var gameManager = new GameManager();
            gameManager.StartGame();

            // Aqui você pode adicionar chamadas para outras funcionalidades, 
            // como carregar templates, iniciar a lógica de combate, etc.
            Console.WriteLine("O jogo iniciou. Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}