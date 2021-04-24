using System;

namespace DIO.Series
{
    public class Filme : EntidadeBase
    {
        // Atributos
        public Genero Genero { get; protected set; }
        
        public string Descricao { get; protected set; }
        public int Ano { get; protected set; }
        public bool Excluido { get; protected set; }
        public int Nominacoes { get; protected set; }

        // Métodos
        public Filme(){}
        public Filme(int id,
                     Genero genero,
                     string titulo,
                     string descricao,
                     int ano,
                     int nominacoes)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Descricao = descricao;
            Ano = ano;
            Nominacoes = nominacoes;
            Excluido = false;
        }
        public Filme(string[] args)
        {
            setData(args);
        }

        public override void setData(string[] args)
        {
            Id = int.Parse(args[0]);
            Titulo = args[1];
            Descricao = args[2];
            Genero = Enum.Parse<Genero>(args[3]);
            Ano = int.Parse(args[4]);
            Nominacoes = int.Parse(args[5]);
            Excluido = bool.Parse(args[6]);
        }

        public override string ToString()
        {
            return "Título: " + Titulo + Environment.NewLine +
                   "Descrição: " + Descricao + Environment.NewLine +
                   "Gênero: " + Genero + Environment.NewLine +
                   "Ano: " + Ano + Environment.NewLine +
                   "Nominações: " + Nominacoes + Environment.NewLine +
                   "Excluído: " + Excluido; 
        }
        // retorna uma string sem descrição de campos
        // para ser usada ao armazenar em arquivo
        public override string ToStringSimples()
        {
            return  Id + Environment.NewLine +
                    Titulo + Environment.NewLine +
                    Descricao + Environment.NewLine +
                    Genero + Environment.NewLine +
                    Ano + Environment.NewLine +
                    Nominacoes + Environment.NewLine +
                    Excluido; 
        }
        // Retorna quantas linhas um objeto Serie retorna com os métodos
        // ToString e ToStringArray.
        public override int NumeroLinhas() => 7;

        public override void Excluir() => Excluido = true;
    }
}