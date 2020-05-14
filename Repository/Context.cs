using System;
using System.Collections.Generic;
using Ajuda;
using Core.Model;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Repository
{
    public class Context : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Franquia> Franquias { get; set; }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserId = "1",
                    Nome = "Admin",
                    Senha = AuthenticationHelper.ComputeHash("123").ToString(),
                    Regra = User.RegraEnum.admin.ToString()
                },

                new User
                {
                    UserId = "2",
                    Nome = "Daniel",
                    Senha = AuthenticationHelper.ComputeHash("123").ToString(),
                    Regra = User.RegraEnum.user.ToString()
                });

            modelBuilder.Entity<User>()
                .HasIndex(c => c.Nome)
                .IsUnique();




            //     new Produto{Nome = "Mc Feliz",
            //                 Preço = 10,
            //                 Acompanhamento = "Batata frita"},

            //     new Produto{Nome = "Big Tasty",
            //                 Preço = 17,
            //                 Acompanhamento = "Coca 500ml"},

            //     new Produto{Nome = "Big Mac", 
            //                 Preço = 15, 
            //                 Acompanhamento = "Pastelzinho"}
            // );

//------------------------------------------------------------------------------------------------

            //     new Franquia{Nome = "MC Terminal",
            //                 Cidade = "Hortolandia",
            //                 Bairro = "São Sebastião",
            //                 HorarioDeAbertura = "10:00hrs",
            //                 HorarioDeFechamento = "22:00hrs"},

            //     new Franquia {Nome = "MC Rodoviaria",
            //                 Cidade = "Campinas",
            //                 Bairro = "Ouro Verde",
            //                 HorarioDeAbertura = "08:00",
            //                 HorarioDeFechamento = "23:00"},

            //     new Franquia {Nome = "MC Shopping",
            //                 Cidade = "Hortolandia",
            //                 Bairro = "Remanso Campineito",
            //                 HorarioDeAbertura = "10:00hrs",
            //                 HorarioDeFechamento = "23:00hrs"}
            // );

        }
    }
}