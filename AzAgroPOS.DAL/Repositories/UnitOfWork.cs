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
        public VahidRepository AltVahidler { get; private set; }
        public MehsulKateqoriyasiRepository UstMehsulKateqoriyalari { get; private set; }
        public BorcOdenisRepository BorcOdenisleri { get; private set; }
        
        // Əlavə edilən repozitorilər
        public AlisOrderRepository AlisOrderleri { get; private set; }
        public AlisSenedRepository AlisSenedleri { get; private set; }
        public AnbarHereketRepository AnbarHereketleri { get; private set; }
        public AnbarTransferRepository AnbarTransferleri { get; private set; }
        public BackupKaydiRepository BackupKayitlari { get; private set; }
        public BackupTenzimlemeRepository BackupTenzimlemeleri { get; private set; }
        public BildirisAyariRepository BildirisAyarlari { get; private set; }
        public BildirisRepository Bildirisler { get; private set; }
        public IsciIzniRepository IsciIzinleri { get; private set; }
        public MusteriQrupuRepository MusteriQruplari { get; private set; }
        public NovbeCedveliRepository NovbeCedvelleri { get; private set; }
        public NovbeDetaliRepository NovbeDetallari { get; private set; }
        public NovbeRepository Novbeler { get; private set; }
        public PrintLogKaydiRepository PrintLogKayitlari { get; private set; }
        public PrintSablonuRepository PrintSablonlari { get; private set; }
        public PrinterKonfiqurasiyasiRepository PrinterKonfiqurasiyas { get; private set; }
        public SatisHesabatiRepository SatisHesabatlari { get; private set; }
        public SistemAyarlariRepository SistemAyarlari { get; private set; }
        public TamirMerheleRepository TamirMerheleri { get; private set; }
        public TedarukcuOdemeRepository TedarukcuOdemeleri { get; private set; }

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
            AltVahidler = new VahidRepository(_context);
            UstMehsulKateqoriyalari = new MehsulKateqoriyasiRepository(_context);
            BorcOdenisleri = new BorcOdenisRepository(_context);
            
            // Əlavə edilən repozitoriləri initialize edirik
            AlisOrderleri = new AlisOrderRepository(_context);
            AlisSenedleri = new AlisSenedRepository(_context);
            AnbarHereketleri = new AnbarHereketRepository(_context);
            AnbarTransferleri = new AnbarTransferRepository(_context);
            BackupKayitlari = new BackupKaydiRepository(_context);
            BackupTenzimlemeleri = new BackupTenzimlemeRepository(_context);
            BildirisAyarlari = new BildirisAyariRepository(_context);
            Bildirisler = new BildirisRepository(_context);
            IsciIzinleri = new IsciIzniRepository(_context);
            MusteriQruplari = new MusteriQrupuRepository(_context);
            NovbeCedvelleri = new NovbeCedveliRepository(_context);
            NovbeDetallari = new NovbeDetaliRepository(_context);
            Novbeler = new NovbeRepository(_context);
            PrintLogKayitlari = new PrintLogKaydiRepository(_context);
            PrintSablonlari = new PrintSablonuRepository(_context);
            PrinterKonfiqurasiyas = new PrinterKonfiqurasiyasiRepository(_context);
            SatisHesabatlari = new SatisHesabatiRepository(_context);
            SistemAyarlari = new SistemAyarlariRepository(_context);
            TamirMerheleri = new TamirMerheleRepository(_context);
            TedarukcuOdemeleri = new TedarukcuOdemeRepository(_context);
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