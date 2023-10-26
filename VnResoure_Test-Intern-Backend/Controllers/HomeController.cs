using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using VnResoure_Test_Intern_Backend.AutoMapperProfile;
using VnResoure_Test_Intern_Backend.Models;
using VnResoure_Test_Intern_Backend.Models.DTO;

namespace VnResoure_Test_Intern_Backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private VNR_InternShipContext _context;
        private IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, VNR_InternShipContext context,MappingProfile mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper.MapperProfile();
        }
            
        public async Task<IActionResult> Index()
        {
            List<KhoaHocDTO> courses = _mapper.Map<List<KhoaHoc>, List<KhoaHocDTO>>(await _context.KhoaHoc.ToListAsync());

            TempData["courses"] = JsonConvert.SerializeObject(courses);

            return View();
        }

        public async Task<IActionResult> GetSubjectsOfIdCourse(int idCourse)
        {
            List <MonHocDTO> subjectsOfCourse = _mapper.Map<List<MonHoc>, List<MonHocDTO>>(await _context.MonHoc.Where(item => item.KhoaHocId == idCourse).ToListAsync());
            string nameOfCourse = (await _context.KhoaHoc.FindAsync(idCourse)).TenKhoaHoc;

            ViewData["subjectsOfCourse"] = JsonConvert.SerializeObject(subjectsOfCourse) ;
            ViewData["nameOfCourse"] = "Khóa học: " + nameOfCourse;

            return View("index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}