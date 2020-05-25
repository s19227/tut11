using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut11.Entities;
using tut11.Requests;
using tut11.Services;

namespace tut11.DAL
{
    public class DbService : IDbService
    {
        private readonly DoctorDbContext _context;

        public DbService(DoctorDbContext context)
        {
            _context = context;
        }

        public List<Doctor> GetDoctors()
        {
            return _context.Doctors.ToList();
        }

        public List<Doctor> SeedData()
        {
            /* Doctors */
            _context.Doctors.Add(new Doctor {
                FirstName = "Greg",
                LastName = "House",
                Email = "doctor@example.com"
            });

            _context.Doctors.Add(new Doctor {
                FirstName = "John",
                LastName = "Watson",
                Email = "doctor@example.com"
            });

            /* Patients */
            _context.Patients.Add(new Patient {
                FirstName = "Jan",
                LastName = "Kowalski",
                BirthDate = new DateTime(1990, 10, 1)
            });

            _context.Patients.Add(new Patient {
                FirstName = "Very",
                LastName = "Sick",
                BirthDate = new DateTime(1994, 8, 13)
            });

            /* Prescriptions */
            _context.Prescriptions.Add(new Prescription {
                Date = new DateTime(2019, 6, 25),
                DueDate = new DateTime(2020, 6, 25),
                IdDoctor = 1,
                IdPatient = 1
            });

            _context.Prescriptions.Add(new Prescription {
                Date = new DateTime(2019, 6, 25),
                DueDate = new DateTime(2020, 6, 25),
                IdDoctor = 2,
                IdPatient = 1
            });

            _context.Prescriptions.Add(new Prescription {
                Date = new DateTime(2019, 6, 25),
                DueDate = new DateTime(2020, 6, 25),
                IdDoctor = 1,
                IdPatient = 2
            });

            /* Medicaments */
            _context.Medicaments.Add(new Medicament {
                Name = "Med1",
                Description = "Med1",
                Type = "Med1"
            });

            _context.Medicaments.Add(new Medicament {
                Name = "Med2",
                Description = "Med2",
                Type = "Med2"
            });

            /* Prescription_Medicaments */
            _context.Prescription_Medicaments.Add(new Prescription_Medicament {
                IdMedicament = 1,
                IdPrescription = 1,
                Details = "123"
            });

            _context.Prescription_Medicaments.Add(new Prescription_Medicament {
                IdMedicament = 1,
                IdPrescription = 2,
                Details = "123"
            });

            _context.Prescription_Medicaments.Add(new Prescription_Medicament {
                IdMedicament = 2,
                IdPrescription = 3,
                Details = "123"
            });

            try { _context.SaveChanges(); } 
            catch (DbUpdateException) { return null; }

            return GetDoctors();
        }

        public Doctor AddDoctor(AddDoctorReq request)
        {
            Doctor doctor = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            _context.Doctors.Add(doctor);

            try { _context.SaveChanges(); }
            catch (DbUpdateException) { return null; }

            return doctor;
        }

        public List<Doctor> DeleteDoctor(int id)
        {
            Doctor doctor = _context.Doctors
                .AsEnumerable()
                .First(d => d.IdDoctor == id);

            _context.Doctors.Remove(doctor);

            try { _context.SaveChanges(); }
            catch (DbUpdateException) { return null; }

            return GetDoctors();
        }

        public Doctor GetDoctor(int id)
        {
            Doctor doctor = _context.Doctors
                .AsEnumerable()
                .First(d => d.IdDoctor == id);

            return doctor;
        }

        public Doctor UpdateDoctor(UpdateDoctorReq request)
        {
            Doctor doctor = _context.Doctors
                .AsEnumerable()
                .First(d => d.IdDoctor == request.IdDoctor);

            doctor.FirstName = request.FirstName;
            doctor.LastName = request.LastName;
            doctor.Email = request.Email;

            try { _context.SaveChanges(); }
            catch (DbUpdateException) { return null; }

            return doctor;
        }
    }
}
