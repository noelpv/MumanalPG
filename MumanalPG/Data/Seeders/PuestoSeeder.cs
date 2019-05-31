using System;
using MumanalPG.Models.RRHH;
using System.Linq;
using MumanalPG.Utility;

namespace MumanalPG.Data.Seeders
{
    public class PuestoSeeder
    {
        private readonly ApplicationDbContext _context;
        public PuestoSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            //IdDepartamento = 2 => para LA PAZ, IUsuario = 1 => Admin, 
            AddNew(new Puesto { Descripcion = "Gerente General", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "GG");
            
            AddNew(new Puesto { Descripcion = "Jefe de Auditoria Interna", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AI");
            
            AddNew(new Puesto { Descripcion = "Secretaria General", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "GG");
            
            AddNew(new Puesto { Descripcion = "Secretaria de Gerencia", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "GG");
 
            AddNew(new Puesto { Descripcion = "Jefe de Asesoria Tecnica", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AT");
            
            AddNew(new Puesto { Descripcion = "Secretario de Infraestructura", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AT");
            
            AddNew(new Puesto { Descripcion = "Jefe de Unidad Juridica", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UJ");
            
            AddNew(new Puesto { Descripcion = "Secretaria Juridica", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UJ");
            
            AddNew(new Puesto { Descripcion = "Abogado", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UJ");
            
            AddNew(new Puesto { Descripcion = "Jefe Administrativo Financiero", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UAF");
            
            AddNew(new Puesto { Descripcion = "Jefe de Recursos Humanos", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "RRHH");
            
            AddNew(new Puesto { Descripcion = "Jefe de Regímenes Especiales", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "URE");
            
            AddNew(new Puesto { Descripcion = "Jefe Unidad de Prestaciones", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UP");
            
            AddNew(new Puesto { Descripcion = "Secretaria de Prestaciones", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UP");
            
            AddNew(new Puesto { Descripcion = "Encargado de Prestaciones", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "PRE");
            
            AddNew(new Puesto { Descripcion = "Encargado de Cotizaciones", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "COT");
            
            AddNew(new Puesto { Descripcion = "Encargado de Servicios Sociales", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SS");
            
            AddNew(new Puesto { Descripcion = "Auxiliar de Prestaciones", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UP");
            
            AddNew(new Puesto { Descripcion = "Auxiliar de Regímenes Especiales", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "URE");
            
            AddNew(new Puesto { Descripcion = "Secreatria Administrativa Financiera", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UAF");
            
            AddNew(new Puesto { Descripcion = "Encargado de Contabilidad", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CON");
            
            AddNew(new Puesto { Descripcion = "Encargado de Sistemas", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SIS");
            
            AddNew(new Puesto { Descripcion = "Encargado de Tesorería", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TES");
            
            AddNew(new Puesto { Descripcion = "Encargado de Activos Fijos", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AF");
            
            AddNew(new Puesto { Descripcion = "Auxiliar de Contabilidad", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CON");
            
            AddNew(new Puesto { Descripcion = "Auxiliar de Tesorería I", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TES");
           
            AddNew(new Puesto { Descripcion = "Auxiliar de Tesorería II", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TES");
            
            AddNew(new Puesto { Descripcion = "Kardixta", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UAF");
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNew(Puesto item, string siglaUnidadEjecutora)
        {
            var existing = _context.RRHH_Puesto.FirstOrDefault(p => p.Descripcion == item.Descripcion);

            if(existing == null)
            {
                var unidad = _context.RRHH_UnidadEjecutora.FirstOrDefault(p => p.Sigla == siglaUnidadEjecutora);
                if (unidad != null)
                {
                    item.IdUnidadEjecutora = unidad.IdUnidadEjecutora;
                }

                _context.RRHH_Puesto.Add(item);
                _context.SaveChanges();
            }
        }
    }
}