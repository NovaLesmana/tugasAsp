using System.Collections.Generic;
using absensionline.Models;
using absensionline.pages.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace absensionline.Pages
{
    public class MahasiswaModel : PageModel
    {
        private readonly ILogger<MahasiswaModel> _logger;

        public MahasiswaModel(ILogger<MahasiswaModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public Mahasiswa Mhs { get; set; }

        [BindProperty]
        public List<DataMahasiswa> DataMahasiswa { get; set; }

        public IActionResult OnGet()
        {
            koneksiDB conn = new koneksiDB();
            if (conn.checkConnection())
            {
                TempData["cekkoneksi"] = "sukses koneksi DB";
            }
            else
            {
                TempData["cekkoneksi"] = "gagal koneksi DB";
            }
            ProsesMahasiswa proses = new ProsesMahasiswa();
            DataMahasiswa = proses.getMahasiswa();
            return Page();
        }
        public IActionResult OnPost()
        {
            TempData["namaMahasiswa"] = Mhs.Nama;
            TempData["kelasMahasiwa"] = Mhs.Kelas;
            TempData["tempatMahasiswa"] = Mhs.TempatLahir;
            TempData["tglMahasiswa"] = Mhs.TglLahir;
            TempData["tinggiMahasiswa"] = Mhs.TinggiBadan;
            TempData["hpMahasiswa"] = Mhs.Hp;
            return Page();
        }
    }
}