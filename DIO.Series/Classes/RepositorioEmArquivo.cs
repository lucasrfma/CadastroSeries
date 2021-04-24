using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class RepositorioEmArquivo<T>  : IRepositorio<T> where T : EntidadeBase, new()
    {
        private string NomeArquivo;
        private List<T> Lista = new List<T>();

        public RepositorioEmArquivo(string nomeArquivo)
        {
            NomeArquivo = nomeArquivo;
            Lista = new List<T>();
            CarregaLista();
        }

        private void GravaLista()
        {
            if( Lista.Count == 0 )
            {
                throw new InvalidOperationException("Nenhuma conta cadastrada.");
            }
            Console.WriteLine($"Gravando lista de contas...");

            List<string> ContasParaGravar = new List<string>();
            for (int i = 0; i < Lista.Count ; i++)
            {
                ContasParaGravar.Add(Lista[i].ToStringSimples());
            }

            try
            {
                System.IO.File.WriteAllLines(".\\Dados\\"+NomeArquivo,ContasParaGravar);
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        private void CarregaLista()
        {
            try{
                // elemento dummy para se ter acesso ao método NumeroLinhas()
                // Gostaria que esse método fosse static, mas não deu para usar T.metodoStatic
                // então fiz essa GAMBS
                T elemento = new T();
                int linhasPorElemento = elemento.NumeroLinhas();
                string[] proximoElemento = new string[linhasPorElemento];

                string line = null;

                System.IO.StreamReader file =
                    new System.IO.StreamReader(".\\Dados\\"+NomeArquivo);
                while(true)
                {
                    for( int i = 0; 
                        (i < linhasPorElemento) && 
                        ((line = file.ReadLine()) != null);
                        ++i)
                    {
                        proximoElemento[i] = line;
                    }
                    if( line == null )
                    {
                        break;
                    }else
                    {
                        T novoElemento = new T();
                        novoElemento.setData(proximoElemento);
                        Lista.Add(novoElemento);
                    }
                }
                file.Close();
            }
            catch
            {
                throw;
            }
        }

        public void Atualiza(int id, T elemento)
        {
            Lista[id] = elemento;
            GravaLista();
        }

        public void Exclui(int id)
        {
            Lista[id].Excluir();
            GravaLista();
        }

        public void Insere(T elemento)
        {
            int index = Lista.IndexOf(elemento);
            if( index != -1 )
            {
                elemento.Id = index;
                Lista[index] = elemento;
            }else
            {
                Lista.Add(elemento);
            }
            GravaLista();
        }

        public List<T> Listar()
        {
            return Lista;
        }

        public int ProximoId()
        {
            return Lista.Count;
        }

        public T RetornaPorId(int id)
        {
            return Lista[id];
        }
    }
}