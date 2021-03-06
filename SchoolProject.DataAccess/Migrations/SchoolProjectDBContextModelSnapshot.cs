// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.DataAccess;

namespace SchoolProject.DataAccess.Migrations
{
    [DbContext(typeof(SchoolProjectDBContext))]
    partial class SchoolProjectDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolProject.DataAccess.Entities.ClassNumb", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("classNumb")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("desc")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ClassNumbs");
                });

            modelBuilder.Entity("SchoolProject.DataAccess.Entities.Student", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("avgScore")
                        .HasColumnType("int");

                    b.Property<int>("classID")
                        .HasColumnType("int");

                    b.Property<int?>("classNumbid")
                        .HasColumnType("int");

                    b.Property<string>("firstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("homeAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("classNumbid");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("SchoolProject.DataAccess.Entities.Student", b =>
                {
                    b.HasOne("SchoolProject.DataAccess.Entities.ClassNumb", "classNumb")
                        .WithMany("student")
                        .HasForeignKey("classNumbid");

                    b.Navigation("classNumb");
                });

            modelBuilder.Entity("SchoolProject.DataAccess.Entities.ClassNumb", b =>
                {
                    b.Navigation("student");
                });
#pragma warning restore 612, 618
        }
    }
}
