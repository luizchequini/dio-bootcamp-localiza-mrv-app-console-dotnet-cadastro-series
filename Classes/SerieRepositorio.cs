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
            throw new NotImplementedException();
        }

        public void Exclui(int id)
        {
            throw new NotImplementedException();            
        }

        public void Insere(Serie entidade)
        {
            throw new NotImplementedException();           
        }

        public List<Serie> Lista()
        {
            throw new NotImplementedException();
        }

        public int ProximoId()
        {
            throw new NotImplementedException();            
        }

        public Serie RetornaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}