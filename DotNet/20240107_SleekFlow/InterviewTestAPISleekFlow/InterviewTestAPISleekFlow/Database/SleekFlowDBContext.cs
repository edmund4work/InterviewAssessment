using System;
using InterviewTestAPISleekFlow.Models;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InterviewTestAPISleekFlow.Database
{
	public class SleekFlowDBContext : DbContext
    {
        public SleekFlowDBContext(DbContextOptions<SleekFlowDBContext> options) : base(options)
        {

        }

        /// <summary>
        /// Commont table
        /// </summary>
        public DbSet<tblCommonTags> tblCommonTags { get; set; }
        public DbSet<tblCommonStatus> tblCommonStatuses { get; set; }

        /// <summary>
        /// Todo Related Table
        /// </summary>
        public DbSet<tblTodo> tblTodo { get; set; }
        public DbSet<tblTodoTags> tblTodoTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionStringsleekflowdb = configuration.GetConnectionString("sleekflowdbConnection");

                //optionsBuilder.UseSqlServer(connectionStringsleekflowdb); //if using tsql
                optionsBuilder.UseMySql(connectionStringsleekflowdb, ServerVersion.AutoDetect(connectionStringsleekflowdb)); //if using mysql
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints here

            modelBuilder.Entity<tblTodo>().HasKey(t => t.Id);
            modelBuilder.Entity<tblCommonTags>().HasKey(t => t.ID);
            modelBuilder.Entity<tblCommonStatus>().HasKey(t => t.statusID);
            modelBuilder.Entity<tblTodoTags>().HasKey(t => t.Id);

            // Add other relationships and constraints as needed
        }
    }
}