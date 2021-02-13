using System;
using System.Collections.Generic;
using dio_bootcamp_localiza_mrv_app_console_dotnet_cadastro_series.Interfaces;

namespace dio_bootcamp_localiza_mrv_app_console_dotnet_cadastro_series.Classes
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> ListaSerie = new List<Serie>();

        public void Atualiza(int id, Serie entidade)
        {
            ListaSerie[id] = entidade;
        }

        public void Exclui(int id)
        {
            ListaSerie[id].Excluir();          
        }

        public void Insere(Serie entidade)
        {
            ListaSerie.Add(entidade);           
        }

        public List<Serie> Lista()
        {
            return ListaSerie;
        }

        public int ProximoId()
        {
            return ListaSerie.Count;   
        }

        public Serie RetornaPorId(int id)
        {
            return ListaSerie[id];
        }
    }
}