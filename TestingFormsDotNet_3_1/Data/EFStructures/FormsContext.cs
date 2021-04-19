using Microsoft.EntityFrameworkCore;
using TestingFormsDotNet_3_1.Models.Entities;

namespace TestingFormsDotNet_3_1.Data.Entities
{
    public class FormsContext : DbContext
    {
        public FormsContext(DbContextOptions<FormsContext> options) : base(options)
        {
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormControlForm> FormControlForms { get; set; }
        public DbSet<FormSectionForm> FormSectionForms { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<FormControl> FormControls { get; set; }
        public DbSet<FormSection> FormSections { get; set; }
        public DbSet<FormDataType> FormDataTypes { get; set; }
        public DbSet<MannerOfDeathType> MannerOfDeathTypes { get; set; }
        public DbSet<MannerOfDeathSubType> MannerOfDeathSubTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>().ToTable("Forms");
            modelBuilder.Entity<FormControlForm>().ToTable("FormControlForms");
            modelBuilder.Entity<FormSectionForm>().ToTable("FormSectionForms");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<State>().ToTable("States");
            modelBuilder.Entity<Address>().ToTable("Addresses");
            modelBuilder.Entity<FormControl>().ToTable("FormControls");
            modelBuilder.Entity<FormSection>().ToTable("FormSections");
            modelBuilder.Entity<FormDataType>().ToTable("FormDataTypes");
            modelBuilder.Entity<MannerOfDeathType>().ToTable("MannerOfDeathType");
            modelBuilder.Entity<MannerOfDeathSubType>().ToTable("MannerOfDeathSubType");
        }

    }

}
