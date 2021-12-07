namespace TreinamentoCSharp
{
  public abstract class EntidadeBase
  //Classe Abstrata são moldes, para outras Classes, elas não podem ser //instanciadas.
  {
    public int Id { get; protected set; }
  }
}