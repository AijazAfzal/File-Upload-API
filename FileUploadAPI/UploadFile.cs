using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Office.Interop.Excel;
using OfficeOpenXml;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
     private readonly IWebHostEnvironment _hostingEnvironment; 
     private readonly AppDbContext _appDbContext;
   public EmployeeController(IWebHostEnvironment hostingEnvironment, AppDbContext appDbContext) 
    {
        _hostingEnvironment = hostingEnvironment; 
        _appDbContext = appDbContext; 
    }

    [HttpPost("upload")]
    public IActionResult UploadFile(IFormFile file)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        if (file == null || file.Length == 0)
        {
            return BadRequest("No file provided.");
        }

        string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads", file.FileName);

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyTo(fileStream);
        }

        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var count = package.Workbook.Worksheets.Count;
            var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            if (worksheet == null)
            {
                throw new Exception("Worksheet not found in the Excel file.");
            }
            var rowCount = worksheet.Dimension.Rows;

            var data = new List<Student>(); 

            for (int row = 2; row <= rowCount; row++) 
            {
                var firstname = worksheet.Cells[row, 1].Value?.ToString();
                var lastname = worksheet.Cells[row, 2].Value?.ToString();
                var email = worksheet.Cells[row, 3].Value?.ToString();

                var model = new Student { First_Name = firstname, Last_Name = lastname, Email_address = email }; 
                data.Add(model);
            }

            _appDbContext.Students.AddRange(data);
            _appDbContext.SaveChanges();
        }

        return Ok("Data imported successfully.");



    }
}

