using EmployeeManagement.Core.Models;
using EmployeeManagement.Service.Services.IService;
using EmployeeManagement.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

public class EmployeeController : Controller
{
    private readonly IEmployeeService _employeeService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public EmployeeController(
        IEmployeeService employeeService,
        IWebHostEnvironment webHostEnvironment)
    {
        _employeeService = employeeService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var obj = await _employeeService.GetAllAsync();
        return View(obj);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EmployeeViewModel emp)
    {
        if (ModelState.IsValid)
        {
            var obj = new Employee();

            var path = _webHostEnvironment.WebRootPath;
            var filePath = "images/" + emp.ImageFile.FileName;
            var fullPath = Path.Combine(path, filePath);

            // Resize and upload image
            FileUpload(emp.ImageFile, fullPath);

            obj.FirstName = emp.FirstName;
            obj.LastName = emp.LastName;
            obj.DateOfBirth = emp.DateOfBirth;
            obj.Email = emp.Email;
            obj.Mobile = emp.Mobile;
            obj.PhotoPath = filePath;

            await _employeeService.InsertAsync(obj);

            return RedirectToAction("Index");
        }

        return View(emp);
    }

    // Method to upload and resize image
    public void FileUpload(IFormFile file, string path)
    {
        // Resize dimensions
        int width = 50;  // You can adjust these values based on your requirements
        int height = 50;

        using (var stream = new MemoryStream())
        {
            file.CopyTo(stream);
            using (var img = System.Drawing.Image.FromStream(stream))
            {
                // Resize the image
                var resizedImage = new Bitmap(img, new Size(width, height));

                // Save the resized image to the desired path
                resizedImage.Save(path);
            }
        }
    }

    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var obj = await _employeeService.GetIdAsync(id);
        return View(obj);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Employee emp)
    {
        await _employeeService.UpdateAsync(emp);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var obj = await _employeeService.GetIdAsync(id);
        await _employeeService.DeleteAsync(obj);
        return Json(new { success = true });
    }
}
