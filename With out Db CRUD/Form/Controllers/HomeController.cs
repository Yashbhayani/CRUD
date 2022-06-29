using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Form.Models;

namespace Form.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            Jumbo ert = new Jumbo();
            return View(ert);
        }
        [HttpPost]
        public ActionResult About(Jumbo ert)
        {

            int i, N, O;

            N = 1000;
            int[] myArray = new int[N];

            O = (int)ert.DEC;

            for (i = 0; O > 0; i++)
            {
                myArray[i] = O % 2;
                O = O / 2;
            }

            string str = "";

            for (i = i - 1; i >= 0; i--)
            {
                str += Convert.ToString(myArray[i]);
            }

            ert.Answer1 = str;

            return View(ert);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [HttpPost]  
        public ActionResult Contact(StudentDetail ram)
        {
            if (ram.StudentsList == null)
            {
                ram.StudentsList = new List<Student>();
            }
            ram.StudentsList.Add(ram.Studentmodel);

            List<Student> _tmpList = new List<Student>();

            if (TempData["stdList"] != null)
            {
                _tmpList = TempData["stdList"] as List<Student>;
            }
            _tmpList.Add(ram.Studentmodel);

            TempData["stdList"] = _tmpList;          

            TempData.Keep();
            return View(ram);
        }

        public ActionResult EditDetails(long id)
        {
            if(id > 0)
            {
                var _tmpList = TempData["stdList"] as List<Student>;
                TempData.Keep();
                if (_tmpList!=null && _tmpList.Count() > 0)
                {
                    var studentInfo = _tmpList.Where(x => x.ID == id).FirstOrDefault();
                    if (studentInfo != null)
                    {
                        return View(studentInfo);
                    }
                }
            }
            return View();
        }

        public ActionResult UpdateDetail(Student student)
        {
            if(student!=null && student.ID > 0)
            {
                var _tmpList = TempData["stdList"] as List<Student>;
                if(_tmpList!=null && _tmpList.Count() > 0 && _tmpList.Where(x =>x.ID == student.ID).Count() > 0)
                {
                    _tmpList.Where(x => x.ID == student.ID).ToList().ForEach(x => { x.FirstName = student.FirstName; x.SecondName = student.SecondName; });
                    StudentDetail studentDetail = new StudentDetail()
                    {
                        Studentmodel = new Student(),
                        StudentsList = _tmpList 
                    };
                    TempData["stdList"] = _tmpList;
                    return View("Contact", studentDetail);
                }
                
            }
            return RedirectToAction("Contact", "Home");
        }

        public ActionResult Delete(long id)
        {
            if (id > 0)
            {
                var _tmpList = TempData["stdList"] as List<Student>;
                TempData.Keep();
                if (_tmpList != null && _tmpList.Count() > 0)
                {
                    var studentInfo = _tmpList.Where(x => x.ID == id).FirstOrDefault();
                    if (studentInfo != null)
                    {
                        _tmpList.Remove(studentInfo);
                        TempData["stdList"] = _tmpList;
                        StudentDetail studentDetail = new StudentDetail()
                        {
                            Studentmodel = new Student(),
                            StudentsList = _tmpList 
                        };
                        return View("Contact", studentDetail); 
                    }
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
    }
}