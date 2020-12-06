# Projeto 1 - Nasa Database

## Grupo 08

|     Nome      |  Número   |   GitHub   |
| :-----------: | :-------: | :--------: |
| Pedro Marques | a21900253 | pmarques93 |
|  Luiz Santos  | a21901441 | JundMaster |

## Tarefas realizadas no exercício

>Por ordem cronológica

|        Luiz Santos         |           Pedro Marques            |
| :------------------------: | :--------------------------------: |
|       `File Reader`        |             `Manager`              |
|     `Exoplanet` `Star`     |         `Search Criteria`          |
|  `Star Collection Getter`  |         `Exoplanet` `Star`         |
| `Planet Collection Getter` |          `User Interface`          |
|       `Data Filter`        |     `PlanetQuery` `StarQuery`      |
|     `File Validation`      | Basic, Advanced and Ordered Search |
|       Read Me / UML        |              Read Me               |

## Arquitetura da Solução

O projeto foi realizado de modo a implementar o modo interativo para consola.

### Funcionamento do Programa

No programa, ao ser executado, é iniciada uma sequência de operações como
observado na seguinte imagem:

![Funcionamento do Programa](Images/Funcionamento_do_Programa.png)

Após correr o programa, são apresentadas opções ao utilizador, escolhas estas
que permitem abrir um ficheiro ou fechar o programa. Caso o utilizador abra
um ficheiro com sucesso, o programa vai ler todas as colunas com *headers* de
interesse e guardá-los numa lista de estrelas (no caso das estrelas) e de
planetas (no caso dos planetas). De seguida é apresentado um menu em que vão
ser apresentados um conjunto de critérios de pesquisa. Neste menu o utilizador
consegue filtrar os resultados (ex: planetname: kepler) e consegue escolher a
ordem pelos quais vão aparecer através do comando *order*. Após escrever
search, de modo a mostrar a lista, o utilizador consegue escrever *information*,
de modo a a ver informação detalhada, em que vai ser apresentado um menu que
pede o nome explícito de um planeta/estrela. Esta informação, no caso dos
planetas, mostra toda a sua informação juntamente com a sua estrela e, no caso
das estrelas, mostra a informação da estrela juntamente com com a lista de
planetas que a mesma contém.

### Algoritmos

Para a criação das coleções de estrelas e planetas, implementou-se um *design*
de classes focado no conceito do *design pattern strategy*.

Dentre estas classes, estão duas - `ExoplanetsListFromCSVData` e
`StarsListFromCSVData` - que são concretizações da classe
`CollectionFromCSVData` e definem a maneira como as coleções de planetas e
estrelas são criadas.

Ambas as classes fazem uso de dados lidos de um ficheiro CSV, sendo isto
responsabilidade de classes que implementem `IFileDataReader`, que neste caso
concreto, seria a classe `CSVFileDataReader` e estes dados são filtrados por
concretizações da interface `IFilterData`.

O algoritmo criado de modo a criar as listas que irão ser filtradas consiste
na utilização do método `CreateStarsAndPlanets`, pertencente à classe `Manager`,
que tem como objetivo a criação das listas. Após a criação, correm dois
*foreach* para todos os planetas e estrelas, em que caso um planeta tenha o
mesmo *hostname* da estrela, este planeta é adicionado como um childplanet
dessa estrela, sendo esta também adicionada com parentstar deste planeta.

O algoritmo criado para pesquisa baseia-se no *input* do utilizador que modifica
critérios de pesquisa criados através da classe `SearchCriteria`. O utilizador
coloca o critério que quer modificar e de seguida coloca o valor, sendo
confirmada a existência deste critério através de um *TryParse* que verifica
se o input existe no *enum* `SearchFieldInputs`, realizando outro *TryParse*
de seguida para confirmar a possibilidade de converter o valor para um
determinado tipo. Após isto, quando o utilizador executa o comando *search*
para procurar uma lista de `IAstronomicalObjects`, vão ser filtrados todos os
valores através de um *query* com uma ordem previamente determinada pelo
utilizador.

### *Queries*

As principais *queries* utilizadas são *queries* executadas em listas de
planetas e estrelas filtradas, nomeadamente
`ICollection<IStar> nonRepeatedStars` e `IEnumerable<IStar> allStars`
encontradas na `Manager`. Estas *queries*, `PlanetQuery` e `SearchQuery`,
filtram todos os planetas/estrelas consoante o *input* do utilizador através das
propriedades da classe `SearchCriteria`. De modo a podermos realizar a pesquisa
avançada, foi também utilizado o *Join* na *query* das `nonRepeatedStars`,
conseguindo assim aceder a uma lista de planetas, sendo possível incluir os
seus campos na pesquisa. Deste modo é possível pesquisar por estrelas com
campos pertencentes a planetas e vice-versa. As *queries* mencionadas contêm
o método `Order` que possibilita a ordenação da mesma por ordem ascendente e
descendente, onde existe também um critério secundário de ordenação.

São realizadas ainda *queries* secundárias no processo de obtenção e filtragem
de dados do ficheiro CSV inserido pelo usuário para então se obterem as
coleções de planetas e estrelas.

Neste processo há alguns métodos que se destacam seriam o `ElementAt` e
`Contains`, sendo o primeiro usado para localizar, especificamente, os dados
da primeira linha válida do ficheiro CSV, isto é, os nomes das colunas. E o
segundo método entra em ação verificando se essa linha contem os campos de
obrigatórios - `hostname` e `pl_name`.

### Diagrama UML

O seguinte diagrama é uma representação gráfica da estrutura de classes do
programa.

![Diagrama UML](Images/UML.png)

## Referências

- ["C# documentation",_Microsoft_, Microsoft 2020](
https://docs.microsoft.com/en-us/dotnet/csharp)
- ["LINQ, Join and Group"](
https://www.youtube.com/watch?v=W5L2_wXj6gw&feature=youtu.be)
- ["How to get properties (System.Reflection)"](
https://www.youtube.com/watch?v=9_tEKosktNo&feature=youtu.be)
- ["2º projeto de LP1 2018/19"](
https://github.com/VideojogosLusofona/lp1_2018_p2_solucao)
