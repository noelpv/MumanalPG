using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Models.RRHH;
using MumanalPG.Utility;

namespace MumanalPG.Data.Seeders
{
    public class FuncionariosPuestoSeeder
    {
        private readonly ApplicationDbContext _context;

        public FuncionariosPuestoSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
           CrearFuncionarios();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add

        private void CrearFuncionarios()
        {
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "SÁNCHEZ", SegundoApellido = "HEREDIA", PrimerNombre = "ADHEMAR",
                    SegundoNombre = ""
                }, "PRESIDENTE");
            
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "RAMOS", SegundoApellido = "CHAMBI", PrimerNombre = "ANTONIO",
                    SegundoNombre = ""
                }, "DIRECTOR I");
            
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "REVILLA", SegundoApellido = "CHUMACERO", PrimerNombre = "ALFREDO",
                    SegundoNombre = ""
                }, "DIRECTOR II");
            
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CLAROS", SegundoApellido = "URQHUART", PrimerNombre = "MARIA",
                    SegundoNombre = "PATRICIA"
                }, "DIRECTOR III");

            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "DASILVA", SegundoApellido = "RODRIGUEZ", PrimerNombre = "ANTONIA",
                    SegundoNombre = ""
                }, "DIRECTOR IV");
            
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "JAIMES", SegundoApellido = "MAMANI", PrimerNombre = "JUAN",
                    SegundoNombre = "JOSE"
                }, "DIRECTOR V");
            
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "SERRANO", SegundoApellido = "VILLAFUERTE", PrimerNombre = "PEDRO",
                    SegundoNombre = "HERNÁN"
                }, "GERENTE");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "OBLITAS", SegundoApellido = "ORTÍZ", PrimerNombre = "LUIS",
                    SegundoNombre = "JORGE"
                }, "ASESOR LEGAL");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "AGUIRRE", SegundoApellido = "PACHECO", PrimerNombre = "LILIAM",
                    SegundoNombre = "MARCELA L."
                }, "JEFE DE RECURSOS HUMANOS");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CRUZ", SegundoApellido = "NINA", PrimerNombre = "LILIAM", SegundoNombre = "NORAH"
                }, "Jefe Unidad de Prestaciones");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "TORRICO", SegundoApellido = "CUSICANQUI", PrimerNombre = "BLANCA",
                    SegundoNombre = "NIEVES"
                }, "Jefe de Auditoria Interna");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "VILLCA", SegundoApellido = "DELGADILLO", PrimerNombre = "RUBEN",
                    SegundoNombre = "ALEJANDRO"
                }, "Jefe Administrativo Financiero");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "RIVERO", SegundoApellido = "TERRAZAS", PrimerNombre = "VIVIANA",
                    SegundoNombre = "TERESA"
                }, "AUDITORA COMITÉ DE VIGILANCIA");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "GUZMAN", SegundoApellido = "LARA", PrimerNombre = "GLADYS",
                    SegundoNombre = "MIRIAM"
                }, "COMITÉ DE VIGILANCIA I");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "DÁVILA", SegundoApellido = "AMADOR", PrimerNombre = "ELEUTERIO",
                    SegundoNombre = ""
                }, "COMITÉ DE VIGILANCIA II");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ANTELO", SegundoApellido = "ESPINOZA", PrimerNombre = "ISRAEL",
                    SegundoNombre = ""
                }, "COMITÉ DE VIGILANCIA III");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "BOHÓRQUEZ", SegundoApellido = "MERCADO", PrimerNombre = "GINA",
                    SegundoNombre = "ROSARIO"
                }, "ABOGADO");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CONDORI", SegundoApellido = "FLORES", PrimerNombre = "SYLVIA",
                    SegundoNombre = "MONICA"
                }, "Encargado de Contabilidad");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "FLORES", SegundoApellido = "QUISBERT", PrimerNombre = "VICKY",
                    SegundoNombre = "FERNANDA"
                }, "ABOGADO PROCURADOR");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ALIAGA", SegundoApellido = "VALVERDE", PrimerNombre = "PABLO", SegundoNombre = ""
                }, "ENCARGADO DE SISTEMAS");
            AddNew(
                new Beneficiario
                    {PrimerApellido = "ALIPAZ", SegundoApellido = "HUARY", PrimerNombre = "XIMENA", SegundoNombre = ""},
                "Encargado de Tesorería");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "LIMACHI", SegundoApellido = "CUBA", PrimerNombre = "ELIZABETH", SegundoNombre = ""
                }, "Encargado de Prestaciones");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "MACHACA", SegundoApellido = "MARTINEZ", PrimerNombre = "ROXANA",
                    SegundoNombre = "GUADALUPE"
                }, "SECRETARIA GENERAL");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "RADA", SegundoApellido = "NUÑEZ DEL PRADO", PrimerNombre = "EDWIN",
                    SegundoNombre = "ALBERTO"
                }, "ENCARGADO REGIONALES");
            AddNew(
                new Beneficiario
                    {PrimerApellido = "APAZA", SegundoApellido = "HUIZA", PrimerNombre = "MARYSOL", SegundoNombre = ""},
                "Encargado de Cotizaciones");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "VELASCO", SegundoApellido = "QUISPE", PrimerNombre = "FLORA", SegundoNombre = ""
                }, "Encargado de Servicios Sociales");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ROJAS", SegundoApellido = "FERRUFINO", PrimerNombre = "JESMAR",
                    SegundoNombre = "ROCIO"
                }, "Agente Regional Cochabamba");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "VELARDE", SegundoApellido = "VARGAS", PrimerNombre = "AROON",
                    SegundoNombre = "GABRIEL"
                }, "Encargado de Activos Fijos");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "FORONDA", SegundoApellido = "FLORES", PrimerNombre = "LUZ",
                    SegundoNombre = "DAYANA"
                }, "Agente Regional La Paz");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "HERRERA", SegundoApellido = "CACERES", PrimerNombre = "ADRIAN", SegundoNombre = ""
                }, "AGENTE REGIONAL COBIJA");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "AZURDUY", SegundoApellido = "SORIA", PrimerNombre = "VELKA",
                    SegundoNombre = "LIZETH"
                }, "AGENTE REGIONAL ORURO");
            AddNew(
                new Beneficiario
                    {PrimerApellido = "SANCHEZ", SegundoApellido = "UÑO", PrimerNombre = "HECTOR", SegundoNombre = ""},
                "AGENTE REGIONAL POTOSI");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "BAYA", SegundoApellido = "DE VILLEGAS", PrimerNombre = "CARLA",
                    SegundoNombre = "JIMENA"
                }, "AGENTE REGIONAL SANTA CRUZ");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "TOLEDO", SegundoApellido = "CALVIMONTES", PrimerNombre = "WILLMA",
                    SegundoNombre = "ROXANA"
                }, "AGENTE REGIONAL SUCRE");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "USTAREZ", SegundoApellido = "VELASQUEZ", PrimerNombre = "RODRIGO",
                    SegundoNombre = ""
                }, "AGENTE REGIONAL TARIJA");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "AGUILAR", SegundoApellido = "ENCINAS", PrimerNombre = "JOSÉ",
                    SegundoNombre = "REYNALDO"
                }, "AGENTE REGIONAL TRINIDAD");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CAMACOPA", SegundoApellido = "MUÑOZ", PrimerNombre = "MARIA",
                    SegundoNombre = "ANGELA"
                }, "AGENTE DISTRITAL EL ALTO");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "MAFAILE", SegundoApellido = "PEREZ", PrimerNombre = "LILIANA", SegundoNombre = ""
                }, "AGENTE DISTRITAL MONTERO");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CHOQUE", SegundoApellido = "PAIZA", PrimerNombre = "LAURA",
                    SegundoNombre = "PRIMA"
                }, "AGENTE DISTRITAL QUILLACOLLO");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "RODRIGUEZ", SegundoApellido = "BAENY", PrimerNombre = "SANDRA",
                    SegundoNombre = "MARCELA"
                }, "AGENTE DISTRITAL RIBERALTA");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ZABALA", SegundoApellido = "QUISBERT", PrimerNombre = "YAMINA", SegundoNombre = ""
                }, "AUXILIAR FINANCIERO");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CLAURE", SegundoApellido = "MENDIZÁBAL", PrimerNombre = "MARCO",
                    SegundoNombre = "ANTONIO"
                }, "KARDIXTA");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CANTUTA", SegundoApellido = "JIGUACUTI", PrimerNombre = "JANETH",
                    SegundoNombre = "CLAUDIA"
                }, "Auxiliar de Tesorería");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CUELLAR", SegundoApellido = "FERNANDEZ", PrimerNombre = "YILKA",
                    SegundoNombre = ""
                }, "Aux. Of. Contabilidad");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "QUISPE", SegundoApellido = "HUANCA", PrimerNombre = "BLANCA", SegundoNombre = ""
                }, "Secretaria de Contabilidad");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "RAMOS", SegundoApellido = "UCEDA", PrimerNombre = "ANA",
                    SegundoNombre = "ESTEFANI"
                }, "Auxiliar de Contabilidad");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "RIVAS", SegundoApellido = "TITO", PrimerNombre = "MARIELA",
                    SegundoNombre = "YOVANA"
                }, "Secretaria de Gerencia");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CUELA", SegundoApellido = "MAMANI", PrimerNombre = "PAMELA",
                    SegundoNombre = "MONICA"
                }, "Secretaria Juridica");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "FLORES", SegundoApellido = "CALLISAYA", PrimerNombre = "MIRIAM",
                    SegundoNombre = "RUTH"
                }, "Auxiliar de Prestaciones");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "SONCO", SegundoApellido = "BOTELLO", PrimerNombre = "DAVID",
                    SegundoNombre = "JOSUE"
                }, "Secretario de Infraestructura");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "VARGAS", SegundoApellido = "MAMANI", PrimerNombre = "NORMA",
                    SegundoNombre = "ARACELY"
                }, "Secretaria de Prestaciones");
            AddNew(
                new Beneficiario
                    {PrimerApellido = "MACHACA", SegundoApellido = "PACO", PrimerNombre = "MARIO", SegundoNombre = ""},
                "Mensajero Of. Central");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "LAFUENTE", SegundoApellido = "CAMACHO", PrimerNombre = "MERY",
                    SegundoNombre = "ROXANA"
                }, "Auxiliar Contable Cochabamba");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CHUQUIMIA", SegundoApellido = "ROLLANO", PrimerNombre = "LAURA",
                    SegundoNombre = "FÁTIMA"
                }, "Secretearia Agencia Regional Cochabamba");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "FERNANDEZ", SegundoApellido = "HUALLPA", PrimerNombre = "IGNACIO",
                    SegundoNombre = ""
                }, "Ujier - Servicio");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "MARAÑON", SegundoApellido = "ALDERETE", PrimerNombre = "LILIANA",
                    SegundoNombre = ""
                }, "Secretaria Agencia Regional Santa Cruz");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "SOTO", SegundoApellido = "QUISPE", PrimerNombre = "KEISI",
                    SegundoNombre = "MARIBEL"
                }, "Portero Mensajero Cochabamba");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "LAURA", SegundoApellido = "SALGUERO", PrimerNombre = "DANIELA", SegundoNombre = ""
                }, "Secretaria Agencia Regional Oruro");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "BENITEZ", SegundoApellido = "SALGUERO", PrimerNombre = "MARIELA",
                    SegundoNombre = "CINTHIA"
                }, "Secretaria Agencia Regional Potosi");
            AddNew(
                new Beneficiario
                    {PrimerApellido = "ROMAN", SegundoApellido = "VACA", PrimerNombre = "TERESA", SegundoNombre = ""},
                "Portero Santa Cruz");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ORTUBE", SegundoApellido = "RODRIGUEZ", PrimerNombre = "RENE",
                    SegundoNombre = "GONZALO"
                }, "Secretaria Agencia Regional Sucre");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "PADILLA", SegundoApellido = "FUENTES", PrimerNombre = "MARIELA",
                    SegundoNombre = "JUANA"
                }, "Secretaria Agencia Regional Tarija");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ESPINOZA", SegundoApellido = "MUÑUNY", PrimerNombre = "ANA",
                    SegundoNombre = "LIDA"
                }, "Secretaria Agencia Regional Trinidad");
           
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "COILA", SegundoApellido = "FLORES", PrimerNombre = "MARCIAL", SegundoNombre = ""
                }, "Portero Potosi");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "MERCADO", SegundoApellido = "NEGRETE", PrimerNombre = "CLAUDIA",
                    SegundoNombre = "KARINA"
                }, "Portero Santa Cruz");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "SOLIZ", SegundoApellido = "ORIHUELA", PrimerNombre = "WILMA", SegundoNombre = ""
                }, "Portero Sucre");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "EGUEZ", SegundoApellido = "BARRON", PrimerNombre = "MIGUEL",
                    SegundoNombre = "OSCAR"
                }, "Portero Tarija");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "MELGAREJO", SegundoApellido = "CALLAU", PrimerNombre = "ZULMA", SegundoNombre = ""
                }, "Agente Distrital Camiri");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "VELARDE", SegundoApellido = "AGUILAR", PrimerNombre = "LITSY", SegundoNombre = ""
                }, "Agente Distrital Punata");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "SALAS", SegundoApellido = "CHÁVEZ", PrimerNombre = "MARÍA",
                    SegundoNombre = "FÁTIMA"
                }, "Agente Distrital Magdalena");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "MARTINEZ", SegundoApellido = "ROMERO", PrimerNombre = "JUAN",
                    SegundoNombre = "JOSÉ"
                }, "Agente Distrital Tupiza");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "NETZ", SegundoApellido = "HERRERA", PrimerNombre = "DE EGUEZ",
                    SegundoNombre = "HORTENCIA"
                }, "Agente Distrital San Matias");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ZAMBRANA", SegundoApellido = "MENDOZA", PrimerNombre = "VIANCA",
                    SegundoNombre = ""
                }, "Agente Distrital San Ignacio de Moxos");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ZUAZO", SegundoApellido = "CAVEROS", PrimerNombre = "MANUEL",
                    SegundoNombre = "ANTONIO"
                }, "Agente Distrital Caranavi");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ALBINO", SegundoApellido = "MENDOZA", PrimerNombre = "SANTIAGO",
                    SegundoNombre = ""
                }, "Agente Distrital Uyuni");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ANTELO", SegundoApellido = "ESPINOZA", PrimerNombre = "ISRAEL", SegundoNombre = ""
                }, "Agente Distrital Puerto Suarez");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "BARBERY", SegundoApellido = "CESPEDES", PrimerNombre = "DENNY", SegundoNombre = ""
                }, "Agente Distrital S.J.Chiquitos");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ORTEGA", SegundoApellido = "VILLEGAS", PrimerNombre = "ANGEL", SegundoNombre = ""
                }, "Agente Distrital Cotagaita");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CONDORI", SegundoApellido = "AVILA", PrimerNombre = "MARIA",
                    SegundoNombre = "ESTHER"
                }, "Agente Distrital Yacuiba");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "COPA", SegundoApellido = "VEGA", PrimerNombre = "OMAR", SegundoNombre = "CARLOS"
                }, "Agente Distrital Atocha");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CORDERO", SegundoApellido = "MEJIA", PrimerNombre = "WILFREDO", SegundoNombre = ""
                }, "Agente Distrital Aiquile");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ESCALANTE", SegundoApellido = "LOAYZA", PrimerNombre = "BEBSY", SegundoNombre = ""
                }, "Agente Distrital Rurrenabaque");
            AddNew(
                new Beneficiario
                    {PrimerApellido = "FRIAS", SegundoApellido = "ESPAÑA", PrimerNombre = "CARLOS", SegundoNombre = ""},
                "Agente Distrital San Ignacio de Velasco");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "GALARZA", SegundoApellido = "VELASQUEZ", PrimerNombre = "JUANA",
                    SegundoNombre = "DANNY"
                }, "Agente Distrital Bermejo");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "GONZALES", SegundoApellido = "TITO", PrimerNombre = "FELIPE", SegundoNombre = ""
                }, "Agente Distrital Villazon");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "MANCILLA", SegundoApellido = "RODRIGUEZ", PrimerNombre = "GERALDINA",
                    SegundoNombre = ""
                }, "Agente Distrital Camargo");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "MENDOZA", SegundoApellido = "ORTÍZ", PrimerNombre = "FLORENCIO",
                    SegundoNombre = ""
                }, "Agente Distrital Robore");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "PIMIENTA", SegundoApellido = "MUÑOZ", PrimerNombre = "JOSE",
                    SegundoNombre = "LUIS"
                }, "Agente Distrital Llallagua");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "ROBLES", SegundoApellido = "VILLAVICENCIO", PrimerNombre = "SAUL",
                    SegundoNombre = ""
                }, "Agente Distrital Santa Ana");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "VARGAS", SegundoApellido = "PADILLA", PrimerNombre = "YENNY", SegundoNombre = ""
                }, "Agente Distrital Monteagudo");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "SALVATIERRA", SegundoApellido = "SABENE", PrimerNombre = "DILMA",
                    SegundoNombre = ""
                }, "Agente Distrital Guayaramerin");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "TIBUBAY", SegundoApellido = "DE", PrimerNombre = "VIDAURRE",
                    SegundoNombre = "ERLIN"
                }, "Agente Distrital Puerto Rico");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CAPURATA", SegundoApellido = "CASTILLO", PrimerNombre = "ERICA",
                    SegundoNombre = ""
                }, "Agente Distrital Villamontes");
            AddNew(
                new Beneficiario
                    {PrimerApellido = "MONTAÑO", SegundoApellido = "FÁTIMA", PrimerNombre = "", SegundoNombre = ""},
                "Agente Distrital Vallegrande");
            AddNew(
                new Beneficiario
                {
                    PrimerApellido = "CALLISAYA", SegundoApellido = "FORONDA", PrimerNombre = "FELIX",
                    SegundoNombre = ""
                }, "Agente Distrital Apolo");
        }

        private void AddNew(Beneficiario item, String cargo)
        {
            
            var puesto = _context.RRHH_Puesto.FirstOrDefault(p => EF.Functions.ILike(p.Descripcion, $"%{cargo.ToLower()}%"));
            var existing = _context.RRHH_Beneficiario.FirstOrDefault(p => p.PrimerApellido == item.PrimerApellido &&
                                                                          p.SegundoApellido == item.SegundoApellido &&
                                                                          p.PrimerNombre == item.PrimerNombre);

            if (existing == null)
            {
                string full_name = "";
                if (item.PrimerApellido.Trim() != "")
                {
                    full_name += $" {item.PrimerApellido}";
                }
                
                if (item.SegundoApellido.Trim() != "")
                {
                    full_name += $" {item.SegundoApellido}";
                }
                
                if (item.PrimerNombre.Trim() != "")
                {
                    full_name += $" {item.PrimerNombre}";
                }
                
                if (item.SegundoNombre.Trim() != "")
                {
                    full_name += $" {item.SegundoNombre}";
                }

                if (puesto != null)
                {
                    item.PuestoId = puesto.IdPuesto;    
                }

                item.IdEstadoRegistro = Constantes.Registrado;
                item.IdUsuario = 0;
                item.Denominacion = full_name.Trim();
                _context.RRHH_Beneficiario.Add(item);
                _context.SaveChanges();
            }
            else if(existing.PuestoId == 1 && puesto != null)
            {
                existing.PuestoId = puesto.IdPuesto;
            }
        }
    }
}