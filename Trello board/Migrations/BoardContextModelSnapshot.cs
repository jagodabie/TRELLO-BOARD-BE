﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Trello_board.Migrations
{
    [DbContext(typeof(BoardContext))]
    partial class BoardContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TasksGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkspaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.HasIndex("WorkspaceId");

                    b.ToTable("TasksGroups");
                });

            modelBuilder.Entity("Trello_board.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.Property<int?>("TasksGroupId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WorkspaceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.HasIndex("TasksGroupId");

                    b.HasIndex("WorkspaceId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jagoda.bieniek1234@gmail.com",
                            Name = "Jagoda Bieniek"
                        },
                        new
                        {
                            Id = 2,
                            Email = "jan@gmail.com",
                            Name = "John Doe"
                        });
                });

            modelBuilder.Entity("Trello_board.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("DueDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TasksGroupId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.HasIndex("TasksGroupId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Trello_board.Models.Workspace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("Workspaces");
                });

            modelBuilder.Entity("TasksGroup", b =>
                {
                    b.HasOne("Trello_board.Entities.User", "Author")
                        .WithOne()
                        .HasForeignKey("TasksGroup", "AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Trello_board.Models.Workspace", "Workspace")
                        .WithMany("TasksGroup")
                        .HasForeignKey("WorkspaceId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("Trello_board.Entities.User", b =>
                {
                    b.HasOne("Trello_board.Models.Task", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");

                    b.HasOne("TasksGroup", "TasksGroup")
                        .WithMany()
                        .HasForeignKey("TasksGroupId");

                    b.HasOne("Trello_board.Models.Workspace", "Workspace")
                        .WithMany()
                        .HasForeignKey("WorkspaceId");

                    b.Navigation("Task");

                    b.Navigation("TasksGroup");

                    b.Navigation("Workspace");
                });

            modelBuilder.Entity("Trello_board.Models.Task", b =>
                {
                    b.HasOne("Trello_board.Entities.User", "Author")
                        .WithOne()
                        .HasForeignKey("Trello_board.Models.Task", "AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TasksGroup", "TasksGroup")
                        .WithMany("Tasks")
                        .HasForeignKey("TasksGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("TasksGroup");
                });

            modelBuilder.Entity("Trello_board.Models.Workspace", b =>
                {
                    b.HasOne("Trello_board.Entities.User", "Author")
                        .WithOne()
                        .HasForeignKey("Trello_board.Models.Workspace", "AuthorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("TasksGroup", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Trello_board.Models.Workspace", b =>
                {
                    b.Navigation("TasksGroup");
                });
#pragma warning restore 612, 618
        }
    }
}