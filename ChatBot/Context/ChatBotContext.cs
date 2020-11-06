using ChatBot.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatBot.Context
{
    public class ChatBotContext : DbContext
    {

        public ChatBotContext(DbContextOptions<ChatBotContext> options) : base(options)
        {

        }

        public DbSet<IntentsReponse> IntentsReponse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IntentsReponse>().ToTable("IntentsReponse");
        }
    }
}
