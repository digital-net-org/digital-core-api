﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SafariDigital.Data.Context;

#nullable disable

namespace SafariDigital.Database.Migrations
{
    [DbContext(typeof(SafariDigitalContext))]
    [Migration("20240722003537_created_document_table")]
    partial class created_document_table
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SafariDigital.Data.Models.AvatarTable.Avatar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int?>("PosX")
                        .HasColumnType("integer")
                        .HasColumnName("pos_x");

                    b.Property<int?>("PosY")
                        .HasColumnType("integer")
                        .HasColumnName("pos_y");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid>("document_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("document_id");

                    b.ToTable("avatar");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.DocumentTable.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<int>("DocumentType")
                        .HasColumnType("integer")
                        .HasColumnName("file_type");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)")
                        .HasColumnName("file_name");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint")
                        .HasColumnName("file_size");

                    b.Property<int>("MimeType")
                        .HasColumnType("integer")
                        .HasColumnName("mime_type");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("uploader_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("FileName")
                        .IsUnique();

                    b.HasIndex("uploader_id");

                    b.ToTable("document");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.UserTable.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("character varying(254)")
                        .HasColumnName("email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)")
                        .HasColumnName("password");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(24)
                        .HasColumnType("character varying(24)")
                        .HasColumnName("username");

                    b.Property<int?>("avatar_id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("avatar_id");

                    b.HasIndex("Username", "Email")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.AvatarTable.Avatar", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.DocumentTable.Document", "Document")
                        .WithMany()
                        .HasForeignKey("document_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.DocumentTable.Document", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.UserTable.User", "Uploader")
                        .WithMany()
                        .HasForeignKey("uploader_id");

                    b.Navigation("Uploader");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.UserTable.User", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.AvatarTable.Avatar", "Avatar")
                        .WithMany()
                        .HasForeignKey("avatar_id");

                    b.Navigation("Avatar");
                });
#pragma warning restore 612, 618
        }
    }
}
