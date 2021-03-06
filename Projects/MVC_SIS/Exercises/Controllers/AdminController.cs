﻿using Exercises.Models.Data;
using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exercises.Controllers
{
    public class AdminController : Controller
    {

        [HttpGet]
        public ActionResult Majors()
        {
            var model = MajorRepository.GetAll();
            return View(model.ToList());
        }

        [HttpGet]
        public ActionResult AddMajor()
        {
            return View(new Major());
        }

        [HttpPost]
        public ActionResult AddMajor(Major major)
        {
            MajorRepository.Add(major.MajorName);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult EditMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult EditMajor(Major major)
        {
            MajorRepository.Edit(major);
            return RedirectToAction("Majors");
        }

        [HttpGet]
        public ActionResult DeleteMajor(int id)
        {
            var major = MajorRepository.Get(id);
            return View(major);
        }

        [HttpPost]
        public ActionResult DeleteMajor(Major major)
        {
            MajorRepository.Delete(major.MajorId);
            return RedirectToAction("Majors");
        }
        //Method to return a view of all states.  
        [HttpGet]
        public ActionResult States()
        {
            var model = StateRepository.GetAll();
            return View(model.ToList());
        }
        //Method to get the view of the add state screen
        [HttpGet]
        public ActionResult AddState()
        {
            return View(new State());
        }
        //method to actually add the state object to the in memory state repo
        [HttpPost]
        public ActionResult AddState(State state)
        {
            StateRepository.Add(state);
            return RedirectToAction("States");
        }
        //method to get  the view for editing the specific state chosen by user. 
        //stateAbb variable used in the 'States.cshtml' file get the state object that will be edited
        [HttpGet]
        public ActionResult EditState(string stateAbb)
        {
            var state = StateRepository.Get(stateAbb);
            return View(state);
        }
        //method to actually edit the state object in the state repo
        [HttpPost]
        public ActionResult EditState(State state)
        {
            StateRepository.Edit(state);
            return RedirectToAction("States");
        }
        //method to get to the view for deleting the specific state chosen by user.
        [HttpGet]
        public ActionResult DeleteState(string stateAbb)
        {
            var state = StateRepository.Get(stateAbb);
            return View(state);
        }
        //method to actually delete the state obect from the state repo
        [HttpPost]
        public ActionResult DeleteState(State state)
        {
            StateRepository.Delete(state.StateAbbreviation);
            return RedirectToAction("States");
        }
        //Method to return a view of all the courses
        [HttpGet]
        public ActionResult Courses()
        {
            var model = CourseRepository.GetAll();
            return View(model.ToList());
        }
        //Method to return a view of the add course screen
        [HttpGet]
        public ActionResult AddCourse()
        {
            return View(new Course());
        }
        //Method to actually add a new Course object to the in memory course repo
        [HttpPost]
        public ActionResult AddCourse(Course course)
        {
            CourseRepository.Add(course.CourseName);
            return RedirectToAction("Courses");
        }
        //Method to return a view of of the edit course screen
        [HttpGet]
        public ActionResult EditCourse(int courseId)
        {
            var course = CourseRepository.Get(courseId);
            return View(course);
        }
        //Method to actually edit the Course object in the in memory course repo 
        [HttpPost]
        public ActionResult EditCourse(Course course)
        {
            CourseRepository.Edit(course);
            return RedirectToAction("Courses");
        }
        //Method to return a view of the delete course screen
        [HttpGet]
        public ActionResult DeleteCourse(int courseId)
        {
            var course = CourseRepository.Get(courseId);
            return View(course);
        }
        //method to actually delete the Course object from the in memory course repo
        [HttpPost]
        public ActionResult DeleteCourse(Course course)
        {
            CourseRepository.Delete(course.CourseId);
            return RedirectToAction("Courses");
        }
    }
}