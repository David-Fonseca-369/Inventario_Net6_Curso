using Inventario_Net6.DTOs;

namespace Inventario_Net6.Helpers
{
    public static class IQueryableExtensions
    {

        public static IQueryable<T>Paginar<T>(this IQueryable<T> queryable, PaginacionDTO paginacionDTO)
        {
            return queryable
                //ej: 1-5 6- 10
                .Skip((paginacionDTO.Pagina - 1) * paginacionDTO.recordsPorPagina)
                //10
                .Take(paginacionDTO.recordsPorPagina);
        }
    }
}
