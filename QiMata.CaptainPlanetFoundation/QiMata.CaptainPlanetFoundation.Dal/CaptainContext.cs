namespace QiMata.CaptainPlanetFoundation.Dal
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CaptainContext : DbContext
    {
        public CaptainContext()
            : base("name=CaptainContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<AquaponicProject> AquaponicProjects { get; set; }
        public virtual DbSet<EditableGarden> EditableGardens { get; set; }
        public virtual DbSet<HabitatRestoration> HabitatRestorations { get; set; }
        public virtual DbSet<PlantType> PlantTypes { get; set; }
        public virtual DbSet<PollinatorGarden> PollinatorGardens { get; set; }
        public virtual DbSet<ProjectBase> ProjectBases { get; set; }
        public virtual DbSet<Reforestation> Reforestations { get; set; }
        public virtual DbSet<RenewableEnergy> RenewableEnergies { get; set; }
        public virtual DbSet<TargetedSpecy> TargetedSpecies { get; set; }
        public virtual DbSet<TreeSpecy> TreeSpecies { get; set; }
        public virtual DbSet<TypeOfWaste> TypeOfWastes { get; set; }
        public virtual DbSet<TypesGrown> TypesGrowns { get; set; }
        public virtual DbSet<WasteDiversion> WasteDiversions { get; set; }
        public virtual DbSet<WaterQualityMonitoring> WaterQualityMonitorings { get; set; }
        public virtual DbSet<WaterTest> WaterTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AquaponicProject>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<AquaponicProject>()
                .Property(e => e.UseOfHarvest)
                .IsUnicode(false);

            modelBuilder.Entity<AquaponicProject>()
                .HasMany(e => e.TypesGrowns)
                .WithRequired(e => e.AquaponicProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EditableGarden>()
                .Property(e => e.UseOfHarvest)
                .IsUnicode(false);

            modelBuilder.Entity<HabitatRestoration>()
                .Property(e => e.SizeOfRestoration)
                .HasPrecision(18, 5);

            modelBuilder.Entity<HabitatRestoration>()
                .Property(e => e.UnitsOfRestoration)
                .IsUnicode(false);

            modelBuilder.Entity<HabitatRestoration>()
                .Property(e => e.AddedOrRestored)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HabitatRestoration>()
                .Property(e => e.RestorationType)
                .IsUnicode(false);

            modelBuilder.Entity<HabitatRestoration>()
                .HasMany(e => e.TargetedSpecies)
                .WithRequired(e => e.HabitatRestoration)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlantType>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<PollinatorGarden>()
                .Property(e => e.GardentLocation)
                .IsUnicode(false);

            modelBuilder.Entity<PollinatorGarden>()
                .HasMany(e => e.PlantTypes)
                .WithRequired(e => e.PollinatorGarden)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectBase>()
                .Property(e => e.ProjectName)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectBase>()
                .Property(e => e.ClassName)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectBase>()
                .Property(e => e.DataReportedLocation)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectBase>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.AquaponicProject)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.EditableGarden)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.HabitatRestoration)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.PollinatorGarden)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.Reforestation)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.RenewableEnergy)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.TreeSpecy)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.WasteDiversion)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<ProjectBase>()
                .HasOptional(e => e.WaterQualityMonitoring)
                .WithRequired(e => e.ProjectBase);

            modelBuilder.Entity<Reforestation>()
                .Property(e => e.AreaOfTreesUnits)
                .IsUnicode(false);

            modelBuilder.Entity<Reforestation>()
                .HasMany(e => e.TreeSpecies)
                .WithRequired(e => e.Reforestation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RenewableEnergy>()
                .Property(e => e.TypeOfEnergy)
                .IsUnicode(false);

            modelBuilder.Entity<TargetedSpecy>()
                .Property(e => e.SpeciesName)
                .IsUnicode(false);

            modelBuilder.Entity<TreeSpecy>()
                .Property(e => e.Species)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOfWaste>()
                .Property(e => e.TypeOfWaste1)
                .IsUnicode(false);

            modelBuilder.Entity<TypesGrown>()
                .Property(e => e.TypeGrown)
                .IsUnicode(false);

            modelBuilder.Entity<WasteDiversion>()
                .Property(e => e.AmountDiverted)
                .HasPrecision(18, 5);

            modelBuilder.Entity<WasteDiversion>()
                .Property(e => e.Units)
                .IsUnicode(false);

            modelBuilder.Entity<WasteDiversion>()
                .HasMany(e => e.TypeOfWastes)
                .WithRequired(e => e.WasteDiversion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WaterQualityMonitoring>()
                .Property(e => e.FrequencyOfTest)
                .IsUnicode(false);

            modelBuilder.Entity<WaterQualityMonitoring>()
                .HasMany(e => e.WaterTests)
                .WithRequired(e => e.WaterQualityMonitoring)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WaterTest>()
                .Property(e => e.Test)
                .IsUnicode(false);
        }
    }
}
