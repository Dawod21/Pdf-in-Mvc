using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;
using PDFMvc.Models;

namespace PDFMvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            FBEntities obj = new FBEntities();

            return View(from Employee in obj.Employees.Take(10)select Employee);
        }

        [HttpPost]
        [ValidateInput(false)]
        public FileResult Export(string GridHtml)
        {
            using(MemoryStream stream=new MemoryStream())
            {
                StringReader sr = new StringReader(GridHtml);
                Document pdf = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdf, stream);
                pdf.Open();
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdf, sr);
                pdf.Close();
                return File(stream.ToArray(), "application/pdf", "Grid.pdf");
            }
        }
    }
}