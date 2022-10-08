﻿// <auto-generated />
using System;
using ChillChat.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChillChat.DataModels.Migrations
{
    [DbContext(typeof(ChillChatDbContext))]
    [Migration("20221008072937_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChillChat.DataModels.Channel", b =>
                {
                    b.Property<int>("ChannelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ChannelId"));

                    b.Property<byte>("ChannelType")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ServerId")
                        .HasColumnType("integer");

                    b.HasKey("ChannelId");

                    b.HasIndex("ServerId");

                    b.ToTable("Channels");
                });

            modelBuilder.Entity("ChillChat.DataModels.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("MessageId"));

                    b.Property<int?>("ChannelId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("MessageId");

                    b.HasIndex("ChannelId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("ChillChat.DataModels.Server", b =>
                {
                    b.Property<int>("ServerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ServerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ServerId");

                    b.ToTable("Servers");
                });

            modelBuilder.Entity("ChillChat.DataModels.Channel", b =>
                {
                    b.HasOne("ChillChat.DataModels.Server", "Server")
                        .WithMany("Channels")
                        .HasForeignKey("ServerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ChillChat.DataModels.ObjectInfo", "ObjectInfo", b1 =>
                        {
                            b1.Property<int>("ChannelId")
                                .HasColumnType("integer");

                            b1.Property<DateTimeOffset>("Created")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Creator")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<bool>("Deleted")
                                .HasColumnType("boolean");

                            b1.Property<DateTimeOffset>("Modified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Modifier")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ChannelId");

                            b1.ToTable("Channels");

                            b1.WithOwner()
                                .HasForeignKey("ChannelId");
                        });

                    b.Navigation("ObjectInfo")
                        .IsRequired();

                    b.Navigation("Server");
                });

            modelBuilder.Entity("ChillChat.DataModels.Message", b =>
                {
                    b.HasOne("ChillChat.DataModels.Channel", "Channel")
                        .WithMany()
                        .HasForeignKey("ChannelId");

                    b.OwnsOne("ChillChat.DataModels.ObjectInfo", "ObjectInfo", b1 =>
                        {
                            b1.Property<int>("MessageId")
                                .HasColumnType("integer");

                            b1.Property<DateTimeOffset>("Created")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Creator")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<bool>("Deleted")
                                .HasColumnType("boolean");

                            b1.Property<DateTimeOffset>("Modified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Modifier")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("MessageId");

                            b1.ToTable("Messages");

                            b1.WithOwner()
                                .HasForeignKey("MessageId");
                        });

                    b.Navigation("Channel");

                    b.Navigation("ObjectInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("ChillChat.DataModels.Server", b =>
                {
                    b.OwnsOne("ChillChat.DataModels.ObjectInfo", "ObjectInfo", b1 =>
                        {
                            b1.Property<int>("ServerId")
                                .HasColumnType("integer");

                            b1.Property<DateTimeOffset>("Created")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Creator")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<bool>("Deleted")
                                .HasColumnType("boolean");

                            b1.Property<DateTimeOffset>("Modified")
                                .HasColumnType("timestamp with time zone");

                            b1.Property<string>("Modifier")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ServerId");

                            b1.ToTable("Servers");

                            b1.WithOwner()
                                .HasForeignKey("ServerId");
                        });

                    b.Navigation("ObjectInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("ChillChat.DataModels.Server", b =>
                {
                    b.Navigation("Channels");
                });
#pragma warning restore 612, 618
        }
    }
}
