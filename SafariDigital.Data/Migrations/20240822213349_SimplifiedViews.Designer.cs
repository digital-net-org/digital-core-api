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
    [Migration("20240822213349_SimplifiedViews")]
    partial class SimplifiedViews
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SafariDigital.Data.Models.Database.Avatar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<Guid>("DocumentId")
                        .HasColumnType("uuid")
                        .HasColumnName("document_id");

                    b.Property<int?>("PosX")
                        .HasColumnType("integer")
                        .HasColumnName("pos_x");

                    b.Property<int?>("PosY")
                        .HasColumnType("integer")
                        .HasColumnName("pos_y");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("DocumentId");

                    b.ToTable("avatar");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.Document", b =>
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

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("mime_type");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<Guid?>("UploaderId")
                        .HasColumnType("uuid")
                        .HasColumnName("uploader_id");

                    b.HasKey("Id");

                    b.HasIndex("FileName")
                        .IsUnique();

                    b.HasIndex("UploaderId");

                    b.ToTable("document");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.RecordedLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)")
                        .HasColumnName("ip_address");

                    b.Property<bool>("Success")
                        .HasColumnType("boolean")
                        .HasColumnName("success");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("user_agent");

                    b.HasKey("Id");

                    b.ToTable("recorded_login");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.RecordedToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime>("ExpiredAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expired_at");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)")
                        .HasColumnName("ip_address");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("token");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserAgent")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("user_agent");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("recorded_token");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int?>("AvatarId")
                        .HasColumnType("integer")
                        .HasColumnName("avatar_id");

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

                    b.HasKey("Id");

                    b.HasIndex("AvatarId");

                    b.HasIndex("Username", "Email")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.View", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean")
                        .HasColumnName("is_published");

                    b.Property<int?>("PublishedFrameId")
                        .HasColumnType("integer")
                        .HasColumnName("published_frame_id");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("title");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.HasIndex("PublishedFrameId")
                        .IsUnique();

                    b.HasIndex("Title")
                        .IsUnique();

                    b.ToTable("view");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.ViewFrame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Data")
                        .HasColumnType("text")
                        .HasColumnName("data");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("character varying(1024)")
                        .HasColumnName("name");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<int>("ViewId")
                        .HasColumnType("integer")
                        .HasColumnName("view_id");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("ViewId");

                    b.ToTable("view_frame");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.Avatar", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.Database.Document", "Document")
                        .WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Document");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.Document", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.Database.User", "Uploader")
                        .WithMany()
                        .HasForeignKey("UploaderId");

                    b.Navigation("Uploader");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.RecordedToken", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.Database.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.User", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.Database.Avatar", "Avatar")
                        .WithMany()
                        .HasForeignKey("AvatarId");

                    b.Navigation("Avatar");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.View", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.Database.ViewFrame", "PublishedFrame")
                        .WithOne()
                        .HasForeignKey("SafariDigital.Data.Models.Database.View", "PublishedFrameId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("PublishedFrame");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.ViewFrame", b =>
                {
                    b.HasOne("SafariDigital.Data.Models.Database.View", "View")
                        .WithMany("Frames")
                        .HasForeignKey("ViewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("View");
                });

            modelBuilder.Entity("SafariDigital.Data.Models.Database.View", b =>
                {
                    b.Navigation("Frames");
                });
#pragma warning restore 612, 618
        }
    }
}
