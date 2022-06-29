using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using USER_CRUD.Yash;
using Login = USER_CRUD.Yash.Login;

namespace USER_CRUD.Controllers
{
    public class UserController : Controller
    {
        User_masterEntities dbObj = new User_masterEntities();

        public new ActionResult User()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(User_Master_Table_1 model) //User_Master_Table_1 model :-  This is Viewer send the data and bring data to the this Action Methode 
        {
                
            if (ModelState.IsValid)
            {
                User_Master_Table_1 obj = new User_Master_Table_1();
                
                obj.User_MasterFName = model.User_MasterFName;
                obj.User_MasterSName = model.User_MasterSName;
                obj.User_MasterEmail = model.User_MasterEmail;
                obj.User_Master_MO_BO = model.User_Master_MO_BO;

                    if (model.User_MasterID == 0)
                    {
                            if (dbObj.User_Master_Table_1.Where(x => x.User_MasterEmail == model.User_MasterEmail).Count() > 0)
                            {
                                ViewBag.TotalStudents = "User Email id is a Already Exist";

                                return View("User");
                            }
                            else if (dbObj.User_Master_Table_1.Where(y => y.User_Master_MO_BO == model.User_Master_MO_BO).Count() > 0)
                            {
                                ViewBag.TotalStudents = "User Mobile Number is a Already Exist";
                                return View("User");
                            }
                            else
                            {
                                dbObj.User_Master_Table_1.Add(obj);
                                dbObj.SaveChanges();
                            }
                    }
                    else
                    {
                            if (dbObj.User_Master_Table_1.Where(x => x.User_MasterEmail == model.User_MasterEmail).Count() > 0){
                                ViewBag.TotalStudents = "User Email id is a Already Exist";
                                return View("User");
                            }else if (dbObj.User_Master_Table_1.Where(y => y.User_Master_MO_BO == model.User_Master_MO_BO).Count() > 0){
                                ViewBag.TotalStudents = "User Mobile Number is a Already Exist";
                                return View("User");
                            }else{
                                dbObj.Entry(model).State = EntityState.Modified;
                                dbObj.SaveChanges();
                            }
                    }

            }
            ModelState.Clear();

            return RedirectToAction("UserList");
        }

        public ActionResult UserList(string SortOrder, string SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            
            var res = dbObj.User_Master_Table_1.ToList();
            
            
            switch(SortBy)
            {
                case "Name":
                    {
                        switch(SortOrder)
                        {
                            case "Asc":
                                {
                                    res = res.OrderBy(x =>x.User_MasterFName).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    res = res.OrderByDescending(x => x.User_MasterFName).ToList();
                                    break;
                                }
                            default:
                                {
                                    res = res.OrderBy(x => x.User_MasterFName).ToList();
                                    break;
                                }
                        }
                        break;
                    }

                case "SurName":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    res = res.OrderBy(x => x.User_MasterSName).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    res = res.OrderByDescending(x => x.User_MasterSName).ToList();
                                    break;
                                }
                            default:
                                {
                                    res = res.OrderBy(x => x.User_MasterSName).ToList();
                                    break;
                                }
                        }
                        break ;
                    }
                case "Email":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    res = res.OrderBy(x => x.User_MasterEmail).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    res = res.OrderByDescending(x => x.User_MasterEmail).ToList();
                                    break;
                                }
                            default:
                                {
                                    res = res.OrderBy(x => x.User_MasterEmail).ToList();
                                    break;

                                }
                        }
                        break;
                    }
                case "Mobile Number":
                    {
                        switch (SortOrder)
                        {
                            case "Asc":
                                {
                                    res = res.OrderBy(x => x.User_Master_MO_BO).ToList();
                                    break;
                                }
                            case "Desc":
                                {
                                    res = res.OrderByDescending(x => x.User_Master_MO_BO).ToList();
                                    break;
                                }
                            default:
                                {
                                    res = res.OrderBy(x => x.User_Master_MO_BO).ToList();
                                    break;

                                }
                        }
                        break;
                    }
                default:
                    {
                        res = res.OrderBy(x => x.User_MasterFName).ToList();
                        break;
                    }
            }    



            return View(res);
        }

        [HttpPost]
        public ActionResult UserList(string searchtext)
        {
            var res = dbObj.User_Master_Table_1.ToList();

            if (searchtext != null)
            {
                res = dbObj.User_Master_Table_1.Where(x => x.User_MasterFName.Contains(searchtext) || x.User_MasterSName.Contains(searchtext) || x.User_MasterEmail.Contains(searchtext) || x.User_Master_MO_BO.Contains(searchtext)).ToList();
            }

            return View(res);
        }

       
        public ActionResult Edit(int id)
        {
            var ui = dbObj.User_Master_Table_1.Where(x => x.User_MasterID == id).First();
            return View(ui);
        }

        public ActionResult Delete(int id)
        {
            var res = dbObj.User_Master_Table_1.Where(x => x.User_MasterID == id).First();

            dbObj.User_Master_Table_1.Remove(res);

            dbObj.SaveChanges();

            var list = dbObj.User_Master_Table_1.ToList();

            return View("UserList", list);
        }
        

        public ActionResult loginuser()
        {
            return View();
        }

      

        [HttpPost]
        public ActionResult loginuser(Login Hui)
        {
            if(ModelState.IsValid)
            {
                if(dbObj.User_Master_Table_1.Where(m => m.User_MasterEmail == Hui.email1 && m.User_Master_MO_BO == Hui.mobo ).FirstOrDefault() == null)
                {
                    ViewBag.YUIO = "Email And Password Dose not match";
                    return View();
                }
                else
                {
                    return RedirectToAction("UserList");
                }

            }
            return View();
        }
    }
}