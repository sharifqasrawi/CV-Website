using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace My_Personal_Website.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<CVPersonalModel> CVPersonalInfo { get; set; }
        public DbSet<CVEduModel> CVEducation { get; set; }
        public DbSet<CVProfModel> Profs { get; set; }

        public DbSet<CVSkillsModel> Skills { get; set; }
        public DbSet<CVTrainingModel> Trainings { get; set; }

        public DbSet<CVLangModel> Languages { get; set; }
        public DbSet<MessageModel> Messages { get; set; }
        public DbSet<EduProject> EduProjects { get; set; }
        public DbSet<ProfRefs> ProRefs { get; set; }

        public DbSet<AddressModel> Address { get; set; }
        public DbSet<SocialModel> Social { get; set; }

    }
}