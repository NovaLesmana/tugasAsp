using System.ComponentModel.DataAnnotations;

namespace absensionline.Models
{
    public class DataMahasiswa
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nim wajib diisi")]
        public string Nim { get; set; }
        public string Nama { get; set; }
        public string Kelas { get; set; }
        public string Jurusan { get; set; }
    }
}