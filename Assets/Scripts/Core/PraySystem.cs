using System;
using System.IO;
using System.Text.Json;

namespace DungeonCrawler.Core {
    [Serializable]
    public class SaveData {
        public int PlayerLevel;
        public int Experience;
        // ... outros dados relevantes do jogo
    }

    public class SaveSystem {
        private string savePath = "savegame.json";

        /// <summary>
        /// Salva o progresso do jogo.
        /// </summary>
        public void SaveGame(SaveData data) {
            try {
                string jsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(savePath, jsonData);
                Console.WriteLine("Jogo salvo com sucesso!");
            } catch (Exception e) {
                Console.WriteLine("Erro ao salvar o jogo: " + e.Message);
            }
        }

        /// <summary>
        /// Carrega os dados salvos, se existirem.
        /// </summary>
        public SaveData LoadGame() {
            try {
                if (File.Exists(savePath)) {
                    string jsonData = File.ReadAllText(savePath);
                    SaveData data = JsonSerializer.Deserialize<SaveData>(jsonData);
                    Console.WriteLine("Jogo carregado com sucesso!");
                    return data;
                } else {
                    Console.WriteLine("Nenhum jogo salvo encontrado.");
                    return null;
                }
            } catch (Exception e) {
                Console.WriteLine("Erro ao carregar o jogo: " + e.Message);
                return null;
            }
        }
    }
}