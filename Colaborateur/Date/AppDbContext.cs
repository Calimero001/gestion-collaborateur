using Colaborateur.Models;
using Microsoft.EntityFrameworkCore;

namespace Colaborateur.Date
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjetCollaborateur>().HasKey(pc => new { pc.ProjetId, pc.CollaborateurId });

            modelBuilder.Entity<ProjetCollaborateur>().HasOne(pc => pc.Projet).WithMany(p => p.ProjetCollaborateurs).HasForeignKey(pc => pc.ProjetId);

            modelBuilder.Entity<ProjetCollaborateur>().HasOne(pc => pc.Collaborateur).WithMany(c => c.ProjetCollaborateurs).HasForeignKey(pc => pc.CollaborateurId);

            modelBuilder.Entity<Objectif>().HasOne(o => o.ObjectifGlobale).WithMany(og => og.Objectifs).HasForeignKey(o => o.ObjectifGlobaleId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Collaborateur> Collaborateurs { get; set; }
        public DbSet<Projet> Projets { get; set; }
        public DbSet<ObjectifGlobale> ObjectifsGlobaux { get; set; }
        public DbSet<Objectif> Objectifs { get; set; }
        public DbSet<ProjetCollaborateur> ProjetsCollaborateurs { get; set; }
    }
}
