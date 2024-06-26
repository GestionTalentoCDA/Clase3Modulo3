using Clase3Modulo3.Repository;
using Clase3Modulo3.Services;
using Clase3Modulo3.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clase3Modulo3.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //private Clase3Modulo3Context _context;
        private IClienteService _clienteService;
        private Prueba _prueba;
        public ClienteController(/*Clase3Modulo3Context context*/ IClienteService clienteService, Prueba prueba)
        {
            //_context = context;

            _clienteService = clienteService;
            _prueba = prueba;
        }

        [HttpGet]
        public IActionResult GetClientes() 
        {

            //var serviceCliente = new ClienteService(_context);

            //var result = serviceCliente.GetClientes();

           

            var result = _clienteService.GetClientes();

            return Ok(result);
        }


        [HttpGet("Inyecciones")]
        public IActionResult GetPrueba() 
        {

            var id = _prueba.Identificador;

            var result = _clienteService.GetClientes();
            return Ok(new { Id = id});
        }
    }
}
