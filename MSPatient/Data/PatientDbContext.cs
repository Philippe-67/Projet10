using Microsoft.EntityFrameworkCore;
using MSPatient.Models;

namespace MSPatient.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        
    } 
}
