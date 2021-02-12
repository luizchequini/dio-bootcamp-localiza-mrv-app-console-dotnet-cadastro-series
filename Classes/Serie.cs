using System;
using System.Linq;
using dio_bootcamp_localiza_mrv_app_console_dotnet_cadastro_series.Enum;

namespace dio_bootcamp_localiza_mrv_app_console_dotnet_cadastro_series.Classes
{
    public class Serie : EntidadeBase
    {
        private string Titulo{ get; set; }

        private string Descricao{ get; set; }

        private int Ano{ get; set; }
    
        private Genero Genero{get; set;}

        public Serie(int id, string titulo, string descricao, int ano, Genero genero)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Genero = genero;
        }

        public string retornoTitulo()
        {
            return this.Titulo;
        }

        internal int retornoId()
        {
            return this.Id;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;

            return retorno;
        }
    }
}