using Microsoft.AspNetCore.Mvc;
using SectraDataApp.Data;
using Newtonsoft.Json;
using SectraDataApp.Models;

namespace SectraDataApp.Controllers
{
    public class JsonDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _environment;
        public JsonDataController(ApplicationDbContext db, IWebHostEnvironment environment)
        {
            _db = db;
            _environment = environment;
        }
        
        

        [HttpPost]
        public async Task<IActionResult> UploadJson(IFormFile filejson)
        {
            string uploads  = Path.Combine(_environment.WebRootPath, "uploads");
            if (!filejson.FileName.EndsWith(".json"))
            {
                ViewBag.errmsg = "Only Json Type Files Allowed";
            }
            else
            {
                string filePath = Path.Combine(uploads, filejson.FileName);
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                    await filejson.CopyToAsync(fileStream);
                StreamReader reader = new StreamReader(uploads + Path.GetFileName(filejson.FileName));
                string jsondata = reader.ReadToEnd();
                List<SiteInfo> siteList = JsonConvert.DeserializeObject<List<SiteInfo>>(jsondata);
                foreach(var item in siteList)
                {
                    item.versionpatch.ToString();
                    item.hostgroup.ToString();
                    item.nameofsoftware.ToString();
                    item.root.ToString();
                    item.cmpid.ToString();  
                    _db.SiteInfos.Add(item);
                    _db.SaveChanges();                
                }
                ViewBag.message="Selected " + Path.GetFileName(filejson.FileName) + " File is Saved Successfully! ";
                //var objSiteInfos = _db.SiteInfos.ToList();
            }
            return View("Index");
        }

    }
}
