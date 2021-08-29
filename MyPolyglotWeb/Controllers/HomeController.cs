﻿using Microsoft.AspNetCore.Mvc;
using MyPolyglotWeb.Models.ViewModels;
using MyPolyglotWeb.Presentation;

namespace MyPolyglotWeb.Controllers
{
    public class HomeController : Controller
    {
        private HomePresentation _homePresentation;

        public HomeController(HomePresentation homePresentation)
        {
            _homePresentation = homePresentation;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Exercise(long lessonId)
        {
            if (lessonId < 1)
            {
                return View(_homePresentation.GetExerciseVM(1));
            }

            var viewModel = _homePresentation.GetExerciseVM(lessonId);

            if (viewModel == null)
            {
                return View(_homePresentation.GetExerciseVM(1));
            } 

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Exercise(ExerciseVM exerciseVM)
        {
            if(!ModelState.IsValid)
            {
                return View(exerciseVM);
            }

            if (_homePresentation.CheckAnswer(exerciseVM.ExerciseId, exerciseVM.UserAnswer))
            {
                TempData["Success"] = "Splendid!";
                return RedirectToAction("Exercise", new { lessonId = exerciseVM.LessonId});
            }

            TempData["Feilure"] = "Please, try again!";

            return View(exerciseVM);
        }
    }
}
