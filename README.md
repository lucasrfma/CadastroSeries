# CadastroSeries
 Projeto "Criando um APP simples de cadastro de séries em .NET" - bootcamp .NET DIO

## Melhorias

 - Criação de uso da classe RepositorioEmArquivo<T> que herda IRepositorio, para substituir a classe SerieRepositorio
   - Essa classe faz uso de arquivos na hora de construir o objeto repositório, assim como na hora de inserir novos elementos, garantindo continuidade dos dados entre inicializações
   - Essa classe faz uso de generics, de modo a permitir uso com outras classes que herdem de EntidadeBase.
     - A classe Filme foi criada para demonstrar essa capacidade, mas a classe Program, que contém a função main() ainda não foi atualizada para por essa melhoria em prática.
   - Ao inserir um novo elemento, o elemento é buscado na lista existente, e se encontrado, o elemento existente na lista é atualizado, dessa forma previne-se a duplicação de elementos, e permite a reinclusão de elementos excluídos sem duplicação de espaço usado no arquivo.

## Modificações possíveis

 - Atualizar a classe Program para permitir uso da classe Filme.
 - Adicionar comentários em diversos métodos que estão sem documentação.
