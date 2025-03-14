using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace DungeonCrawler.Core{
    public class CharacterTemplate{
        [JsonPropertyName("Nome")]
        public string Nome { get; set; }
        
        [JsonPropertyName("Raça")]
        public string Raça { get; set; }
        
        [JsonPropertyName("Classe")]
        public string Classe { get; set; }
        
        [JsonPropertyName("Origem")]
        public string Origem { get; set; }
        
        [JsonPropertyName("Nível")]
        public int Nível { get; set; }
        
        [JsonPropertyName("Exp")]
        public int Exp { get; set; }
        
        [JsonPropertyName("Economia")]
        public Economia Economia { get; set; }
        
        [JsonPropertyName("Status Base")]
        public StatusBase StatusBase { get; set; }
        
        [JsonPropertyName("Status Secundários")]
        public StatusSecundarios StatusSecundarios { get; set; }
        
        [JsonPropertyName("Status Gerais")]
        public Dictionary<string, int> StatusGerais { get; set; }
        
        [JsonPropertyName("Itens")]
        public List<string> Itens { get; set; }
        
        [JsonPropertyName("Itens Chave")]
        public List<string> ItensChave { get; set; }
        
        [JsonPropertyName("Armas")]
        public List<string> Armas { get; set; }
        
        [JsonPropertyName("Armaduras")]
        public List<string> Armaduras { get; set; }
        
        [JsonPropertyName("Fortificações")]
        public List<string> Fortificações { get; set; }
        
        [JsonPropertyName("Magias")]
        public List<string> Magias { get; set; }
        
        [JsonPropertyName("Orações")]
        public List<string> Orações { get; set; }
        
        [JsonPropertyName("Penalidades")]
        public List<string> Penalidades { get; set; }
        
        [JsonPropertyName("Aliados")]
        public List<string> Aliados { get; set; }
    }

    public class Economia{
        [JsonPropertyName("Moedas de ouro")]
        public int MoedasDeOuro { get; set; }
    }

    public class StatusBase{
        [JsonPropertyName("Vida")]
        public int Vida { get; set; }
        
        [JsonPropertyName("Mana")]
        public int Mana { get; set; }
        
        [JsonPropertyName("Stamina")]
        public int Stamina { get; set; }
    }

    public class StatusSecundarios{
        [JsonPropertyName("Peso de equipamento")]
        public int PesoDeEquipamento { get; set; }
        
        [JsonPropertyName("Movimento")]
        public int Movimento { get; set; }
        
        [JsonPropertyName("Luta")]
        public int Luta { get; set; }
        
        [JsonPropertyName("Esquiva")]
        public int Esquiva { get; set; }
    }

    public static class Utilities{
        // Caminho padrão relativo para o template de ficha
        private static readonly string fichaTemplatePath = @"..\..\..\Models\Ficha.json";

        /// <summary>
        /// Carrega o template do personagem a partir do arquivo JSON padrão.
        /// </summary>
        public static CharacterTemplate LoadCharacterTemplate(){
            return LoadCharacterTemplate(fichaTemplatePath);
        }

        /// <summary>
        /// Carrega o template do personagem a partir de um arquivo JSON.
        /// </summary>
        public static CharacterTemplate LoadCharacterTemplate(string filePath){
            try{
                string jsonContent = File.ReadAllText(filePath);
                var template = JsonSerializer.Deserialize<CharacterTemplate>(jsonContent);
                return template;
            }
            catch(Exception ex){
                Console.WriteLine($"Erro ao carregar o template: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Cria um novo personagem com base no template, solicitando dados via console.
        /// </summary>
        public static CharacterTemplate CreateNewCharacter(CharacterTemplate template){
            if(template == null){
                Console.WriteLine("Template inválido.");
                return null;
            }

            Console.Write("Digite o Nome do personagem: ");
            template.Nome = Console.ReadLine();

            Console.Write("Digite a Raça: ");
            template.Raça = Console.ReadLine();

            Console.Write("Digite a Classe: ");
            template.Classe = Console.ReadLine();

            Console.Write("Digite a Origem: ");
            template.Origem = Console.ReadLine();

            // Possivelmente, você pode solicitar input para outros campos ou
            // implementar lógica de distribuição de pontos.
            return template;
        }

        /// <summary>
        /// Salva os dados do personagem em um arquivo JSON.
        /// </summary>
        public static void SaveCharacter(CharacterTemplate character, string filePath){
            try{
                string json = JsonSerializer.Serialize(character, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
                Console.WriteLine("Personagem salvo com sucesso!");
            }
            catch(Exception ex){
                Console.WriteLine($"Erro ao salvar o personagem: {ex.Message}");
            }
        }
    }
}