using VoeAirlines.Entities; // modelo do nosso projeto ( model => dados)
using Microsoft.EntityFrameworkCore; //ORM
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace VoeAirlines.EntityConfigurations;

public class LoginConfiguration:IEntityTypeConfiguration<Login> {
    //Estudar sobre a diferença de Classe e Interface

    public void Configure (EntityTypeBuilder<Login> builder) {

        //Definindo a Tabela:
        //Pluralização
        builder.ToTable("Logins");

        //Chave primária:
        // => Símbolo do Lambda
        builder.HasKey(l => l.Id);


        //Definindo o usuário:
        builder.Property(l => l.Usuario)
               .IsRequired()
               .HasMaxLength(40);

        //Definindo a senha:
        builder.Property(l => l.Senha)
               .IsRequired()
               .HasMaxLength(12);

        builder.Property(l => l.DataCriacao)
               .IsRequired();
               

        
    }
}