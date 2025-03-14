using System;

namespace DungeonCrawler.Core {
    public enum GameState {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public class GameManager {
        public static GameManager Instance { get; private set; }
        public GameState State { get; private set; }

        public GameManager() {
            if (Instance != null) {
                throw new Exception("Já existe uma instância de GameManager!");
            }
            Instance = this;
            State = GameState.MainMenu;
        }

        public void StartGame() {
            State = GameState.Playing;
            Console.WriteLine("Jogo iniciado!");
            // Inicialize sistemas e carregue dados, se necessário.
        }

        public void PauseGame() {
            if (State == GameState.Playing) {
                State = GameState.Paused;
                Console.WriteLine("Jogo pausado!");
            }
        }

        public void ResumeGame() {
            if (State == GameState.Paused) {
                State = GameState.Playing;
                Console.WriteLine("Jogo retomado!");
            }
        }

        public void EndGame() {
            State = GameState.GameOver;
            Console.WriteLine("Fim de jogo!");
            // Lógica para limpar recursos, salvar progresso, etc.
        }
    }
}