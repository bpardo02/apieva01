using apitest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace apitest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> getAll()
        {
            var contactos = await _context.TblContactos.ToListAsync();
            return Ok(contactos);
        }

        [HttpPost]
        [Route("addContacto")]
        public async Task<IActionResult> addContacto(ContactosDTO contactoDTO)
        {
            var contacto = new Contacto()
            {
                Id = contactoDTO.Id,
                Nombres = contactoDTO.Nombres,
                Rut = contactoDTO.Rut,
                Apellidos = contactoDTO.Apellidos,
                FechaNacimiento = contactoDTO.FechaNacimiento,
                Direccion = contactoDTO.Direccion,
                Comuna = contactoDTO.Comuna,
                Correo = contactoDTO.Correo,
                Telefono = contactoDTO.Telefono,
                RutTrabajador = contactoDTO.RutTrabajador
            };
            _context.Add(contacto);
            await _context.SaveChangesAsync();
            return Ok(contacto);
        }

        [HttpPut]
        [Route("uptContacto")]
        public async Task<IActionResult> uptContacto(int id, ContactosDTO contactDTO)
        {
            var existecontacto = await _context.TblContactos.Where(x=>x.Id == id).FirstOrDefaultAsync();

            if (existecontacto == null)
            {
                return NotFound();
            }
            existecontacto.Rut = contactDTO.Rut;
            existecontacto.Nombres = contactDTO.Nombres;
            existecontacto.FechaNacimiento = contactDTO.FechaNacimiento;
            existecontacto.Direccion = contactDTO.Direccion;
            existecontacto.Comuna= contactDTO.Comuna;
            existecontacto.Telefono = contactDTO.Telefono;
            existecontacto.Apellidos = contactDTO.Apellidos;

            await _context.SaveChangesAsync();  
            return Ok();


        }

        [HttpDelete]
        [Route("deletecontacto")]

        public async Task<IActionResult> delContacto(int id)
        {
            var existe = await _context.TblContactos.Where(x=> x.Id == id).ToListAsync();
            if (existe == null)
            {
                return NotFound();
            }
            _context.Remove(existe);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpGet]
        [Route("contactobyRut")]

        public async Task<IActionResult> contactoByRut(string RutT)
        {
            var contactosrut = await _context.TblContactos.Where(x=>x.RutTrabajador == RutT).FirstOrDefaultAsync();
            if (contactosrut == null)
            {
                return NotFound();
            }
            return Ok(contactosrut);

        }




    }
}
