using System;

namespace Empregado
{
    public class Empregado
    {
        private string _nome;

        public string Nome
        {
            get
            {
                if (Sexo == "M")
                    return $"Sr.{_nome}";
                else
                    return $"Srª.{_nome}";
            }
            set { _nome = value; }
        }

        public string Sexo { get; private set; }

        public Empregado(string nome, string sexo)
        {
            nome = Nome;
            sexo = Sexo;
        }
    }
}
