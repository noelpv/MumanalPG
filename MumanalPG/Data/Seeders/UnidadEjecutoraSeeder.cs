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
            AddNew(new UnidadEjecutora { Descripcion = "Auditoria Interna", Sigla = "AI"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Asesoría Tecnica", Sigla = "AT"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad Jurídica", Sigla = "UJ"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Recursos Humanos", Sigla = "RRHH"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad Administrativa Financiera", Sigla = "UAF"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Regímenes Especiales", Sigla = "URE"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Unidad de Prestaciones", Sigla = "UP"}, "GG");
            AddNew(new UnidadEjecutora { Descripcion = "Contabilidad", Sigla = "CON"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Sistemas", Sigla = "SIS"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Tesoreria", Sigla = "TES"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Activos Fijos", Sigla = "AF"}, "UAF");
            AddNew(new UnidadEjecutora { Descripcion = "Prestaciones", Sigla = "PRE"}, "UP");
            AddNew(new UnidadEjecutora { Descripcion = "Cotizaciones", Sigla = "COT"}, "UP");
            AddNew(new UnidadEjecutora { Descripcion = "Servicios Sociales", Sigla = "SS"}, "UP");
            
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