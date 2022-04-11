using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiarioDeBordo.Aplicacao.Models
{
    public class Paginacao<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        public Paginacao(List<T> items, int count, int pagina, int tamanho)
        {
            PageIndex = pagina;
            TotalPages = (int)Math.Ceiling(count / (double)tamanho);

            this.AddRange(items);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

        public static Paginacao<T> Paginar(IList<T> dados, int pagina, int tamanho)
        {
            var count = dados.Count();
            var items = dados.Skip((pagina - 1) * tamanho).Take(tamanho).ToList();
            return new Paginacao<T>(items, count, pagina, tamanho);
        }
    }
}
