using DocsAndHospitals.Models;
using DocsAndHospitals.Factories;
using System;
using System.Linq;

namespace DocsAndHospitals.Services
{
    public class HospitalService
    {
        private Hospital[] _hospitals;

        public HospitalService()
        {
            _hospitals = HospitalFactory.CreateMany();
        }

        public Hospital[] GetAllHospitals() => _hospitals;

        public void AddHospital(Hospital hospital)
        {
            Array.Resize(ref _hospitals, _hospitals.Length + 1);
            _hospitals[^1] = hospital;
        }

        public Hospital? GetHospitalById(int id)
        {
            return _hospitals.FirstOrDefault(h => h.KNumber == id);
        }

        public bool DeleteHospital(int id)
        {
            int initialCount = _hospitals.Length;
            _hospitals = _hospitals.Where(h => h.KNumber != id).ToArray();
            return _hospitals.Length < initialCount;
        }

        public void UpdateHospital(Hospital hospital, string? name = null, string? address = null, string? phone = null)
        {
            if (name != null) hospital.Name = name;
            if (address != null) hospital.Address = address;
            if (phone != null) hospital.PhoneNumber = phone;
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
