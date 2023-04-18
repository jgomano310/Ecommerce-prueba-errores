using Ecommerce.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Areas.Identity.Data;

public class LoginContexto : IdentityDbContext<EcommerceUser>
{
    public LoginContexto(DbContextOptions<LoginContexto> options)
        : base(options)
    {
    }

    public virtual DbSet<EcommerceUser> ApplicationUserSet { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserEntityConfiguration());

        //nuevo esquema
        builder.HasDefaultSchema("dlk_ecommerce");

        //cambia el nombre de las tablas
        builder.Entity<EcommerceUser>().ToTable("Dlk_cat_acc_empleados");
        builder.Entity<IdentityRole>().ToTable("Dlk_cat_acc_roles");


        builder.Entity<IdentityUserRole<string>>().ToTable("Dlk_cat_acc_empleados_roles");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("Dlk_cat_acc_claim_roles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("Dlk_cat_acc_claim_empleados");
        builder.Entity<IdentityUserLogin<string>>().ToTable("Dlk_cat_acc_login_empleados");
        builder.Entity<IdentityUserToken<string>>().ToTable("Dlk_cat_acc_token_empleados");
       
    }
}

public class UserEntityConfiguration : IEntityTypeConfiguration<EcommerceUser>
{
    public void Configure(EntityTypeBuilder<EcommerceUser> builder)
    {
        //añadimos nuevos campos
        builder.Property(usuario => usuario.UsuarioNombre).HasMaxLength(255);
        builder.Property(usuario => usuario.UsuarioApellidos).HasMaxLength(255);
    }
}
