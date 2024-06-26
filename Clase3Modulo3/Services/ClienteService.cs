using Clase3Modulo3.Domain.Entities;
using Clase3Modulo3.Repository;
using Clase3Modulo3.Services.Interfaces;

namespace Clase3Modulo3.Services
{
    public class ClienteService : IClienteService
    {

        private Clase3Modulo3Context _context;

        private Prueba _prueba;
        public ClienteService(Clase3Modulo3Context context,Prueba prueba)
        {
            _context= context;
            _prueba= prueba;
        }

        public List<Cliente> GetClientes() 
        {

            var id = _prueba.Identificador;
            return _context.Cliente.ToList();
        }
    }
}
