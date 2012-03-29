using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Todo.Controllers
{
    public class ValidationController : Controller
    {
        public JsonResult ValidateExtension(string file, string title, string entry)
        {
            bool result = false;
            if(file !=  null)
            {
                string ext = file.Split('.').Last();
                if (ext == "png")
                {
                    result = true;
                }
            }
            return Json(result);
        }
    }
}
