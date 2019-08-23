using System.Linq;
using MumanalPG.Models.RRHH;

namespace MumanalPG.Data.Seeders
{
    public class UnidadEjecutoraSeeder
    {
        private readonly ApplicationDbContext _context;
        public UnidadEjecutoraSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            AddNew(new UnidadEjecutora { Descripcion = "Gerencia General", Sigla = "GG", OrdenMostrar = 1});
            AddNew(new UnidadEjecutora { Descripcion = "Regionales", Sigla = "REG", OrdenMostrar = 3});
            AddNew(new UnidadEjecutora { Descripcion = "Secretaría General", Sigla = "SG", OrdenMostrar = 1}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Comité de Vigilancia", Sigla = "COM-VIG", OrdenMostrar = 2});
            AddNew(new UnidadEjecutora { Descripcion = "Auditoria Interna", Sigla = "AI", OrdenMostrar = 5}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Asesoría Tecnica", Sigla = "AT", OrdenMostrar = 6}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad Jurídica", Sigla = "UJ", OrdenMostrar = 4}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Recursos Humanos", Sigla = "RRHH", OrdenMostrar = 7}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad Administrativa Financiera", Sigla = "UAF", OrdenMostrar = 3}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Regímenes Especiales", Sigla = "URE"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Prestaciones", Sigla = "UP", OrdenMostrar = 2}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Contabilidad", Sigla = "CON"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Inversiones", Sigla = "INV"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Sistemas", Sigla = "SIS"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Tesoreria", Sigla = "TES"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Activos Fijos", Sigla = "AF"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Prestaciones", Sigla = "PRE"}, "UP");
            AddNew(new UnidadEjecutora { Descripcion = "Cotizaciones", Sigla = "COT"}, "UP");
            AddNew(new UnidadEjecutora { Descripcion = "Servicios Sociales", Sigla = "SS"}, "UP");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Cochabamba", Sigla = "CBBA"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional La Paz", Sigla = "LP"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Cobija", Sigla = "COB"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Oruro", Sigla = "OR"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Potosi", Sigla = "PT"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Santa Cruz", Sigla = "SC"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Sucre", Sigla = "SUC"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Tarija", Sigla = "TJ"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Trinidad", Sigla = "TRI"}, "REG");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital El Alto", Sigla = "DIS.ALT"}, "LP");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Montero", Sigla = "DIS.MON"}, "SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Camiri", Sigla = "DIS.CAM"}, "SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Quillacollo", Sigla = "DIS.QUILL"}, "CBBA");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Punata", Sigla = "DIS.PUN"}, "CBBA");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Riberalta", Sigla = "DIS.RIB"}, "TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Magdalena", Sigla = "DIS.MAG"}, "TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Tupiza", Sigla = "DIS.TUP"}, "PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital San Matias", Sigla = "DIS.SANMAT"}, "SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital San Ignacio de Moxos", Sigla = "DIS.MOX"}, "TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Caranavi", Sigla = "DIS.CAR"}, "LP");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Uyuni", Sigla = "DIS.UYU"}, "PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Puerto Suarez", Sigla = "DIS.PSUA"}, "SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital S.J.Chiquitos", Sigla = "DIS.SJCH"}, "SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Cotagaita", Sigla = "DIS.COT"}, "PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Yacuiba", Sigla = "DIS.YAC"}, "TJ");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Atocha", Sigla = "DIS.ATCH"}, "PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Aiquile", Sigla = "DIS.AIQU"}, "CBBA");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Rurrenabaque", Sigla = "DIS.RURRE"}, "TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital San Ignacio de Velasco", Sigla = "DIS.SIVEL"}, "SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Bermejo", Sigla = "DIS.BER"}, "TJ");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Villazon", Sigla = "DIS.VILL"}, "PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Camargo", Sigla = "DIS.CAMG"}, "SUC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Robore", Sigla = "DIS.ROB"}, "SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Llallagua", Sigla = "DIS.LLA"}, "PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Santa Ana de Yacuma", Sigla = "DIS.SAYACU"}, "TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Monteagudo", Sigla = "DIS.MONTG"}, "SUC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Guayaramerin", Sigla = "DIS.GUAY"}, "TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Puerto Rico", Sigla = "DIS.PR"}, "COB");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Villamontes", Sigla = "DIS.VILLAM"}, "TJ");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Vallegrande", Sigla = "DIS.VALLEG"}, "SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Apolo", Sigla = "DIS.APO"}, "LP");

        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNew(UnidadEjecutora item, string siglaPadre = "")
        {
            var existing = _context.RRHH_UnidadEjecutora.FirstOrDefault(p => p.Descripcion == item.Descripcion &&
                                                                             p.EsExterna == false);

            if(existing == null)
            {
                var parent = _context.RRHH_UnidadEjecutora.FirstOrDefault(p => p.Sigla == siglaPadre && p.EsExterna == false);
                if (parent != null)
                {
                    item.IdUnidadEjecutoraPadre = parent.IdUnidadEjecutora;
                }
                else
                {
                    item.IdUnidadEjecutoraPadre = 0;
                }

                _context.RRHH_UnidadEjecutora.Add(item);
                _context.SaveChanges();
            }
        }
    }
}