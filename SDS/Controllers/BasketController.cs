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
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            List<Basket> listBasket = _context.Basket.ToList();
            List<String> listIdCourse = new List<String>();
            foreach(Basket b in listBasket){
                if(string.Equals(b.idStudent,userId))
                {
                    listIdCourse.Add(b.idCourse);
                }
            }
            var listCourse = _context.Course.ToList();
            var courseBasket = new List<Course>();
            foreach(String courseID in listIdCourse)
            {
                foreach (var c in listCourse)
                {
                    if(c.Id == Int32.Parse(courseID))
                    {
                        courseBasket.Add(c);
                    }
                }
            }
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
            var basket = await _context.Basket.FirstOrDefaultAsync(m => string.Equals(m.idBasket,userId+id));
            if (basket == null)
            {
                return NotFound();
            }
            _context.Basket.Remove(basket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
