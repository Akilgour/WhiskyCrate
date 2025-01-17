﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WhiskyCrate.Data.Context;

namespace WhiskyCrate.Data.Migrations
{
    [DbContext(typeof(WhiskyCrateContext))]
    partial class WhiskyCrateContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WhiskyCrate.Domain.Distilleries.Distillery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("CurrentlyOperating")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Distilleries");
                });

            modelBuilder.Entity("WhiskyCrate.Domain.WhiskyExpressions.WhiskyExpression", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgeInMonths")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DistilleryId")
                        .HasColumnType("int");

                    b.Property<string>("DistillingNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TastingNotes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistilleryId");

                    b.ToTable("WhiskyExpressions");
                });

            modelBuilder.Entity("WhiskyCrate.Domain.WhiskyExpressions.WhiskyExpression", b =>
                {
                    b.HasOne("WhiskyCrate.Domain.Distilleries.Distillery", "Distillery")
                        .WithMany("WhiskyExpressions")
                        .HasForeignKey("DistilleryId");

                    b.Navigation("Distillery");
                });

            modelBuilder.Entity("WhiskyCrate.Domain.Distilleries.Distillery", b =>
                {
                    b.Navigation("WhiskyExpressions");
                });
#pragma warning restore 612, 618
        }
    }
}
