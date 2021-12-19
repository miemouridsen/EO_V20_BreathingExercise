using EO_V20_BreathingExercise2.Data;
using EO_V20_BreathingExercise2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EO_V20_BreathingExercise2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Breathing()
        {
            return View();
        }
        [Authorize]
        public async Task<IActionResult> AddExercise(int min)
        {
            var exercise = new Exercise();
            exercise.Id = Guid.NewGuid();
            exercise.Minutes = min;
            exercise.Date = DateTime.Now;
            exercise.UserName = User.Identity.Name;

            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return Redirect("/Home/Progress");
        }
        [Authorize]
        public async Task<IActionResult> Progress(ExercisePagemodel model)
        {
            List<Exercise> exercises = await _context.Exercises.Where(u => User.Identity.Name == u.UserName).ToListAsync();
            //List<Exercise> exercises = await _context.Exercises.ToListAsync();
            model.Exercises = exercises;
            foreach (Exercise e in exercises)
            {
                model.TotalMinutes += e.Minutes;
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
