using Clinic_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Clinic_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            DashboardVM vm = new DashboardVM();

            string cn = _config.GetConnectionString("con_db");

            using (SqlConnection con = new SqlConnection(cn))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@"
                SELECT 
                (SELECT COUNT(*) FROM Pacientes),
                (SELECT COUNT(*) FROM Medicos),
                (SELECT COUNT(*) FROM Citas),
                (SELECT COUNT(*) FROM Medicamentos)
                ", con);

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    vm.TotalPacientes = dr.GetInt32(0);
                    vm.TotalMedicos = dr.GetInt32(1);
                    vm.CitasHoy = dr.GetInt32(2);
                    vm.TotalMedicamentos = dr.GetInt32(3);
                }
            }

            return View(vm);
        }
    }
}