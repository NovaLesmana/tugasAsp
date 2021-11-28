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
        public void OnGet()
        {

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