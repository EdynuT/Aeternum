using System;

namespace DungeonCrawler.Models {
    public class CharacterCreation {
        // Exemplo de total de pontos disponíveis para distribuição
        private const int TotalPontos = 10;
        
        /// <summary>
        /// Valida e cria o personagem a partir dos dados informados.
        /// </summary>
        public void CreateCharacter(string nome, string classe, int forca, int inteligencia) {
            if (string.IsNullOrEmpty(nome))
                throw new Exception("Nome inválido.");

            // Exemplo de validação: soma dos atributos deve ser menor ou igual ao total disponível
            if (forca + inteligencia > TotalPontos)
                throw new Exception($"A soma dos atributos não pode exceder {TotalPontos} pontos.");

            // Outras validações podem ser adicionadas aqui conforme a lógica do jogo

            Console.WriteLine($"Personagem '{nome}' da classe '{classe}' criado com Força: {forca} e Inteligência: {inteligencia}.");
        }
    }
}