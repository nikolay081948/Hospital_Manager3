using Business.Interfaces;
using Data_Hospital_Manager;
using Data_Hospital_Manager.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly HospitalDbContext context_new;
        public DoctorService(HospitalDbContext context)
        {
            context_new = context;
        }
        public async Task AddDoctorAsync(Doctor doctor)
        {
            context_new.Doctors.Add(doctor);
            await context_new.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor= await context_new.Doctors.Include(x=>x.DoctorPatients).FirstOrDefaultAsync(x => x.Id == id);
            if (doctor != null)
            {
                context_new.DoctorPatients.RemoveRange(doctor.DoctorPatients);
                context_new.Doctors.Remove(doctor);
                await context_new.SaveChangesAsync();
            }
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync(string? search , string? specialty, string? sortOrder)
        {
            var query = context_new.Doctors.Include(d => d.Hospital).Where(d => true);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query=query.Where(d=>d.FirstName.Contains(search)||d.LastName.Contains(search));
            }

            if (!string.IsNullOrWhiteSpace(specialty))
            {
                query=query.Where(d=>d.Specialty.Contains(specialty));
            }

            switch (sortOrder)
            {
                case "name_asc":
                    query=query.OrderBy(d=>d.FirstName).ThenBy(d=>d.LastName);
                    break;
                case "name_desc":
                    query = query.OrderByDescending(d => d.FirstName).ThenByDescending(d => d.LastName);
                    break;
                case "specialty":
                    query = query.OrderBy(d => d.Specialty).ThenBy(d => d.FirstName);
                    break;
                default:
                    query = query.OrderBy(d => d.FirstName).ThenBy(d => d.LastName);
                    break;
            }
            return await query.ToListAsync();
        }

        public async Task<Doctor?> GetDoctorAsync(int id)
        {
            return await context_new.Doctors.FindAsync(id);
        }

        public async Task UpdateDoctorAsync(Doctor doctor)
        {
            await context_new.SaveChangesAsync();
        }
        public async Task<Doctor> GetDoctorDetailsAsync(int id)
        {
             return await context_new.Doctors.Include(x => x.DoctorPatients)
                .ThenInclude(x => x.Patient)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
