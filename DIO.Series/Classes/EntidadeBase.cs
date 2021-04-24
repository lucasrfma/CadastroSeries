namespace DIO.Series
{
    public abstract class EntidadeBase
    {
        public int Id{ get; internal protected set; }
        public string Titulo { get; protected set; }
        public abstract void Excluir();
        public abstract string ToStringSimples();
        public virtual int NumeroLinhas() => 2;
        public EntidadeBase(){}
        // public EntidadeBase(string[] argumentos)
        // {
        //     Id = int.Parse(argumentos[0]);
        //     Titulo = argumentos[1];
        // }
        // public EntidadeBase(int id,string titulo)
        // {
        //     Id = id;
        //     Titulo = titulo;
        // }
        public abstract void setData(string[] args);
    }
}