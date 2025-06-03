using DocsAndHospitals.Models;
using System.Collections.Generic;

namespace DocsAndHospitals.Persistence;

public interface IHospitalRepository
{
    void Save(IEnumerable<Hospital> hospitals);
    List<Hospital> Load();
}
