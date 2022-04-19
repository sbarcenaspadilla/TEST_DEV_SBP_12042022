using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using TEST_DEV_SBP_12042022.Datos;
using System.Web.Http;
using TEST_DEV_SBP_12042022.Models;

namespace TEST_DEV_SBP_12042022.Controllers
{
    public class PersonasFisicasController : ApiController
    {
        // GET: api/PersonasFisicas
        //Listar todos los registros de la tabla
        public List<PersonasFisicas> Get()
        {
            return CRUDPersonasFisicas.MostrarTodos();
        }

        // GET: api/PersonasFisicas/5
        //Consultar un registro
        public PersonasFisicas Get(int id)
        {
            return CRUDPersonasFisicas.ConsultarUno(id);
        }

        // POST: api/PersonasFisicas
        //Registar usuarios
        public bool Post([FromBody]PersonasFisicas oPersonasFisicas)
        {
            return CRUDPersonasFisicas.Agregar(oPersonasFisicas);
        }

        // PUT: api/PersonasFisicas/5
        //Actualizar registros
        public bool Put([FromBody] PersonasFisicas oPersonasFisicas)
        {
            return CRUDPersonasFisicas.Modificar(oPersonasFisicas);
        }

        // DELETE: api/PersonasFisicas/5
        //Eliminar Registro
        public bool Delete(int id)
        {
            return CRUDPersonasFisicas.Eliminar(id);
        }
    }
}
