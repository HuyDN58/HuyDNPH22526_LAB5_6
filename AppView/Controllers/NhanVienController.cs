using AppData.Model;
using AppView.IServices;
using AppView.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly ILogger<NhanVienController> _logger;
        private readonly INhanVienService NhanVienServices; // interface
        public NhanVienController(ILogger<NhanVienController> logger)
        {
            _logger = logger;
            NhanVienServices = new NhanVienService();
        }

        public async Task<IActionResult> ShowAllColor()
        {
            string apiUrl = "https://localhost:7262/api/NhanVien";
            var httpClient = new HttpClient(); // tạo ra để callApi
            var response = await httpClient.GetAsync(apiUrl);// Lấy dữ liệu ra từ API URL
                                                             // Lấy dữ liệu Json trả về từ Api được call dạng string
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kqua trả về từ API dạng Json
            // Đọc từ string Json vừa thu được sang double
            var colors = JsonConvert.DeserializeObject<List<NhanVien>>(apiData);
            return View(colors);
        }
        
        public IActionResult Create() // Hiển thị form ra cho người dùng
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            return Content("Them Thai Bai");
        }
        [HttpPost]
        public IActionResult Create(NhanVien product) // Thực hiện thêm
        {
            // Trong trường hợp chúng ta thực hiện với thuộc tính Description
            // Thuộc tính này đang là string => Không thể thao tác trực tiếp
            // với các file => Truyền thêm 1 tham số vào Action này
            // Truyền thêm 1 tham số imageFile kiểu IFormFile
            // Bước 1: Kiểm tra đường dãn tới ảnh được lấy từ form

            if (NhanVienServices.Create(product))
            {
                return RedirectToAction("ShowAllColor");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            if (NhanVienServices.Delete(id))
            {
                return RedirectToAction("ShowAllColor");
            }
            else return BadRequest();
        }

        public IActionResult Details(Guid id)
        {
            var products = NhanVienServices.GetProductById(id);
            return View(products);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            NhanVien p = NhanVienServices.GetProductById(id);
            return View(p);
        }

        public IActionResult Edit(NhanVien p)
        {
            if (NhanVienServices.Update(p))
                return RedirectToAction("ShowAllColor");
            return BadRequest();
        }
    }
}
