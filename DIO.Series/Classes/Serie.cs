using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Atributos
        public Genero Genero { get; protected set; }
        
        public string Descricao { get; protected set; }
        public int Ano { get; protected set; }
        public bool Excluida { get; protected set; }

        // Métodos
        public Serie(){}
        public Serie(int id,
                     Genero genero,
                     string titulo,
                     string descricao,
                     int ano)
        {
            Id = id;
            Titulo = titulo;
            Genero = genero;
            Descricao = descricao;
            Ano = ano;
            Excluida = false;
        }
        public Serie(string[] args)
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
            Excluida = bool.Parse(args[5]);
        }

        public override string ToString()
        {
            return "Título: " + Titulo + Environment.NewLine +
                   "Descrição: " + Descricao + Environment.NewLine +
                   "Gênero: " + Genero + Environment.NewLine +
                   "Ano: " + Ano + Environment.NewLine +
                   "Excluída: " + Excluida; 
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
                    Excluida; 
        }

        public override bool Equals(object obj)
        {
            if( obj.GetType().Equals(this.GetType()) )
            {
                return ((Serie)obj).Titulo.Equals(this.Titulo);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Titulo.GetHashCode();
        }
        // Retorna quantas linhas um objeto Serie retorna com os métodos
        // ToString e ToStringArray.
        public override int NumeroLinhas() => 6;

        public override void Excluir() => Excluida = true;
    }
}