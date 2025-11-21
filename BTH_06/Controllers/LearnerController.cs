using System;
using BTH_06.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BTH_06.Controllers
{
    public class LearnerController : Controller
    {
        private int pageSize = 3;
        private SchoolContext db;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        public IActionResult Index(string? mid)
        {
            var learners = (IQueryable<Learner>)db.Learners.Include(m => m.Major);
            if (mid!=null)
            {
                learners = (IQueryable<Learner>)db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major).ToList();
                return View(learners);
            }
            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);

            ViewBag.pageNum = pageNum;
            var res = learners.Take(pageSize).ToList();
            return View(res);
        }

        public IActionResult Create()
        {
            ViewBag.Majors = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Learner learner)
        {
            ModelState.Remove("Major");

            if (ModelState.IsValid)
            {
                try
                {
                    db.Learners.Add(learner);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi lưu dữ liệu: " + ex.Message);
                }
            }
            ViewBag.Majors = new SelectList(db.Majors, "MajorID", "MajorName", learner?.MajorID);
            return View(learner);
        }

        // GET: Learner/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }

            ViewBag.Majors = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // POST: Learner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, Learner learner)
        {
            if (id != learner.LearnerId)
            {
                return NotFound();
            }

            ModelState.Remove("Major");

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lỗi khi cập nhật dữ liệu: " + ex.Message);
                }
            }
            ViewBag.Majors = new SelectList(db.Majors, "MajorID", "MajorName", learner?.MajorID);
            return View(learner);
        }

        // GET: Learner/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learner = db.Learners
                .Include(m => m.Major)
                .FirstOrDefault(m => m.LearnerId == id);

            if (learner == null)
            {
                return NotFound();
            }

            return View(learner);
        }

        // POST: Learner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var learner = db.Learners
                .Include(m => m.Major)
                .FirstOrDefault(m => m.LearnerId == id);

            if (learner == null)
            {
                return NotFound();
            }

            try
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi xóa dữ liệu: " + ex.Message);
                return View(learner);
            }
        }

        private bool LearnerExists(string id)
        {
            return db.Learners.Any(e => e.LearnerId == id);
        }


        public IActionResult LearnerByMajorID(string mid)
        {
            // quick sanity: treat null/empty as "all"
            if (string.IsNullOrWhiteSpace(mid))
            {
                var all = db.Learners.Include(m => m.Major).ToList();
                return PartialView("LearnerTable", all);
            }

            mid = mid.Trim();

            // Use case-insensitive comparison to avoid mismatch due to casing
            var learners = db.Learners
                .Where(l => l.MajorID.ToLower() == mid.ToLower())
                .Include(m => m.Major)
                .ToList();

            return PartialView("LearnerTable", learners);
        }

        public IActionResult LearnerFilter(string? mid,string? keyword, int? pageIndex)
        {
            var learners = (IQueryable<Learner>)db.Learners;
            int page= (int) (pageIndex == null || pageIndex <= 0 ? 1 : pageIndex);
            if (mid != null)
            {
                learners = learners.Where(l => l.MajorID == mid);
                ViewBag.mid = mid;
            }

            if (keyword != null)
            {
                learners = learners.Where(l => l.LastMidName.ToLower().Contains(keyword.ToLower()));

                ViewBag.keyword = keyword; 
            }

            int pageNum = (int)Math.Ceiling(learners.Count() / (float)pageSize);
        
            ViewBag.pageNum = pageNum;
            var res = learners.Skip(pageSize * (page-1)).Take(pageSize).Include(m => m.Major);

            return PartialView("LearnerTable", res);
        }
    }
}
