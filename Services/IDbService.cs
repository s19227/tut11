using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tut11.Entities;
using tut11.Requests;

namespace tut11.Services
{
    public interface IDbService
    {
        /* List all doctors */
        public List<Doctor> GetDoctors();

        /* Generate sample data */
        public List<Doctor> SeedData();

        /* Get doctor data based on id */
        public Doctor GetDoctor(int id);

        /* Add new doctor */
        public Doctor AddDoctor(AddDoctorReq request);

        /* Update doctor data */
        public Doctor UpdateDoctor(UpdateDoctorReq request);

        /* Delete doctor by id */
        public List<Doctor> DeleteDoctor(int id);
    }
}
