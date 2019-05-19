using System;
using MumanalPG.Models.RRHH;
using System.Linq;
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
            var puestos = _context.RRHH_Puesto.Where(p => p.IdPuesto > 1).ToList();
            var index = 1;
            foreach (var p in puestos)
            {
                index = ActualizarBeneficiarioPuesto(p.IdPuesto, index);
                index++;
            }
            _context.SaveChanges();
        }

        // since we run this seeder when the app starts
        // we should avoid adding duplicates, so check first
        // then add
        private int ActualizarBeneficiarioPuesto(int puestoId, int index = 1)
        {
            var beneficiario = _context.RRHH_Beneficiario.FirstOrDefault(p => p.IdBeneficiario == index);

            if(beneficiario != null)
            {
                beneficiario.PuestoId = puestoId;
                _context.RRHH_Beneficiario.Update(beneficiario);
               
            }
            else
            {
                index++;
                index = ActualizarBeneficiarioPuesto(puestoId, index);
            }
            return index;
        }
    }
}