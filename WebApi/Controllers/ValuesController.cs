using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        SqlConnection con = new SqlConnection("server=DESKTOP-3BJ5GK9;Database=SchoolDb;Integrated Security=false");

        [HttpGet("get")]
        public IActionResult Values()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Department",con);
            DataTable da = new DataTable();
            da.Clear();
            adapter.Fill(da);

            return Ok(da);
        }
    }
}
