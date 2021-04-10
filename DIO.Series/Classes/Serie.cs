using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
        public Genero Genero { get; private set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public int Ano { get; private set; }
        public bool Excluido { get; private set; }

        // Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            Id = id;
            Genero = genero;
            Titulo = titulo;
            Descricao = descricao;
            Ano = ano;
            Excluido = false;
        }

        public override string ToString()
        {
            return "Título: " + Titulo + Environment.NewLine +
                 "Descrição: " + Descricao + Environment.NewLine +
                 "Gênero: " + Genero + Environment.NewLine +
                 "Ano: " + Ano; 
        }
        // public string retornaTitulo()
        // {
        //     return this.T
        // }
        public void Excluir()
        {
            Excluido = true;
        }
    }
}