using System;
using UnityEngine;
using System.Text.RegularExpressions;

namespace DungeonCrawler.Combat {
    [Serializable]
    public class Weapon {
        public string nomeBase;
        public float peso;
        public string danoFisicoDice; // Ex: "1d6"
        public string tipoDano;
        public int durabilidadeAtual;
        public int durabilidadeMaxima;

        public Weapon(string nomeBase, float peso, string danoFisicoDice, string tipoDano, int durabilidadeAtual, int durabilidadeMaxima) {
            this.nomeBase = nomeBase;
            this.peso = peso;
            this.danoFisicoDice = danoFisicoDice;
            this.tipoDano = tipoDano;
            this.durabilidadeAtual = durabilidadeAtual;
            this.durabilidadeMaxima = durabilidadeMaxima;
        }

        /// <summary>
        /// Rola os dados conforme a notação "XdY".
        /// </summary>
        public int RolarDado() {
            int numDados, lados;
            if (ParseDiceNotation(danoFisicoDice, out numDados, out lados)) {
                int total = 0;
                for (int i = 0; i < numDados; i++) {
                    total += UnityEngine.Random.Range(1, lados + 1);
                }
                return total;
            }
            Debug.LogError("Formato de dados inválido: " + danoFisicoDice);
            return 0;
        }

        /// <summary>
        /// Interpreta a notação "XdY" e extrai a quantidade de dados e lados.
        /// </summary>
        private bool ParseDiceNotation(string diceNotation, out int numDados, out int lados) {
            numDados = 0;
            lados = 0;
            var match = Regex.Match(diceNotation, @"(\d+)d(\d+)");
            if (match.Success) {
                numDados = int.Parse(match.Groups[1].Value);
                lados = int.Parse(match.Groups[2].Value);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Calcula um multiplicador para o dano com base na durabilidade.
        /// </summary>
        public float CalcularMultiplicadorDano() {
            float ratio = (float)durabilidadeAtual / durabilidadeMaxima;
            if (ratio >= 1.25f)
                return 1.5f;
            else if (ratio >= 1.0f)
                return 1.25f;
            else if (ratio >= 0.75f)
                return 1.0f;
            else if (ratio >= 0.50f)
                return 0.75f;
            else if (ratio >= 0.25f)
                return 0.5f;
            else if (ratio > 0.0f)
                return 0.25f;
            else
                return 0.1f;
        }

        /// <summary>
        /// Atualiza o nome da arma com base na durabilidade (indicando seu estado).
        /// </summary>
        public string AtualizarNomeEstado() {
            float ratio = (float)durabilidadeAtual / durabilidadeMaxima;
            string estado;
            if (ratio >= 1.25f)
                estado = "Excelente";
            else if (ratio >= 1.0f)
                estado = "Perfeito";
            else if (ratio >= 0.75f)
                estado = "Ótimo";
            else if (ratio >= 0.50f)
                estado = "Bom";
            else if (ratio >= 0.25f)
                estado = "Riscado";
            else if (ratio > 0.0f)
                estado = "Danificado";
            else
                estado = "Quebrado";
            return nomeBase + " (" + estado + ")";
        }

        /// <summary>
        /// Realiza um ataque, calculando o dano e reduzindo a durabilidade.
        /// </summary>
        public float Attack() {
            float multiplicador = CalcularMultiplicadorDano();
            int danoBase = RolarDado();
            float totalDano = danoBase * multiplicador;
            // Reduz a durabilidade em 1, sem ir abaixo de zero.
            durabilidadeAtual = Mathf.Max(0, durabilidadeAtual - 1);
            return totalDano;
        }

        public override string ToString() {
            return AtualizarNomeEstado() + " (" + peso + " kg) - Durabilidade: " 
                   + durabilidadeAtual + "/" + durabilidadeMaxima +
                   "\nDano " + danoFisicoDice + " (" + tipoDano + ")";
        }
    }
}