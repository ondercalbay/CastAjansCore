﻿using CastAjansCore.Business.Abstract;
using CastAjansCore.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CastAjansCore.WebUI.Controllers
{
    public class IllerController : Controller
    {
        private readonly IIlServis _IlServis;        

        public IllerController(IIlServis IlServis)
        {
            _IlServis = IlServis;            
        }

        // GET: Ils
        //public async Task<IActionResult> Index()
        //{
        //    var Illar = await _IlServis.GetListAsync();
        //    return View(Illar);
        //}

        public async Task<IActionResult> Index()
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            var Illar = await _IlServis.GetListAsync();
            return View(Illar);
        }

        // GET: Ils/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            if (id == null)
            {
                return NotFound();
            }

            var entity = await _IlServis.GetByIdAsync(id.Value);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        
        // GET: Ils/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            if (id == null)
            {
                return View(new Il());
            }
            else
            {
                var entity = await _IlServis.GetByIdAsync(id.Value);
                if (entity == null)
                {
                    return NotFound();
                }

                return View(entity);
            }
        }

        // POST: Ils/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Il Il)
        {
            if (ModelState.IsValid)
            {
                try
                { 
                    if (id == null || id == 0)
                    {                      
                        await _IlServis.AddAsync(Il, HttpContext.Session.GetUserHelper());
                    }
                    else
                    {
                        if (id != Il.Id)
                        {
                            return NotFound();
                        }
                        await _IlServis.UpdateAsync(Il, HttpContext.Session.GetUserHelper());
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await IlExistsAsync(Il.Id))
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

            return View(Il);
        }

        // GET: Ils/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            ViewData["UserHelper"] = HttpContext.Session.GetUserHelper();
            if (id == null)
            {
                return NotFound();
            }

            var Il = await _IlServis.GetByIdAsync(id.Value);
            if (Il == null)
            {
                return NotFound();
            }

            return View(Il);
        }

        // POST: Ils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _IlServis.DeleteAsync(id, HttpContext.Session.GetUserHelper());
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> IlExistsAsync(int id)
        {
            Il entity = await _IlServis.GetByIdAsync(id);
            return entity != null;
        }
    }
}
