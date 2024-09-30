using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecureWeb.Models;

namespace SecureWeb.Data
{
    public class DataMahasiswa : IMahasiswa
    {
        private readonly ApplicationDbContext _db;

        public DataMahasiswa(ApplicationDbContext db)
        {
            _db = db;
        }
        public Mahasiswa AddStudent(Mahasiswa mahasiswas)
        {
            try {
                _db.Mahasiswas.Add(mahasiswas);
                _db.SaveChanges();
                return mahasiswas;
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteStudent(int nim)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mahasiswa> GetMahasiswa()
        {
            var mahasiswas = _db.Mahasiswas.OrderBy(s => s.Nama);
            return mahasiswas;
        }

        public Mahasiswa GetMahasiswa(int nim)
        {
            throw new NotImplementedException();
        }

        public Mahasiswa UpdateStudent(Mahasiswa mahasiswas)
        {
            throw new NotImplementedException();
        }
    }
}