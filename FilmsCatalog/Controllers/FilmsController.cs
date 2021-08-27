using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FilmsCatalog.Data;
using FilmsCatalog.Models;
using AutoMapper;
using FilmsCatalog.ViewModels;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using cloudscribe.Pagination.Models;
using System.Threading;

namespace FilmsCatalog.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FilmsController(ApplicationDbContext context, IMapper mapper, SignInManager<User> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this._mapper = mapper;
            _signInManager = signInManager;
            this._webHostEnvironment = webHostEnvironment;
        }

        [Authorize]
        // GET: Films
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 3, CancellationToken cancellationToken = default(CancellationToken))
        {
            var offset = (pageSize * pageNumber) - pageSize;

            var query = _context.Film.Skip(offset).Take(pageSize).Select(x => _mapper.Map<FilmForTableViewModel>(x));//.ProjectTo<FilmForTableViewModel>(_mapper.ConfigurationProvider);


            var result = new PagedResult<FilmForTableViewModel>();
            result.Data = await query.AsNoTracking().ToListAsync(cancellationToken);
            result.TotalItems = await _context.Film.CountAsync();
            result.PageNumber = pageNumber;
            result.PageSize = pageSize;

            return View(result);
        }

        // GET: Films/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FilmViewModel>(film));
        }

        // GET: Films/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Films/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Year,Director,PosterImage")] FilmViewModel film)
        {
            if (ModelState.IsValid)
            {
                var newFilm = _mapper.Map<Film>(film);
                newFilm.UserId = _signInManager.UserManager.GetUserId(User);

                string fileName = UploadFile(film);
                newFilm.PosterFileName = fileName;

                _context.Add(newFilm);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film);
        }

        private string UploadFile(FilmViewModel filmViewModel)
        {
            var fileName = string.Empty;
            if (filmViewModel.PosterImage != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                fileName = Guid.NewGuid().ToString() + "-" + filmViewModel.PosterImage.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    filmViewModel.PosterImage.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        // GET: Films/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            return View(_mapper.Map<FilmViewModel>(film));
        }

        // POST: Films/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Year,Director,PosterImage")] FilmViewModel film)
        {
            if (id != film.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = UploadFile(film);
                    film.PosterFileName = fileName;

                    _context.Update(_mapper.Map<Film>(film));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmExists(film.Id))
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

            return View(film);
        }

        // GET: Films/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film = await _context.Film
                .FirstOrDefaultAsync(m => m.Id == id);
            if (film == null)
            {
                return NotFound();
            }

            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var film = await _context.Film.FindAsync(id);
            _context.Film.Remove(film);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmExists(int id)
        {
            return _context.Film.Any(e => e.Id == id);
        }
    }
}
