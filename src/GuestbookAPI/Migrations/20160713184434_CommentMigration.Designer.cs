using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using GuestbookAPI.Models;

namespace GuestbookAPI.Migrations
{
    [DbContext(typeof(GuestbookContext))]
    [Migration("20160713184434_CommentMigration")]
    partial class CommentMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuestbookAPI.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<DateTime>("PostedAt");

                    b.HasKey("Id");

                    b.ToTable("Comments");
                });
        }
    }
}
