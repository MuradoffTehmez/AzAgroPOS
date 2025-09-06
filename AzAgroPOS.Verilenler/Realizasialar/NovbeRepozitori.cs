using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AzAgroPOS.Verilenler.Realizasialar
{
    public class NovbeRepozitori : Repozitori<Novbe>, INovbeRepozitori
    {
        private readonly AzAgroPOSDbContext _kontekst;

        public NovbeRepozitori(AzAgroPOSDbContext kontekst) : base(kontekst)
        {
            _kontekst = kontekst;
        }

        public async Task<Novbe> AktivNovbeniGetirAsync()
        {
            return await _kontekst.Novbeler
                .Include(n => n.Isci)
                .FirstOrDefaultAsync(n => n.Status == NovbeStatusu.Aciq);
        }
        
        public async Task<Novbe?> AktivNovbeniGetirAsync(int isciId)
        {
            return await _kontekst.Novbeler
                .FirstOrDefaultAsync(n => n.IsciId == isciId && n.Status == NovbeStatusu.Aciq);
        }
    }
}