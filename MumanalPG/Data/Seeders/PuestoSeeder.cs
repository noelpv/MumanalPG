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
            AddNew(new Puesto { Descripcion = "Presidente", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIR");
            
            AddNew(new Puesto { Descripcion = "Director I", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIR");
            
            AddNew(new Puesto { Descripcion = "Director II", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIR");
            
            AddNew(new Puesto { Descripcion = "Director III", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIR");
            
            AddNew(new Puesto { Descripcion = "Director IV", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIR");
            
            AddNew(new Puesto { Descripcion = "Director V", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIR");
            
            AddNew(new Puesto { Descripcion = "Presidente", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIR");
            
            AddNew(new Puesto { Descripcion = "Gerente General", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "GG");
            
            AddNew(new Puesto { Descripcion = "Encargado Regionales", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "REG");
            
            AddNew(new Puesto { Descripcion = "Mensajero Of. Central", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SG");
            
            AddNew(new Puesto { Descripcion = "Portero Of. Central", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SG");
            
            AddNew(new Puesto { Descripcion = "Ujier - Servicio", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SG");
            
            AddNew(new Puesto { Descripcion = "Jefe de Auditoria Interna", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AI");
            
            AddNew(new Puesto { Descripcion = "Auditor Junior", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AI");
            
            AddNew(new Puesto { Descripcion = "Secretaria General", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SG");
            
            AddNew(new Puesto { Descripcion = "Secretaria de Gerencia", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "GG");
 
            AddNew(new Puesto { Descripcion = "Jefe de Asesoria Tecnica", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AT");
            
            AddNew(new Puesto { Descripcion = "Secretario de Infraestructura", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AT");
            
            AddNew(new Puesto { Descripcion = "Asesor Legal", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UJ");
            
            AddNew(new Puesto { Descripcion = "Secretaria Juridica", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UJ");
            
            AddNew(new Puesto { Descripcion = "Abogado", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UJ");
            
            AddNew(new Puesto { Descripcion = "Abogado Procurador", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
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
            
            AddNew(new Puesto { Descripcion = "Encargado de Inversiones", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "INV");
            
            AddNew(new Puesto { Descripcion = "Encargado de Sistemas", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SIS");
            
            AddNew(new Puesto { Descripcion = "Encargado de Tesorería", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TES");
            
            AddNew(new Puesto { Descripcion = "Encargado de Activos Fijos", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "AF");
            
            AddNew(new Puesto { Descripcion = "Aux. Of. Contabilidad", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CON");
            
            AddNew(new Puesto { Descripcion = "Auxiliar de Contabilidad", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CON");
            
            AddNew(new Puesto { Descripcion = "Secretaria de Contabilidad", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CON");
            
            AddNew(new Puesto { Descripcion = "Auxiliar de Tesorería", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TES");
           
            AddNew(new Puesto { Descripcion = "Auxiliar Financiero", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UAF");
            
            AddNew(new Puesto { Descripcion = "Kardixta", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "UAF");
            
            AddNew(new Puesto { Descripcion = "Auditora Comité de Vigilancia", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "COM-VIG");
            
            AddNew(new Puesto { Descripcion = "Comité de Vigilancia I", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "COM-VIG");
            
            AddNew(new Puesto { Descripcion = "Comité de Vigilancia II", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "COM-VIG");
            
            AddNew(new Puesto { Descripcion = "Comité de Vigilancia III", Item = 0, IdDepartamento = 2, EsDePlanilla = false, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "COM-VIG");
            
            AddNew(new Puesto { Descripcion = "Agente Regional Cochabamba", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CBBA");
            
            AddNew(new Puesto { Descripcion = "Auxiliar Contable Cochabamba", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CBBA");
            
            AddNew(new Puesto { Descripcion = "Secretearia Agencia Regional Cochabamba", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CBBA");
            
            AddNew(new Puesto { Descripcion = "Portero Mensajero Cochabamba", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "CBBA");
            
            AddNew(new Puesto { Descripcion = "Agente Regional La Paz", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "LP");
            
            AddNew(new Puesto { Descripcion = "Secretaria Agencia Regional La Paz", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "LP");
            
            AddNew(new Puesto { Descripcion = "Agente Regional Cobija", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "COB");
            
            AddNew(new Puesto { Descripcion = "Agente Regional Oruro", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "OR");
            
            AddNew(new Puesto { Descripcion = "Secretaria Agencia Regional Oruro", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "OR");
            
            AddNew(new Puesto { Descripcion = "Agente Regional Potosi", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "PT");
            
            AddNew(new Puesto { Descripcion = "Portero Potosi", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "PT");
            
            AddNew(new Puesto { Descripcion = "Secretaria Agencia Regional Potosi", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "PT");
            
            AddNew(new Puesto { Descripcion = "Agente Regional Santa Cruz", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SC");
            
            AddNew(new Puesto { Descripcion = "Portero Santa Cruz", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SC");
            
            AddNew(new Puesto { Descripcion = "Portero Santa Cruz II", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SC");
            
            AddNew(new Puesto { Descripcion = "Secretaria Agencia Regional Santa Cruz", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SC");
            
            AddNew(new Puesto { Descripcion = "Agente Regional Sucre", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SUC");
            
            AddNew(new Puesto { Descripcion = "Portero Sucre", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SUC");
            
            AddNew(new Puesto { Descripcion = "Secretaria Agencia Regional Sucre", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "SUC");
            
            AddNew(new Puesto { Descripcion = "Agente Regional Tarija", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TJ");
            
            AddNew(new Puesto { Descripcion = "Portero Tarija", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TJ");
            
            AddNew(new Puesto { Descripcion = "Secretaria Agencia Regional Tarija", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TJ");
            
            AddNew(new Puesto { Descripcion = "Agente Regional Trinidad", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TRI");
            
            AddNew(new Puesto { Descripcion = "Secretaria Agencia Regional Trinidad", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "TRI");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital El Alto", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.ALT");
            
            AddNew(new Puesto { Descripcion = "Secretaria Agencia Distrital El Alto", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.ALT");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Montero", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.MON");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Quillacollo", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.QUILL");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Riberalta", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.RIB");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Camiri", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.CAM");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Punata", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.PUN");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Magdalena", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.MAG");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Tupiza", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.TUP");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital San Matias", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.SANMAT");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital San Ignacio de Moxos", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.MOX");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Caranavi", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.CAR");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Uyuni", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.UYU");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Puerto Suarez", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.PSUA");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital S.J.Chiquitos", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.SJCH");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Cotagaita", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.COT");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Yacuiba", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.YAC");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Atocha", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.ATCH");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Aiquile", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.AIQU");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Rurrenabaque", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.RURRE");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital San Ignacio de Velasco", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.SIVEL");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Bermejo", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.BER");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Villazon", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.VILL");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Camargo", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.CAMG");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Robore", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.ROB");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Llallagua", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.LLA");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Santa Ana", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.SAYACU");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Monteagudo", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.MONTG");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Guayaramerin", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.GUAY");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Puerto Rico", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.PR");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Villamontes", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.VILLAM");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Vallegrande", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.VALLEG");
            
            AddNew(new Puesto { Descripcion = "Agente Distrital Apolo", Item = 0, IdDepartamento = 2, EsDePlanilla = true, 
                IdUsuario = 1, FechaRegistro = DateTime.Now, IdEstadoRegistro = Constantes.Registrado}, "DIS.APO");
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNew(Puesto item, string siglaUnidadEjecutora)
        {
            var existing = _context.RRHH_Puesto.FirstOrDefault(p => p.Descripcion == item.Descripcion);

            if(existing == null)
            {
                var unidad = _context.RRHH_UnidadEjecutora.FirstOrDefault(p => p.Sigla == siglaUnidadEjecutora && p.EsExterna == false);
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