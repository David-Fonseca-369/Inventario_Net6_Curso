using Inventario_Net6.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventario_Net6.Mapeo
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario").HasKey( x => x.IdUsuario );

            //Configuracion a la llave foranea
            builder.HasOne( x => x.Rol).WithMany().HasForeignKey( x => x.IdRol);
        }
    }
}
