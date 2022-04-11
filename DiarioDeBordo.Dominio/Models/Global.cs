using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioDeBordo.Dominio.Models
{
    public static class Globais
    {
#if DEBUG
        //public static string CaminhoWebApi = "http://10.100.132.31/FolhaDePonto.WebApi/api/";
        //public static string CaminhoWebApi = "http://ponto.consorciocpt.com.br/webapi/api/";
        public static string CaminhoWebApi = "http://179.131.10.204/api/";
#else
        public static string CaminhoWebApi = "http://179.131.10.204/api/";
#endif
    }
}
