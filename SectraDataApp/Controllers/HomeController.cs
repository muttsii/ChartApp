using Microsoft.AspNetCore.Mvc;
using SectraDataApp.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace SectraDataApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        //public ActionResult DashBoardcount(PatchModel patchModel)
        //{
        //    var model = new PatchModel();
        //    return View(model);
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public ActionResult DashBoardcount(PatchModel patchModel)
        {
            //PatchModel(model.PatchValue);
            try
                {
                    
                    string[] dashBoardcount = new string[19];
                    string Patch = "23.2.6.5161";
                    string connectionString;
                    SqlConnection cnn;
                    connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=MinimalApiSectraDb;Integrated Security=True;MultipleActiveResultSets=True";
                    cnn = new(connectionString);
                    cnn.Open();
                    SqlCommand cmd = new("SELECT count (root) as UK,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'UK' AND programpatch = '" + patchModel + "') as DACH,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'NA' AND programpatch = '" + patchModel + "') as NA,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Southeast_Imaging' AND programpatch = '" + patchModel + "') as Southeast_Imaging,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Commit' AND programpatch = '" + patchModel + "') as Commït,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Benelux' AND programpatch = '" + patchModel + "') as Benelux,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Scandinavia' AND programpatch = '" + patchModel + "') as Scandinavia,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Iberia' AND programpatch = '" + patchModel + "') as Iberia,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'PhilipsDACH' AND programpatch = '" + patchModel + "') as PhilipsDACH,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Medi-Far' AND programpatch = '" + patchModel + "') as MediFar,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'ANZ' AND programpatch = '" + patchModel + "') as ANZ,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'MedIT' AND programpatch = '" + patchModel + "') as Medit,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'France' AND programpatch = '" + patchModel + "') as France,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'SouthAfrica' AND programpatch = '" + patchModel + "') as SouthAfrica,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Preop Online' AND programpatch = '" + patchModel + "') as PreopOnline,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'AttirhMedico' AND programpatch = '" + patchModel + "') as AttiehMedico,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Answer_Medical' AND programpatch = '" + patchModel + "') as Answer_Medical,(SELECT count (root) FROM JsonDataSectraUseThis WHERE root = 'Education' AND programpatch = '" + patchModel + "') as Education FROM JsonDataSectraUseThis WHERE root = 'DACH' AND programpatch = '" + patchModel + "'", cnn);
                    DataTable dt = new();
                    SqlDataAdapter cmd1 = new(cmd);
                    cmd1.SelectCommand = cmd;
                    cmd1.Fill(dt);
                    if (dt.Rows.Count == 0)
                    {
                        dashBoardcount[0] = "0";
                        dashBoardcount[1] = "0";
                        dashBoardcount[2] = "0";
                        dashBoardcount[3] = "0";
                        dashBoardcount[4] = "0";
                        dashBoardcount[5] = "0";
                        dashBoardcount[6] = "0";
                        dashBoardcount[7] = "0";
                        dashBoardcount[8] = "0";
                        dashBoardcount[9] = "0";
                        dashBoardcount[10] = "0";
                        dashBoardcount[12] = "0";
                        dashBoardcount[13] = "0";
                        dashBoardcount[14] = "0";
                        dashBoardcount[15] = "0";
                        dashBoardcount[16] = "0";
                        dashBoardcount[17] = "0";
                        dashBoardcount[18] = "0";
                    }
                    else
                    {
                        dashBoardcount[0] = dt.Rows[0]["UK"].ToString();
                        dashBoardcount[1] = dt.Rows[0]["DACH"].ToString();
                        dashBoardcount[2] = dt.Rows[0]["NA"].ToString();
                        dashBoardcount[3] = dt.Rows[0]["Southeast_Imaging"].ToString();
                        dashBoardcount[4] = dt.Rows[0]["Commït"].ToString();
                        dashBoardcount[5] = dt.Rows[0]["Benelux"].ToString();
                        dashBoardcount[6] = dt.Rows[0]["Scandinavia"].ToString();
                        dashBoardcount[7] = dt.Rows[0]["Iberia"].ToString();
                        dashBoardcount[8] = dt.Rows[0]["PhilipsDACH"].ToString();
                        dashBoardcount[9] = dt.Rows[0]["MediFar"].ToString();
                        dashBoardcount[10] = dt.Rows[0]["ANZ"].ToString();
                        dashBoardcount[12] = dt.Rows[0]["Medit"].ToString();
                        dashBoardcount[13] = dt.Rows[0]["France"].ToString();
                        dashBoardcount[14] = dt.Rows[0]["SouthAfrica"].ToString();
                        dashBoardcount[15] = dt.Rows[0]["PreopOnline"].ToString();
                        dashBoardcount[16] = dt.Rows[0]["AttiehMedico"].ToString();
                        dashBoardcount[17] = dt.Rows[0]["Answer_Medical"].ToString();
                        dashBoardcount[18] = dt.Rows[0]["Education"].ToString();
                    }
                    cnn.Close();
                    return Json(new { dashBoardcount });

                }
                catch (Exception ex)
                {

                    throw ex;
                }
        }
    }
}