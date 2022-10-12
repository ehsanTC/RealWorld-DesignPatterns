# Strategy Design Pattern

This pattern make it easy to use a family of algorithms or execution paths. Each algorithm is concrete implementation of a interface which define the functionality of the algorithm.
  
I use this pattern to split the searching algorithms of a graph. 
The context class is `GraphTraverse` and the strategy interface is `ISearchStrategy`

The concerete strategies are:
 - `Bfs` class that searchs breadth first
 - `Dfs` class that searchs depth first

The subtle point here is that the two above algorithm search the graph, but they have different requirements. All of them implement the **Strategy** interface as expected and each one has different constructor. 
