using Colaborateur.Models;

namespace Colaborateur.Date
{
    public class AppDbInitialzer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Collaborateur
                if (!context.Collaborateurs.Any())
                {
                    context.Collaborateurs.AddRange(new List<Collaborateur>()
                    {
                        new Collaborateur()
                        {
                             Maricule = "A001" ,FullName = "John Doe", Email = "john.doe@example.com", DateEntree_SQLI = DateTime.Parse("2020-05-12"), CIN="F665214",N_Tel="0643790677"
                        },
                        new Collaborateur()
                        {
                              Maricule = "A002" ,FullName = "Jane Smith", Email = "jane.smith@example.com", DateEntree_SQLI = DateTime.Parse("2021-01-22"),CIN="F665214",N_Tel="0600000000"
                        },
                         new Collaborateur()
                        {
                             Maricule = "A003" , FullName = "Saad Kodade", Email = "saad.kd@example.com", DateEntree_SQLI = DateTime.Parse("2021-12-21"),CIN="F665214",N_Tel="0600000000"
                        },
                        new Collaborateur()
                        {
                              Maricule = "A004" ,FullName = "Mouad Chouya", Email = "Mouad.ch@example.com", DateEntree_SQLI = DateTime.Parse("2022-10-08"),CIN="F801114",N_Tel="0600000000"
                        },
                    });
                    context.SaveChanges();
                }
                //Projets
                if (!context.Projets.Any())
                {
                    context.Projets.AddRange(new List<Projet>()
                    {
                        new Projet()
                        {
                            NomProjet = "Projet A", Description = "Description du projet A", DateDebut = DateTime.Now.AddDays(-10), DateFin = DateTime.Now.AddDays(30),N_Collaborateur=2
                        },
                        new Projet()
                        {
                            NomProjet = "Projet B", Description = "Description du projet B", DateDebut = DateTime.Now.AddDays(-20), DateFin = DateTime.Now.AddDays(5),N_Collaborateur = 2
                        },
                        new Projet()
                        {
                            NomProjet = "Projet C", Description = "Description du projet C", DateDebut = DateTime.Now.AddDays(-1), DateFin = DateTime.Now.AddDays(20), N_Collaborateur=1
                        },
                    });
                    context.SaveChanges();
                }
                //ObjectifsGlobaux
                if (!context.ObjectifsGlobaux.Any())
                {
                    context.ObjectifsGlobaux.AddRange(new List<ObjectifGlobale>()
                    {
                        new ObjectifGlobale()
                        {
                            NoteGlobale = 10 , Description = "Description de l'objectif global 1", Label = "Label 1", CollaborateurId = 1 , DateDubut = DateTime.Now.AddDays(-30), DateFin = DateTime.Now.AddMonths(12)

                        },
                        new ObjectifGlobale()
                        {
                            NoteGlobale = 8 , Description = "Description de l'objectif global 2", Label = "Label 2", CollaborateurId = 2, DateDubut = DateTime.Now.AddDays(-40), DateFin = DateTime.Now.AddMonths(12)

                        },

                        new ObjectifGlobale()
                        {
                            NoteGlobale = 7 , Description = "Description de l'objectif global 1", Label = "Label 1", CollaborateurId = 3, DateDubut = DateTime.Now.AddDays(-10), DateFin = DateTime.Now.AddMonths(12)

                        },
                    });
                    context.SaveChanges();
                }
                //Objectif
                if (!context.Objectifs.Any())
                {
                    context.Objectifs.AddRange(new List<Objectif>()
                    {
                        //ObjectifGloble1
                        new Objectif()
                        {
                            Label = "Objectif 1", Note = 10, Description = "Description de l'objectif 1", ObjectifGlobaleId = 1, Poit_NoteGlobale = 40 , Delai=DateTime.Now.AddDays(20)
                        },
                        new Objectif()
                        {
                            Label = "Objectif 2", Note = 10, Description = "Description de l'objectif 1", ObjectifGlobaleId = 1, Poit_NoteGlobale = 40 ,Delai=DateTime.Now.AddDays(90)
                        },
                        new Objectif()
                        {
                            Label = "Objectif 3", Note = 10, Description = "Description de l'objectif 1", ObjectifGlobaleId = 1, Poit_NoteGlobale = 20 ,Delai=DateTime.Now.AddDays(200)
                        },
                        //ObjectifGlobale2
                        new Objectif()
                        {
                            Label = "Objectif 1", Note = 10, Description = "Description de l'objectif 1", ObjectifGlobaleId = 2, Poit_NoteGlobale = 40,Delai=DateTime.Now.AddDays(89)
                        },
                        new Objectif()
                        {
                            Label = "Objectif 2", Note = 5, Description = "Description de l'objectif 1", ObjectifGlobaleId = 2, Poit_NoteGlobale = 40,Delai=DateTime.Now.AddDays(20)
                        },
                        new Objectif()
                        {
                            Label = "Objectif 3", Note = 10, Description = "Description de l'objectif 1", ObjectifGlobaleId = 2, Poit_NoteGlobale = 20,Delai=DateTime.Now.AddDays(259)
                        },
                        //ObjectifGlobale3
                        new Objectif()
                        {
                            Label = "Objectif 1", Note = 10, Description = "Description de l'objectif 1", ObjectifGlobaleId = 3, Poit_NoteGlobale = 40,Delai=DateTime.Now.AddDays(220)
                        },
                        new Objectif()
                        {
                            Label = "Objectif 2", Note = 5, Description = "Description de l'objectif 1", ObjectifGlobaleId = 3, Poit_NoteGlobale = 40,Delai=DateTime.Now.AddDays(60)
                        },
                        new Objectif()
                        {
                            Label = "Objectif 3", Note = 5, Description = "Description de l'objectif 1", ObjectifGlobaleId = 3, Poit_NoteGlobale = 20,Delai=DateTime.Now.AddDays(45)
                        },
                    });
                    context.SaveChanges();
                }
                //ProjetsCollaborateurs
                if (!context.ProjetsCollaborateurs.Any())
                {
                    context.ProjetsCollaborateurs.AddRange(new List<ProjetCollaborateur>()
                    {
                        new ProjetCollaborateur()
                        {
                            CollaborateurId = 1, ProjetId = 1
                        },
                        new ProjetCollaborateur()
                        {
                            CollaborateurId = 2, ProjetId = 1
                        },
                        new ProjetCollaborateur()
                        {
                            CollaborateurId = 1, ProjetId = 2
                        },
                        new ProjetCollaborateur()
                        {
                            CollaborateurId = 3, ProjetId = 2
                        },
                        new ProjetCollaborateur()
                        {
                            CollaborateurId = 3, ProjetId = 3
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
