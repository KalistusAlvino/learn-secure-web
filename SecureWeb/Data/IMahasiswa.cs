using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecureWeb.Models;

namespace SecureWeb.Data
{
    public interface IMahasiswa
    {
         IEnumerable<Mahasiswa> GetMahasiswa();

        Mahasiswa GetMahasiswa(int nim);
        Mahasiswa AddStudent(Mahasiswa mahasiswas);
        Mahasiswa UpdateStudent(Mahasiswa mahasiswas);
        void DeleteStudent(int nim);
    }
}