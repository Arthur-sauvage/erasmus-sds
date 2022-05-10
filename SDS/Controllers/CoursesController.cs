#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SDS.Models;

namespace SDS.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SDSContext _context;

        public CoursesController(SDSContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await _context.Course.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            
            var comments = _context.Comment.ToArray();
            /*
            System.Diagnostics.Debug.WriteLine("IIIIIIIIIIIICCCCCCCCCCCCCCCIIIIIIIIIIIIIIIIIIIIIIIIIIIII");
            int i = 0;
            foreach (var comment in comments)
            {
                System.Diagnostics.Debug.WriteLine("i : " + comment.CommentStudent);
                i++;
            }
            System.Diagnostics.Debug.WriteLine("Fin");
            */
            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Speciality,Ects,Likes,Difficulty")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> Like(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            try
                {
                    course.Likes += 1; 
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Speciality,Ects,Likes,Difficulty")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var course = await _context.Course.FindAsync(id);
            _context.Course.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Course.Any(e => e.Id == id);
        }


        // GET: Courses/Comments
        public async Task<IActionResult> Comments(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Course
                .FirstOrDefaultAsync(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/CommentTest/7
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Comments(int id,string comment,string gradeDifficulty, string gradeQuality/*, string gradeQuality*/)
        {
            /*
             //var c = await _context.Course.FindAsync(id);
             if (id != course.Id)
             {
                 return NotFound();
             }*/
            var course = await _context.Course.FindAsync(id);
            if (ModelState.IsValid)
            {


                Comment newC = new Comment() {
                    CommentStudent = comment,
                    DifficultyC = Int32.Parse(gradeDifficulty),
                    QualityC = Int32.Parse(gradeQuality)
                };
                /*
                if (newC.IdStudent == null)
                {
                    newC.IdStudent = 0;
                }
                else { 
                    newC.IdStudent = newC.IdStudent + 1;
                }*/
                //Random rnd = new Random();
                //newC.IdStudent = rnd.Next(0, 55);
                
                var l = course.AllComments;
                if(l == null)
                {
                    l = new List<Comment>();
                }
                l.Add(newC);
                course.AllComments = l;


                
                
                try
                {
                    if(course.Quality == null){
                        course.Quality = 5;
                    }
                    
                    course.Difficulty = (Int32.Parse(gradeDifficulty)+course.Difficulty)/(course.AllComments.Count()+1);
                    course.Quality = (Int32.Parse(gradeQuality) + course.Quality) / (course.AllComments.Count() + 1);
                    //= Int32.Parse(gradeDifficulty);
                    //_context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }


    }


    
}
