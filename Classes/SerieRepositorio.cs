using System;
using System.Collections.Generic;
using TreinamentoCSharp.Interfaces;

namespace TreinamentoCSharp
{
  public class SerieRepositorio : IRepositorio<Serie>
  {
    private List<Serie> ListSerie = new List<Serie>();

    public void Atualiza(int id, Serie objeto)
    {
      ListSerie[id] = objeto;
      //throw new NotImplementedException();
    }

    public void Exclui(int id)
    {
      ListSerie[id].Excluir();
      //throw new NotImplementedException();
    }

    public void Insere(Serie objeto)
    {
      ListSerie.Add(objeto);
      //throw new NotImplementedException();
    }

    public List<Serie> Lista()
    {
      return ListSerie;
      //throw new NotImplementedException();
    }

    public int ProximoId()
    {
      return ListSerie.Count;
      //throw new NotImplementedException();
    }

    public Serie RetornaPorId(int id)
    {
      return ListSerie[id];
      //throw new NotImplementedException();
    }
  }
}