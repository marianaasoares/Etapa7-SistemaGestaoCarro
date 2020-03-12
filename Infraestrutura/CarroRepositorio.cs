using Dominio;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura
{
    public class CarroRepositorio
    {
        private static List<Carro> carroLista = new List<Carro>();

        public List<Carro> Pesquisar(string termoDePesquisa)
        {
            return carroLista.Where(x => x.Nome.ToUpper().Contains(termoDePesquisa.ToUpper()))
                                                         .ToList();
        }

        public void Adicionar(Carro carro)
        {
            carroLista.Add(carro);
        }

        public List<Carro> PesquisarCarrosApartirDe2015()
        {
            return carroLista.Where(x => x.Ano >= 2015).ToList();
        }

    }
}
