using AzAgroPOS.BLL.Interfaces;
using System.Threading.Tasks;

namespace AzAgroPOS.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AzAgroDbContext _context;

        public IstifadeciRepository Istifadeciler { get; private set; }
        public SatisRepository Satislar { get; private set; }
        public SatisDetaliRepository SatisDetallari { get; private set; }
        public SatisOdemesiRepository SatisOdemeleri { get; private set; }
        public AnbarQalikRepository AnbarQaliqlari { get; private set; }
        public MehsulRepository Mehsullar { get; private set; }
        public MusteriBorcRepository MusteriBorclari { get; private set; }
        public MusteriRepository Musteriler { get; private set; }
        public TedarukcuRepository Tedarukciler { get; private set; }
        public AnbarRepository Anbarlar { get; private set; }
        public GiderRepository Giderler { get; private set; }
        public TamirIsiRepository TamirIsleri { get; private set; }
        public IsciRepository Isciler { get; private set; }
        public RolRepository Roller { get; private set; }
        public MehsulKateqoriyasiRepository MehsulKateqoriyalari { get; private set; }
        public VahidRepository Vahidler { get; private set; }
        public BorcOdenisRepository BorcOdenisleri { get; private set; }

        public UnitOfWork(AzAgroDbContext context)
        {
            _context = context;

            // Bütün repozitoriləri eyni DbContext ilə yaradırıq
            Istifadeciler = new IstifadeciRepository(_context);
            Satislar = new SatisRepository(_context);
            SatisDetallari = new SatisDetaliRepository(_context);
            SatisOdemeleri = new SatisOdemesiRepository(_context);
            AnbarQaliqlari = new AnbarQalikRepository(_context);
            Mehsullar = new MehsulRepository(_context);
            MusteriBorclari = new MusteriBorcRepository(_context);
            Musteriler = new MusteriRepository(_context);
            Tedarukciler = new TedarukcuRepository(_context);
            Anbarlar = new AnbarRepository(_context);
            Giderler = new GiderRepository(_context);
            TamirIsleri = new TamirIsiRepository(_context);
            Isciler = new IsciRepository(_context);
            Roller = new RolRepository(_context);
            MehsulKateqoriyalari = new MehsulKateqoriyasiRepository(_context);
            Vahidler = new VahidRepository(_context);
            BorcOdenisleri = new BorcOdenisRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}