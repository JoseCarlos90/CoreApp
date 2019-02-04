using CoreApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options){}

        public DbSet<Value> Values { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Like>()
                .HasKey(k => new {k.LikerId, k.LikeeId});

            builder.Entity<Like>()
                .HasOne(u => u.Likee)
                .WithMany(u => u.Likers)
                .HasForeignKey(u => u.LikeeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Like>()
                .HasOne(u => u.Liker)
                .WithMany(u => u.Likees)
                .HasForeignKey(u => u.LikerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Message>() // Significado...
                .HasOne(u => u.Sender) // Un "Sender" (usuario), tiene....
                .WithMany(m => m.MessagesSent) // con muchos (usuarios)...
                .OnDelete(DeleteBehavior.Restrict); // Resticcion de borrar en cascada... un mensaje por mucho que lo borre el usuario
                                                    // el otro usuario al que se lo envio lo seguira viendo...
            
            // Lo mismo para el receptor, que se llama Recipient
            builder.Entity<Message>() 
                .HasOne(u => u.Recipient) 
                .WithMany(m => m.MessagesReceived)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}