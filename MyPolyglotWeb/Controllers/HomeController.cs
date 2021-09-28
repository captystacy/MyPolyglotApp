﻿using Microsoft.AspNetCore.Mvc;
using MyPolyglotWeb.Models.ViewModels;
using MyPolyglotWeb.Presentations;

namespace MyPolyglotWeb.Controllers
{
    public class HomeController : Controller
    {
        private HomePresentation _homePresentation;

        public HomeController(HomePresentation homePresentation)
        {
            _homePresentation = homePresentation;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ShowExercise(long lessonId)
        {
            if (lessonId < 1 || lessonId > 31)
            {
                return View(_homePresentation.GetExerciseVM(1));
            }

            var viewModel = _homePresentation.GetExerciseVM(lessonId);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ShowExercise(ShowExerciseVM exerciseVM)
        {
            if (!ModelState.IsValid)
            {
                return View(exerciseVM);
            }

            if (!_homePresentation.CheckAnswer(exerciseVM.ExerciseId, exerciseVM.UserAnswer))
            {
                TempData["Feilure"] = "Please, try again!";
                return View(exerciseVM);
            }

            TempData["Success"] = "Splendid!";
            if (User.Identity.IsAuthenticated)
            {
                _homePresentation.PlusPoint(exerciseVM.LessonId);
            }

            return RedirectToAction("ShowExercise", new { lessonId = exerciseVM.LessonId });
        }
    }
}
