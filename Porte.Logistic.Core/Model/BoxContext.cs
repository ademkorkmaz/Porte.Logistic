using Microsoft.EntityFrameworkCore;
using Porte.Logistic.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Porte.Logistic.Core.Model
{
    public class BoxContext: DbContext
    {
        public static string connStr =
            //@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PorteLogisticData.mdf;Integrated Security=True;";
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MyProjects\Ademk\Porte.Logistic\Porte.Logistic.Core\Data\PorteLogisticData.mdf;Integrated Security = True";
        public DbSet<Box> Boxes { get; set; }
        public DbSet<Part> Parts { get; set; }

        public BoxContext(DbContextOptions<BoxContext> options)
        : base(options)
        {
        }

        public BoxContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(connStr);
        }
    }
}
