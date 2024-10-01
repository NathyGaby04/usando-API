using asp_servicios.Nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace asp_servicios.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {

        [HttpGet(Name = "GetClientes")]
        public IEnumerable<Clientes> Get()
        {
            var conexion = new Conexion();           
            conexion.StringConnection = "server=localhost;database=db_cafeteria;Integrated Security=True;TrustServerCertificate=true;";
            conexion.Database.Migrate();

            conexion.Guardar(new Clientes()
            {
                Cedula = "1127574583",
                Nombre = "Sebastian",
                Apellido = "Fuentes",
                Fecha = DateTime.Now,
                Puntos = 4.6m,
                Activo = true,
            });
            conexion.SaveChanges();    
            return conexion.Listar<Clientes>();
        }
    }
}
