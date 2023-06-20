using Course.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System.IO;
using RevWorld;

namespace RevWorld.Model
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<TagReview> UTagReview { get; set; }

        public void delete_review(int del_id) => throw new NotSupportedException();

        string sql = "select max(bookid) from book";

        private string ConnectionString { get; set; }
        IConfiguration _config;

        //public IQueryable<int> get_by_tag(string name) => FromExpression(() => get_by_tag(name));

        //public IQueryable<User> delete_user2(int id) => FromExpression(() => (IQueryable<Review>)delete_user2(id));
        // public IQueryable<int> delete_review4(int id) => FromExpression(() => delete_review4(id));

        //public IQueryable<Book> delete_book2(int id) => (IQueryable <Book>)FromExpression(() => (IQueryable<Review>)delete_book2(id));

        public ApplicationContext()
        {
            ConfigurationBuilder cfg = new ConfigurationBuilder();
            _config = cfg
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public ApplicationContext(string connect)
        {
            ConnectionString = connect;
        }
        private IQueryable<User> FromExpression(Func<IQueryable<Review>> p)
        {
            throw new NotImplementedException();
        }

        //public ApplicationContext()
        //{ }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            if (!optionsBuilder.IsConfigured)
            {
                /*
                if (Program.globalString == "User")
                {
                    optionsBuilder.UseNpgsql(Connection.GetConnection("User", _config));
                }
                else if (Program.globalString == "Author")
                {
                    optionsBuilder.UseNpgsql(Connection.GetConnection("Author", _config));
                }
                else if (Program.globalString == "Admin")
                {
                    optionsBuilder.UseNpgsql(Connection.GetConnection("Admin", _config));
                }
                */
                //optionsBuilder.UseNpgsql(ConnectionString);
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=dbcourse;Username=postgres;Password=klainer1");
            }
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "English_United States.1252");
            //modelBuilder.HasDbFunction(() => delete_review4(default));
            //modelBuilder.HasDbFunction(() => delete_book2(default));
            //modelBuilder.HasDbFunction(() => delete_user2(default));
            //modelBuilder.HasDbFunction(() => get_by_tag(default));
            //modelBuilder.HasDbFunction(typeof(SalesContext)
            //      .GetMethod(nameof(delete_review),
            //                new[] { typeof(int) }))
            //     .HasName("delete_review");
            // modelBuilder.HasDbFunction(() => sortdate());      

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("userid");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");

                entity.Property(e => e.Email)

                    .HasMaxLength(32)
                    .HasColumnName("email");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(32)
                    .HasColumnName("avatar");

                entity.Property(e => e.Access_role)
                    .HasMaxLength(32)
                    .HasColumnName("access_role");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("review");

                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("reviewid");

                entity.Property(e => e.UserId).HasColumnName("userid");
                entity.Property(e => e.BookId).HasColumnName("bookid");

                entity.Property(e => e.Title)
                    .IsRequired()
                    
                    .HasColumnName("title");

                entity.Property(e => e.NumLikes).HasColumnName("numlikes");

                entity.Property(e => e.Review_data)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("review_data");

                entity.Property(e => e.RaitingBook).HasColumnName("raitingbook");

                entity.Property(e => e.Public_date)
                    .HasColumnType("date")
                    .HasColumnName("public_date");
                
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("review_user_id_fkey");
                
                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("review_book_id_fkey");
                

                modelBuilder.Entity<Book>(entity =>
                {
                    entity.ToTable("book");

                    entity.Property(e => e.BookId)
                        .ValueGeneratedNever()
                        .HasColumnName("bookid");

                    entity.Property(e => e.BookName)
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnName("bookname");

                    entity.Property(e => e.Author)
                        .HasMaxLength(32)
                        .HasColumnName("author");
                    entity.Property(e => e.Path)
                       .HasMaxLength(32)
                       .HasColumnName("path");
                });

                modelBuilder.Entity<Comment>(entity =>
                {
                    entity.ToTable("comment");

                    entity.Property(e => e.CommentId)
                        .ValueGeneratedNever()
                        .HasColumnName("commentid");

                    entity.Property(e => e.UserId).HasColumnName("userid");
                    entity.Property(e => e.ReviewId).HasColumnName("reviewid");

                    entity.Property(e => e.NumLikes).HasColumnName("numlikes");

                    entity.Property(e => e.Comment_data)
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnName("comment_data");

                    entity.Property(e => e.Public_date)
                        .HasColumnType("date")
                        .HasColumnName("public_date");

                    
                    entity.HasOne(d => d.User)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(d => d.UserId)
                        .HasConstraintName("comment_user_id_fkey");

                    

                    entity.HasOne(d => d.Review)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(d => d.ReviewId)
                        .HasConstraintName("comment_review_id_fkey");

                });

                modelBuilder.Entity<Tag>(entity =>
                {
                    entity.ToTable("tag");

                    entity.Property(e => e.TagId)
                        .ValueGeneratedNever()
                        .HasColumnName("tagid");

                    entity.Property(e => e.TagName)
                        .HasMaxLength(32)
                        .HasColumnName("tagname");
                });


                modelBuilder.Entity<TagReview>(entity =>
                {
                    //entity.HasNoKey();
                    entity.Property(e => e.Id).HasColumnName("id");

                    entity.ToTable("tag_to_review");

                    entity.Property(e => e.TagId).HasColumnName("tagid");

                    

                    entity.Property(e => e.ReviewId).HasColumnName("reviewid");

                    entity.HasOne(d => d.Tag)
                        .WithMany()
                        .HasForeignKey(d => d.TagId)
                        .HasConstraintName("review_tag_tag_id_fkey");

                    entity.HasOne(d => d.Review)
                        .WithMany()
                        .HasForeignKey(d => d.ReviewId)
                        .HasConstraintName("review_tag_review_id_fkey");
                });

            });
        }

    }

    internal class SalesContext
    {
    }
}
