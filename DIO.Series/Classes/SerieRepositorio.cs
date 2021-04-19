using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    // Mudar essa parte:
    // Não gostei de criar uma interface com generics e dps implementá-la com um tipo específico hardcoded
    // Isso acaba com o propósito de usar generics, a meu ver.
    // Sem falar que na hora de usar, não usar uma referência à interface (na classe Program) faz com que
    // a interface cumpra absolutamente nenhum papel, já que ela não está servindo para "encaixar"
    // a classe final (que implementa a interface) com a classe que utiliza essa classe final.
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSeries = new List<Serie>();
        public void Atualiza(int id, Serie serie)
        {
            listaSeries[id] = serie;
        }

        public void Exclui(int id)
        {
            listaSeries[id].Excluir();
        }

        public void Insere(Serie serie)
        {
            listaSeries.Add(serie);
        }

        public List<Serie> Lista()
        {
            return listaSeries;
        }

        public int ProximoId()
        {
            return listaSeries.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSeries[id];
        }
    }
}