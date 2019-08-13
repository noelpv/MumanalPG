using MumanalPG.Models.RRHH;
using System.Linq;

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
            AddNew(new UnidadEjecutora { Descripcion = "Gerencia General", Sigla = "GG"});
            AddNew(new UnidadEjecutora { Descripcion = "Secretaría General", Sigla = "SG"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Comité de Vigilancia", Sigla = "COMVIG"});
            AddNew(new UnidadEjecutora { Descripcion = "Auditoria Interna", Sigla = "AI"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Asesoría Tecnica", Sigla = "AT"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad Jurídica", Sigla = "UJ"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Recursos Humanos", Sigla = "RRHH"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad Administrativa Financiera", Sigla = "UAF"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Regímenes Especiales", Sigla = "URE"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Prestaciones", Sigla = "UP"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Contabilidad", Sigla = "CON"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Inversiones", Sigla = "INV"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Sistemas", Sigla = "SIS"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Tesoreria", Sigla = "TES"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Activos Fijos", Sigla = "AF"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Prestaciones", Sigla = "PRE"}, "UP");
            AddNew(new UnidadEjecutora { Descripcion = "Cotizaciones", Sigla = "COT"}, "UP");
            AddNew(new UnidadEjecutora { Descripcion = "Servicios Sociales", Sigla = "SS"}, "UP");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Cochabamba", Sigla = "REG.CBBA"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional La Paz", Sigla = "REG.LP"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Cobija", Sigla = "REG.COB"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Oruro", Sigla = "REG.OR"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Potosi", Sigla = "REG.PT"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Santa Cruz", Sigla = "REG.SC"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Sucre", Sigla = "REG.SUC"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Tarija", Sigla = "REG.TJ"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Regional Trinidad", Sigla = "REG.TRI"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital El Alto", Sigla = "DIS.ALT"}, "REG.LP");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Montero", Sigla = "DIS.MON"}, "REG.SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Camiri", Sigla = "DIS.CAM"}, "REG.SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Quillacollo", Sigla = "DIS.QUILL"}, "REG.CBBA");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Punata", Sigla = "DIS.PUN"}, "REG.CBBA");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Riberalta", Sigla = "DIS.RIB"}, "REG.TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Magdalena", Sigla = "DIS.MAG"}, "REG.TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Tupiza", Sigla = "DIS.TUP"}, "REG.PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital San Matias", Sigla = "DIS.SANMAT"}, "REG.SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital San Ignacio de Moxos", Sigla = "DIS.MOX"}, "REG.TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Caranavi", Sigla = "DIS.CAR"}, "REG.LP");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Uyuni", Sigla = "DIS.UYU"}, "REG.PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Puerto Suarez", Sigla = "DIS.PSUA"}, "REG.SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital S.J.Chiquitos", Sigla = "DIS.SJCH"}, "REG.SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Cotagaita", Sigla = "DIS.COT"}, "REG.PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Yacuiba", Sigla = "DIS.YAC"}, "REG.TJ");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Atocha", Sigla = "DIS.ATCH"}, "REG.PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Aiquile", Sigla = "DIS.AIQU"}, "REG.CBBA");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Rurrenabaque", Sigla = "DIS.RURRE"}, "REG.TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital San Ignacio de Velasco", Sigla = "DIS.SIVEL"}, "REG.SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Bermejo", Sigla = "DIS.BER"}, "REG.TJ");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Villazon", Sigla = "DIS.VILL"}, "REG.PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Camargo", Sigla = "DIS.CAMG"}, "REG.SUC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Robore", Sigla = "DIS.ROB"}, "REG.SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Llallagua", Sigla = "DIS.LLA"}, "REG.PT");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Santa Ana de Yacuma", Sigla = "DIS.SAYACU"}, "REG.TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Monteagudo", Sigla = "DIS.MONTG"}, "REG.SUC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Guayaramerin", Sigla = "DIS.GUAY"}, "REG.TRI");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Puerto Rico", Sigla = "DIS.PR"}, "REG.COB");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Villamontes", Sigla = "DIS.VILLAM"}, "REG.TJ");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Vallegrande", Sigla = "DIS.VALLEG"}, "REG.SC");
            AddNew(new UnidadEjecutora { Descripcion = "Distrital Apolo", Sigla = "DIS.APO"}, "REG.LP");
            
            
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNew(UnidadEjecutora item, string siglaPadre = "")
        {
            var existing = _context.RRHH_UnidadEjecutora.FirstOrDefault(p => p.Descripcion == item.Descripcion);

            if(existing == null)
            {
                var parent = _context.RRHH_UnidadEjecutora.FirstOrDefault(p => p.Sigla == siglaPadre);
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