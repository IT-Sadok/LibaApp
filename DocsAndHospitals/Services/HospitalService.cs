using DocsAndHospitals.Models;
using DocsAndHospitals.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocsAndHospitals.Services
{
    public class HospitalService
    {
        private readonly List<Hospital> _hospitals;
        private readonly HospitalFactory _hospitalFactory;

        public HospitalService(HospitalFactory hospitalFactory)
        {
            _hospitalFactory = hospitalFactory;
            _hospitals = _hospitalFactory.CreateMany().ToList();
        }

        public Hospital[] GetAllHospitals() => _hospitals.ToArray();

        public void AddHospital(Hospital hospital)
        {
            _hospitals.Add(hospital);
        }

        public Hospital? GetHospitalById(int id)
        {
            return _hospitals.FirstOrDefault(h => h.KNumber == id);
        }

        public bool DeleteHospital(int id)
        {
            var hospital = GetHospitalById(id);
            if (hospital == null)
                return false;

            return _hospitals.Remove(hospital);
        }


        public void UpdateHospital(Hospital hospital, string? name = null, string? address = null, string? phone = null)
        {
            if (!string.IsNullOrWhiteSpace(name)) hospital.Name = name;
            if (!string.IsNullOrWhiteSpace(address)) hospital.Address = address;
            if (!string.IsNullOrWhiteSpace(phone)) hospital.PhoneNumber = phone;
        }

        public void AddDoctor(Hospital hospital, Doctor doctor)
        {
            hospital.Doctors.Add(doctor);
        }

        public Doctor? GetDoctor(Hospital hospital, int doctorId)
        {
            return hospital.Doctors.FirstOrDefault(d => d.KNumber == doctorId);
        }

        public void UpdateDoctor(Doctor doctor, string? name = null, string? specialization = null)
        {
            if (name != null) doctor.Name = name;
            if (specialization != null) doctor.Specialization = specialization;
        }

        public void DeleteDoctor(Hospital hospital, int doctorId)
        {
            hospital.Doctors.RemoveAll(d => d.KNumber == doctorId);
        }
    }
}
