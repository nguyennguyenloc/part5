using part5.data.Entities;
using part5.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace part5.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
    {
        private PostService postService = new PostService();

        public ActionResult Index()
        {
            var data = postService.GetList();
            return View(data);
        }

        public ActionResult CreateHandle()
        {
            return View();
        }

        public ActionResult CreateAction(Post model)
        {
            model.CreatedBy = Convert.ToInt64(Session["UserId"]);
            if (ModelState.IsValid)
            {
                try
                {
                    var action = postService.Create(model);
                    if (action)
                    {
                        return Redirect("/admin/post/index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại");
                    }
                }
                catch
                {
                    ModelState.AddModelError("", "Thêm thất bại");
                }
            }
            else
            {
                ModelState.AddModelError("", "Thêm thất bại");
            }
            return View("CreateHandle");
        }
    }
}