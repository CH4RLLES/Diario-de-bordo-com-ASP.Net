using System;
using System.Collections.Generic;
using System.Text;

namespace DiarioDeBordo.Aplicacao.Models.Api
{
    public sealed class ApiResult<TModel>
    {
        public bool Sucesso { get; set; }
        public TModel Data { get; set; }
    }
}
