using Microsoft.EntityFrameworkCore;

namespace Inventario_Net6.Helpers
{
    public static class HttpContextExtensions
    {
        public async static Task InsertarParametrosPaginacionCabeceraAsync<T>(this HttpContext httpContext, IQueryable<T> queryable)
        {
            if (httpContext == null)
            {
                throw new ArgumentNullException(nameof(httpContext));
            }

            //contar los registros
            double cantidad = await queryable.CountAsync();


            //Agregar cabecera
            httpContext.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());

        }

        public static void InsertarParametrosPaginacionEnCabecera(this HttpContext httpContext, int cantidad)
        {
            httpContext.Response.Headers.Add("cantidadTotalRegistros", cantidad.ToString());
        }
    }
}
