using System;

namespace Dominio
{
    public class Carro
    {
        public string Nome { get; private set; }
        public int Ano { get; private set; }

        public Carro(string nome, int ano)
        {
            Nome = nome;
            Ano = ano;
        }

        public int CalcularHaQuantosAnosFoiFabricado()
        {
            return DateTime.Now.Year - Ano;
        }

    }
}
