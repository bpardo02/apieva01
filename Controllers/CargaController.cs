using apitest.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CargaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> add(CargaDTO Cdto)
        {
            var carga = new Carga()
            {
                Rut = Cdto.Rut,
                Nombres = Cdto.Nombres,
                Apellidos = Cdto.Apellidos,
                FechaNacimiento = Cdto.FechaNacimiento,
                RutTrabajador = Cdto.RutTrabajador,
            };
            _context.Add(carga);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> getAll()
        {
            return Ok(await _context.TblCargas.ToListAsync());
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> uptall(string id, CargaDTO cargaDTO)
        {
            var exists = await _context.TblCargas.Where(x=>x.Rut == id).FirstOrDefaultAsync();

            if (exists == null){
                return NotFound();
            }
            exists.Nombres = cargaDTO.Nombres;
            exists.RutTrabajador = cargaDTO.RutTrabajador;
            exists.Apellidos = cargaDTO.Apellidos;
            exists.FechaNacimiento = cargaDTO.FechaNacimiento;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> delCarga(string id)
        {
            var existeCarga = await _context.TblCargas.Where(x=>x.Rut==id).FirstOrDefaultAsync();
            if (existeCarga == null)
            {
                return NotFound();
            }
            _context.Remove(existeCarga);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet]
        [Route("getbyRut")]
        public async Task<IActionResult> getByRut(string id)
        {
            var existsRut = await _context.TblCargas.Where(x=>x.Rut.Equals(id)).ToListAsync();
            if (existsRut == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(existsRut);
            }
        }

       

    }
}