using System;
using System.Linq;
using MumanalPG.Models.Correspondencia;

namespace MumanalPG.Data.Seeders
{
    public class TipoAnexoSeeder
    {
        private readonly ApplicationDbContext _context;
        public TipoAnexoSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            //IdDepartamento = 2 => para LA PAZ, IUsuario = 1 => Admin, 
            AddNew(new TipoAnexo { Nombre = "Auto", Descripcion = "", FechaRegistro = DateTime.Now});
            AddNew(new TipoAnexo { Nombre = "Ayuda Memoria", Descripcion = "", FechaRegistro = DateTime.Now});
            AddNew(new TipoAnexo { Nombre = "Decreto", Descripcion = "", FechaRegistro = DateTime.Now});
            AddNew(new TipoAnexo { Nombre = "Exp. Trámite", Descripcion = "", FechaRegistro = DateTime.Now});
            AddNew(new TipoAnexo { Nombre = "Informe", Descripcion = "", FechaRegistro = DateTime.Now});
            AddNew(new TipoAnexo { Nombre = "Nota", Descripcion = "", FechaRegistro = DateTime.Now});
            AddNew(new TipoAnexo { Nombre = "Resolución", Descripcion = "", FechaRegistro = DateTime.Now});
            AddNew(new TipoAnexo { Nombre = "CD/DVD", Descripcion = "", FechaRegistro = DateTime.Now});

            
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private void AddNew(TipoAnexo item)
        {
            var existing = _context.CorrespondenciaTipoAnexo.FirstOrDefault(a => a.Nombre == item.Nombre);

            if(existing == null)
            {
                _context.CorrespondenciaTipoAnexo.Add(item);
                
            }
        }
    }
}