using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SDS.Data;
using SDS.Models;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.IO;
using Syncfusion.Pdf.Grid;

namespace SDS.Controllers
{
    public class BasketController : Controller
    {
        private readonly SDSContext _context;
        private readonly SDSAuthContext _userManager;

        public BasketController(SDSContext context, SDSAuthContext userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Basket
        public async Task<IActionResult> Index()
        {
            var courseBasket = getBasketCourse();
            return View(courseBasket);
        }

        public async Task<IActionResult> Add(string id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Basket b = new Basket();
            b.idBasket = userId + id;
            b.idCourse = id;
            b.idStudent = userId;
            List<Basket> listBasket = _context.Basket.ToList();
            foreach (Basket basket in listBasket)
            {
                if (string.Equals(basket.idBasket, b.idBasket))
                {
                    return View();
                }
            }
            _context.Basket.Add(b);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Basket/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comments = _context.Comment.ToArray();
            var course = await _context.Course.FirstOrDefaultAsync(m => m.Id == id);
            return View(course);
        }

        // GET: Basket/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Basket == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var basket = await _context.Basket.FirstOrDefaultAsync(m => string.Equals(m.idBasket, userId + id));
            if (basket == null)
            {
                return NotFound();
            }
            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CreatePDF(string id)
        {

            var courseBasket = getBasketCourse();



            //Generate a new PDF document.
            PdfDocument doc = new PdfDocument();
            //Add a page.
            PdfPage page = doc.Pages.Add();
            //Create a PdfGrid.
            PdfGrid pdfGrid = new PdfGrid();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            //Add values to list
            //Draw the text
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FindAsync(userId);
            graphics.DrawString(user.FirstName + " " + user.LastName, font, PdfBrushes.Black, new PointF(0, 0));

            List<object> data = new List<object>();

            //Object row;
            for (int i = 0; i < courseBasket.Count; i++)
            {
                var course = courseBasket[i];
                var row = new { Name = course.Name, Speciality = course.Speciality, ECTS = course.Ects };
                data.Add(row);
            }

            
            //Add list to IEnumerable
            IEnumerable<object> dataTable = data;
            //Assign data source.
            pdfGrid.DataSource = dataTable;
            //Draw grid to the page of PDF document.
            pdfGrid.Draw(page, new Syncfusion.Drawing.PointF(10, 50));
            //Write the PDF document to stream
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            //If the position is not set to '0' then the PDF will be empty.
            stream.Position = 0;
            //Close the document.
            doc.Close(true);
            //Defining the ContentType for pdf file.
            string contentType = "application/pdf";
            //Define the file name.
            string fileName = "Learning_agreement_" + user.FirstName +"_"+ user.LastName + ".pdf";
            //Creates a FileContentResult object by using the file contents, content type, and file name.
            return File(stream, contentType, fileName);
        }

        private List<Course> getBasketCourse()
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Basket> listBasket = _context.Basket.ToList();
            List<String> listIdCourse = new List<String>();
            foreach (Basket b in listBasket)
            {
                if (string.Equals(b.idStudent, userId))
                {
                    listIdCourse.Add(b.idCourse);
                }
            }
            var listCourse = _context.Course.ToList();
            var courseBasket = new List<Course>();
            foreach (String courseID in listIdCourse)
            {
                foreach (var c in listCourse)
                {
                    if (c.Id == Int32.Parse(courseID))
                    {
                        courseBasket.Add(c);
                    }
                }
            }
            return courseBasket;
        }

    }
}
