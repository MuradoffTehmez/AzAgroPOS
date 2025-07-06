-- ===============================================
-- AzAgroPOS - Kənd Təsərrüfatı POS Sistemi
-- Tam və Detallı Verilənlər Bazası Skripti
-- Versiya: 2.5
-- Müəllif: Muradov Təhməz
-- Tarix: 2025
-- ===============================================

-- Verilənlər bazasının yaradılması
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AzAgroPOS_DB')
BEGIN
    CREATE DATABASE AzAgroPOS_DB
    COLLATE Azerbaijani_Latin_100_CI_AS;
    PRINT 'AzAgroPOS verilənlər bazası yaradıldı';
END
ELSE
BEGIN
    PRINT 'AzAgroPOS verilənlər bazası artıq mövcuddur';
END
GO

USE AzAgroPOS_DB;
GO

-- Verilənlər bazası səviyyəsində optimallaşdırma parametrləri
ALTER DATABASE AzAgroPOS_DB SET RECOVERY SIMPLE;
ALTER DATABASE AzAgroPOS_DB SET AUTO_UPDATE_STATISTICS ON;
ALTER DATABASE AzAgroPOS_DB SET AUTO_CREATE_STATISTICS ON;
ALTER DATABASE AzAgroPOS_DB SET AUTO_SHRINK OFF;
ALTER DATABASE AzAgroPOS_DB SET PAGE_VERIFY CHECKSUM;
GO

-- ===============================================
-- 1. SİSTEM KONFİQURASİYASI VƏ ŞİRKƏT MƏLUMATLARI
-- ===============================================

-- Sistem konfiqurasiya cədvəli
CREATE TABLE sistem_konfiqurasiyasi (
    id INT PRIMARY KEY IDENTITY(1,1),
    acar NVARCHAR(100) UNIQUE NOT NULL,
    deyer NVARCHAR(MAX) NOT NULL,
    tip NVARCHAR(50) NOT NULL CHECK (tip IN ('STRING', 'INTEGER', 'DECIMAL', 'BOOLEAN', 'JSON', 'DATE')),
    tesvir NVARCHAR(255) NULL,
    varsayilan_deyer NVARCHAR(MAX) NULL,
    son_deyisiklik DATETIME DEFAULT GETDATE() NOT NULL,
    deyisen_istifadeci_id INT NULL,
    modul NVARCHAR(50) NULL CHECK (modul IN ('GENEL', 'SATIS', 'STOK', 'MUSTERI', 'TEMIR', 'FINANS', 'PERSONEL'))
);
GO

-- Şirkət məlumatları cədvəli
CREATE TABLE sirket_melumatlari (
    id INT PRIMARY KEY IDENTITY(1,1),
    sirket_adi NVARCHAR(150) NOT NULL,
    qisa_adi NVARCHAR(50) NULL,
    vergi_nomresi NVARCHAR(20) UNIQUE NOT NULL,
    vergi_dairesi NVARCHAR(100) NULL,
    unvan NVARCHAR(MAX) NOT NULL,
    seher NVARCHAR(50) NULL,
    rayon NVARCHAR(50) NULL,
    kend NVARCHAR(50) NULL,
    telefon NVARCHAR(20) NOT NULL,
    telefon2 NVARCHAR(20) NULL,
    fax NVARCHAR(20) NULL,
    email NVARCHAR(100) NULL CHECK (email LIKE '%@%.%'),
    website NVARCHAR(150) NULL,
    logo_yolu NVARCHAR(255) NULL,
    direktor_adi NVARCHAR(100) NULL,
    direktor_imza_yolu NVARCHAR(255) NULL,
    muhasib_adi NVARCHAR(100) NULL,
    bank_hesab_nomresi NVARCHAR(50) NULL,
    bank_adi NVARCHAR(100) NULL,
    bank_kodu NVARCHAR(20) NULL,
    swift_kodu NVARCHAR(20) NULL,
    aktiv_statusu BIT DEFAULT 1 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    deyisen_istifadeci_id INT NULL
);
GO

-- Filiallar/Mağazalar cədvəli
CREATE TABLE filiallar (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) NOT NULL,
    kodu NVARCHAR(20) UNIQUE NOT NULL,
    unvan NVARCHAR(MAX) NOT NULL,
    seher NVARCHAR(50) NULL,
    rayon NVARCHAR(50) NULL,
    kend NVARCHAR(50) NULL,
    telefon NVARCHAR(20) NOT NULL,
    telefon2 NVARCHAR(20) NULL,
    email NVARCHAR(100) NULL CHECK (email LIKE '%@%.%'),
    enlem DECIMAL(10, 6) NULL,
    boylam DECIMAL(10, 6) NULL,
    manager_id INT NULL,
    acilis_tarixi DATE NOT NULL,
    baglanma_tarixi DATE NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    qeyd NVARCHAR(500) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    deyisen_istifadeci_id INT NULL
);
GO

-- ===============================================
-- 2. İSTİFADƏÇİ VƏ İDARƏETMƏ MODULU
-- ===============================================

-- Rollar cədvəli
CREATE TABLE rollar (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) UNIQUE NOT NULL,
    tesvir NVARCHAR(255) NULL,
    huquqlar NVARCHAR(MAX) NULL, -- JSON formatında saxlanılır
    seviyye INT DEFAULT 1 NOT NULL CHECK (seviyye BETWEEN 1 AND 5),
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    sistem_rolu BIT DEFAULT 0 NOT NULL
);
GO

-- İstifadəçilər cədvəli
CREATE TABLE istifadeciler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) NOT NULL,
    soyad NVARCHAR(50) NOT NULL,
    ata_adi NVARCHAR(50) NULL,
    istifadeci_adi NVARCHAR(50) UNIQUE NOT NULL,
    parol_hash NVARCHAR(512) NOT NULL,
    parol_salt NVARCHAR(128) NOT NULL,
    rol_id INT NOT NULL,
    filial_id INT NULL,
    telefon NVARCHAR(20) NULL CHECK (telefon LIKE '+994%' OR telefon LIKE '0%'),
    telefon2 NVARCHAR(20) NULL,
    email NVARCHAR(100) NULL CHECK (email LIKE '%@%.%'),
    dogum_tarixi DATE NULL,
    ise_baslama_tarixi DATE NULL,
    isden_cixma_tarixi DATE NULL,
    maas DECIMAL(18,2) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    son_giris_tarixi DATETIME NULL,
    son_parol_deyisiklik DATETIME NULL,
    parol_son_istifade_tarixi DATETIME NULL,
    giris_cehd_sayi INT DEFAULT 0 NOT NULL,
    bloklanma_tarixi DATETIME NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    deaktivasiya_tarixi DATETIME NULL,
    sekil_yolu NVARCHAR(255) NULL,
    imza_yolu NVARCHAR(255) NULL,
    qeyd NVARCHAR(500) NULL,
    CONSTRAINT CHK_istifadeci_adi CHECK (LEN(istifadeci_adi) >= 4),
    CONSTRAINT FK_istifadeciler_rollar FOREIGN KEY (rol_id) REFERENCES rollar(id),
    CONSTRAINT FK_istifadeciler_filiallar FOREIGN KEY (filial_id) REFERENCES filiallar(id)
);
GO

-- Əməliyyat jurnalı cədvəli
CREATE TABLE emeliyyat_jurnali (
    id INT PRIMARY KEY IDENTITY(1,1),
    istifadeci_id INT NOT NULL,
    filial_id INT NULL,
    emeliyyat_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    emeliyyat_novu NVARCHAR(100) NOT NULL,
    emeliyyat_obyekti NVARCHAR(100) NULL,
    obyekt_id INT NULL,
    kohne_deyer NVARCHAR(MAX) NULL,
    yeni_deyer NVARCHAR(MAX) NULL,
    tesvir NVARCHAR(MAX) NULL,
    ip_adresi NVARCHAR(45) NULL,
    brauzer_melumati NVARCHAR(255) NULL,
    cihaz_melumati NVARCHAR(255) NULL,
    ugurlu_statusu BIT DEFAULT 1 NOT NULL,
    xeta_mesaji NVARCHAR(MAX) NULL,
    xeta_kodu NVARCHAR(50) NULL,
    xeta_stack_trace NVARCHAR(MAX) NULL,
    CONSTRAINT FK_emeliyyat_jurnali_istifadeciler FOREIGN KEY (istifadeci_id) REFERENCES istifadeciler(id),
    CONSTRAINT FK_emeliyyat_jurnali_filiallar FOREIGN KEY (filial_id) REFERENCES filiallar(id)
);
GO

-- ===============================================
-- 3. MƏHSUL VƏ STOK İDARƏÇİLİYİ
-- ===============================================

-- Kateqoriyalar cədvəli
CREATE TABLE kateqoriyalar (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) NOT NULL,
    kodu NVARCHAR(20) UNIQUE NULL,
    tesvir NVARCHAR(255) NULL,
    ana_kateqoriya_id INT NULL,
    sekil_yolu NVARCHAR(255) NULL,
    renk_kodu NVARCHAR(7) NULL CHECK (renk_kodu LIKE '#%' AND LEN(renk_kodu) = 7),
    siralama INT DEFAULT 0 NOT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    deyisen_istifadeci_id INT NULL,
    CONSTRAINT FK_kateqoriyalar_ana_kateqoriya FOREIGN KEY (ana_kateqoriya_id) REFERENCES kateqoriyalar(id),
    CONSTRAINT CHK_kateqoriya_kodu CHECK (kodu IS NULL OR LEN(kodu) >= 2)
);
GO

-- Vahidlər cədvəli
CREATE TABLE vahidler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) UNIQUE NOT NULL,
    qisaltma NVARCHAR(10) NOT NULL,
    tip NVARCHAR(50) NOT NULL CHECK (tip IN ('Ədəd', 'Çəki', 'Həcm', 'Uzunluq', 'Sahə', 'Vaxt', 'Digər')),
    cevirme_emsali DECIMAL(18,6) DEFAULT 1 NOT NULL,
    esas_vahid_id INT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    CONSTRAINT FK_vahidler_esas_vahid FOREIGN KEY (esas_vahid_id) REFERENCES vahidler(id)
);
GO

-- Brendlər cədvəli
CREATE TABLE brendler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) UNIQUE NOT NULL,
    kodu NVARCHAR(20) UNIQUE NULL,
    tesvir NVARCHAR(255) NULL,
    logo_yolu NVARCHAR(255) NULL,
    website NVARCHAR(150) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL
);
GO

-- Tədarükçülər cədvəli
CREATE TABLE tedarukcüler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) NOT NULL,
    kodu NVARCHAR(20) UNIQUE NOT NULL,
    vergi_nomresi NVARCHAR(20) NULL,
    elaqe_shexsi NVARCHAR(100) NULL,
    telefon NVARCHAR(20) NULL,
    telefon2 NVARCHAR(20) NULL,
    email NVARCHAR(100) NULL CHECK (email LIKE '%@%.%'),
    website NVARCHAR(150) NULL,
    unvan NVARCHAR(MAX) NULL,
    seher NVARCHAR(50) NULL,
    rayon NVARCHAR(50) NULL,
    kend NVARCHAR(50) NULL,
    poçt_kodu NVARCHAR(10) NULL,
    bank_hesab_nomresi NVARCHAR(50) NULL,
    bank_adi NVARCHAR(100) NULL,
    bank_kodu NVARCHAR(20) NULL,
    swift_kodu NVARCHAR(20) NULL,
    odenis_sertleri NVARCHAR(500) NULL,
    kredit_limiti DECIMAL(18,2) DEFAULT 0 NOT NULL,
    cari_borc DECIMAL(18,2) DEFAULT 0 NOT NULL,
    reytinq DECIMAL(3,2) DEFAULT 0 NOT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    qeyd NVARCHAR(500) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    deyisen_istifadeci_id INT NULL,
    CONSTRAINT CHK_reytinq CHECK (reytinq >= 0 AND reytinq <= 5),
    CONSTRAINT CHK_tedarukcu_kodu CHECK (LEN(kodu) >= 2)
);
GO

-- Məhsullar cədvəli
CREATE TABLE mehsullar (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(255) NOT NULL,
    kodu NVARCHAR(50) UNIQUE NULL,
    barkod NVARCHAR(50) UNIQUE NULL,
    qr_kodu NVARCHAR(255) NULL,
    kateqoriya_id INT NOT NULL,
    brend_id INT NULL,
    vahid_id INT NOT NULL,
    model NVARCHAR(100) NULL,
    renk NVARCHAR(50) NULL,
    olcu NVARCHAR(50) NULL,
    vezn DECIMAL(18,3) NULL,
    alis_qiymeti DECIMAL(18, 2) NOT NULL,
    satis_qiymeti DECIMAL(18, 2) NOT NULL,
    perakende_qiymeti DECIMAL(18, 2) NULL,
    topdan_qiymeti DECIMAL(18, 2) NULL,
    minimum_stok INT DEFAULT 0 NOT NULL,
    maksimum_stok INT NULL,
    cari_stok INT DEFAULT 0 NOT NULL,
    rezerv_stok INT DEFAULT 0 NOT NULL,
    kritik_stok_seviyyesi INT NULL,
    tedarukcu_id INT NULL,
    tedarukcu_kodu NVARCHAR(50) NULL,
    garantiya_muddeti INT NULL,
    istehsal_tarixi DATE NULL,
    son_istifade_tarixi DATE NULL,
    raf_yeri NVARCHAR(100) NULL,
    tesvir NVARCHAR(MAX) NULL,
    texniki_xususiyyetler NVARCHAR(MAX) NULL,
    sekil_yolu NVARCHAR(255) NULL,
    qalereya_yollari NVARCHAR(MAX) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    silinib BIT DEFAULT 0 NOT NULL,
    populyarliq_reytinqi INT DEFAULT 0 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    deyisen_istifadeci_id INT NULL,
    CONSTRAINT FK_mehsullar_kateqoriya FOREIGN KEY (kateqoriya_id) REFERENCES kateqoriyalar(id),
    CONSTRAINT FK_mehsullar_brend FOREIGN KEY (brend_id) REFERENCES brendler(id),
    CONSTRAINT FK_mehsullar_vahid FOREIGN KEY (vahid_id) REFERENCES vahidler(id),
    CONSTRAINT FK_mehsullar_tedarukcu FOREIGN KEY (tedarukcu_id) REFERENCES tedarukcüler(id),
    CONSTRAINT CHK_qiymet CHECK (satis_qiymeti >= alis_qiymeti),
    CONSTRAINT CHK_stok_seviyyesi CHECK (maksimum_stok IS NULL OR maksimum_stok >= minimum_stok),
    CONSTRAINT CHK_garantiya CHECK (garantiya_muddeti IS NULL OR garantiya_muddeti > 0),
    CONSTRAINT CHK_stok_deyerleri CHECK (cari_stok >= 0 AND rezerv_stok >= 0)
);
GO

-- Məhsul əlaqələri cədvəli
CREATE TABLE mehsul_elaqeleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    mehsul_id INT NOT NULL,
    elaqeli_mehsul_id INT NOT NULL,
    elaqe_novu NVARCHAR(50) NOT NULL CHECK (elaqe_novu IN ('Əlaqəli', 'Alternativ', 'Əlavə', 'Kombine', 'Eyni')),
    siralama INT DEFAULT 0 NOT NULL,
    tesvir NVARCHAR(255) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    CONSTRAINT FK_mehsul_elaqeleri_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id),
    CONSTRAINT FK_mehsul_elaqeleri_elaqeli_mehsul FOREIGN KEY (elaqeli_mehsul_id) REFERENCES mehsullar(id),
    CONSTRAINT CHK_ferqli_mehsul CHECK (mehsul_id != elaqeli_mehsul_id),
    CONSTRAINT UQ_mehsul_elaqesi UNIQUE (mehsul_id, elaqeli_mehsul_id, elaqe_novu)
);
GO

-- Anbar hərəkətləri cədvəli
CREATE TABLE anbar_hereketleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    mehsul_id INT NOT NULL,
    filial_id INT NULL,
    hereket_novu NVARCHAR(50) NOT NULL CHECK (hereket_novu IN ('Giriş', 'Çıxış', 'Qaytarma', 'Inventarizasiya', 'Transfer', 'İtki', 'Zərər', 'Digər')),
    alt_hereket_novu NVARCHAR(50) NULL,
    miqdar INT NOT NULL,
    vahid_qiymeti DECIMAL(18,2) NULL,
    yekun_qiymet DECIMAL(18,2) NULL,
    kohne_stok INT NOT NULL,
    yeni_stok INT NOT NULL,
    hereket_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    istifadeci_id INT NOT NULL,
    sened_nomresi NVARCHAR(50) NULL,
    sened_tipi NVARCHAR(50) NULL,
    raf_yeri NVARCHAR(100) NULL,
    parti_nomresi NVARCHAR(50) NULL,
    istehsal_tarixi DATE NULL,
    son_istifade_tarixi DATE NULL,
    qeyd NVARCHAR(MAX) NULL,
    ip_adresi NVARCHAR(45) NULL,
    CONSTRAINT FK_anbar_hereketleri_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id),
    CONSTRAINT FK_anbar_hereketleri_filial FOREIGN KEY (filial_id) REFERENCES filiallar(id),
    CONSTRAINT FK_anbar_hereketleri_istifadeci FOREIGN KEY (istifadeci_id) REFERENCES istifadeciler(id),
    CONSTRAINT CHK_miqdar CHECK (miqdar != 0),
    CONSTRAINT CHK_yeni_stok CHECK (yeni_stok >= 0)
);
GO

-- Anbar inventarizasiyası cədvəli
CREATE TABLE anbar_inventarizasiyasi (
    id INT PRIMARY KEY IDENTITY(1,1),
    inventarizasiya_kodu NVARCHAR(50) UNIQUE NOT NULL,
    baslama_tarixi DATETIME NOT NULL,
    bitme_tarixi DATETIME NULL,
    sorumlu_istifadeci_id INT NOT NULL,
    filial_id INT NULL,
    status NVARCHAR(50) NOT NULL CHECK (status IN ('Davam edir', 'Tamamlandı', 'Ləğv edildi')),
    tesvir NVARCHAR(255) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    CONSTRAINT FK_inventarizasiya_istifadeci FOREIGN KEY (sorumlu_istifadeci_id) REFERENCES istifadeciler(id),
    CONSTRAINT FK_inventarizasiya_filial FOREIGN KEY (filial_id) REFERENCES filiallar(id)
);
GO

-- Inventarizasiya detalları cədvəli
CREATE TABLE inventarizasiya_detallari (
    id INT PRIMARY KEY IDENTITY(1,1),
    inventarizasiya_id INT NOT NULL,
    mehsul_id INT NOT NULL,
    sistem_stoqu INT NOT NULL,
    fiziki_stok INT NOT NULL,
    ferq AS (fiziki_stok - sistem_stoqu),
    qeyd NVARCHAR(255) NULL,
    yoxlama_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    yoxlayan_istifadeci_id INT NOT NULL,
    CONSTRAINT FK_inventarizasiya_detallari_inventarizasiya FOREIGN KEY (inventarizasiya_id) REFERENCES anbar_inventarizasiyasi(id),
    CONSTRAINT FK_inventarizasiya_detallari_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id),
    CONSTRAINT FK_inventarizasiya_detallari_istifadeci FOREIGN KEY (yoxlayan_istifadeci_id) REFERENCES istifadeciler(id)
);
GO

-- ===============================================
-- 4. MÜŞTƏRİ VƏ SATIŞLAR MODULU
-- ===============================================

-- Müştəri kateqoriyaları cədvəli
CREATE TABLE musteri_kateqoriyalari (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) UNIQUE NOT NULL,
    endirim_faizi DECIMAL(5,2) DEFAULT 0 NOT NULL,
    minimum_nisye_bali INT DEFAULT 0 NOT NULL,
    maksimum_nisye_limiti DECIMAL(18,2) DEFAULT 0 NOT NULL,
    tesvir NVARCHAR(255) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    CONSTRAINT CHK_endirim_faizi CHECK (endirim_faizi >= 0 AND endirim_faizi <= 100)
);
GO

-- Müştərilər cədvəli
CREATE TABLE musteriler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) NOT NULL,
    soyad NVARCHAR(50) NOT NULL,
    ata_adi NVARCHAR(50) NULL,
    musteri_kodu AS ('MUS-' + RIGHT('000000' + CAST(id AS VARCHAR(6)), 6)) PERSISTED,
    kateqoriya_id INT NULL,
    telefon NVARCHAR(20) NOT NULL,
    telefon2 NVARCHAR(20) NULL,
    email NVARCHAR(100) NULL CHECK (email LIKE '%@%.%'),
    dogum_tarixi DATE NULL,
    cinsi NVARCHAR(10) NULL CHECK (cinsi IN ('Kişi', 'Qadın', 'Digər')),
    fin_kodu NVARCHAR(7) NULL,
    pasport_seriya NVARCHAR(20) NULL,
    unvan NVARCHAR(MAX) NULL,
    seher NVARCHAR(50) NULL,
    rayon NVARCHAR(50) NULL,
    kend NVARCHAR(50) NULL,
    poçt_kodu NVARCHAR(10) NULL,
    nisye_limiti DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    cari_nisye_borcu DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    endirim_faizi DECIMAL(5,2) DEFAULT 0 NOT NULL,
    sadakat_puani INT DEFAULT 0 NOT NULL,
    son_alis_tarixi DATETIME NULL,
    toplam_alis_meblegi DECIMAL(18,2) DEFAULT 0 NOT NULL,
    alis_sayi INT DEFAULT 0 NOT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    qeyd NVARCHAR(500) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    deyisen_istifadeci_id INT NULL,
    CONSTRAINT FK_musteriler_kateqoriya FOREIGN KEY (kateqoriya_id) REFERENCES musteri_kateqoriyalari(id),
    CONSTRAINT CHK_endirim_musteri CHECK (endirim_faizi >= 0 AND endirim_faizi <= 100),
    CONSTRAINT UQ_musteri_telefon UNIQUE (telefon)
);
GO

-- Müştəri ünvanları cədvəli
CREATE TABLE musteri_unvanlari (
    id INT PRIMARY KEY IDENTITY(1,1),
    musteri_id INT NOT NULL,
    unvan_novu NVARCHAR(50) NOT NULL CHECK (unvan_novu IN ('Ev', 'İş', 'Çatdırılma', 'Digər')),
    unvan_adi NVARCHAR(100) NULL,
    unvan NVARCHAR(MAX) NOT NULL,
    seher NVARCHAR(50) NULL,
    rayon NVARCHAR(50) NULL,
    kend NVARCHAR(50) NULL,
    poçt_kodu NVARCHAR(10) NULL,
    GPS_koordinatlari NVARCHAR(100) NULL,
    esas_unvan BIT DEFAULT 0 NOT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    CONSTRAINT FK_musteri_unvanlari_musteri FOREIGN KEY (musteri_id) REFERENCES musteriler(id),
    CONSTRAINT CHK_esas_unvan_tekliyi UNIQUE (musteri_id, esas_unvan) WHERE esas_unvan = 1
);
GO

-- Satışlar cədvəli
CREATE TABLE satislar (
    id INT PRIMARY KEY IDENTITY(1,1),
    satis_kodu AS ('SAT-' + RIGHT('000000' + CAST(id AS VARCHAR(6)), 6)) PERSISTED,
    filial_id INT NULL,
    satis_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    musteri_id INT NULL,
    istifadeci_id INT NOT NULL,
    kassa_nomresi NVARCHAR(20) NULL,
    mehsul_sayi INT DEFAULT 0 NOT NULL,
    ara_yekun DECIMAL(18, 2) NOT NULL,
    vergi_meblegi DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    vergi_faizi DECIMAL(5, 2) DEFAULT 0 NOT NULL,
    endirim_meblegi DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    endirim_faizi DECIMAL(5, 2) DEFAULT 0 NOT NULL,
    yekun_mebleg DECIMAL(18, 2) NOT NULL,
    odenmis_mebleg DECIMAL(18, 2) NOT NULL,
    qaliq_mebleg AS (yekun_mebleg - odenmis_mebleg) PERSISTED,
    para_ustu DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    sadakat_puani INT DEFAULT 0 NOT NULL,
    istifade_puani INT DEFAULT 0 NOT NULL,
    satis_novu NVARCHAR(50) DEFAULT 'Satış' NOT NULL CHECK (satis_novu IN ('Satış', 'Qaytarma', 'Mübadilə', 'Sifariş')),
    status NVARCHAR(50) DEFAULT 'Tamamlandı' NOT NULL CHECK (status IN ('Gözləyən', 'Tamamlandı', 'Ləğv edildi', 'Qaytarıldı', 'Yarımçıq')),
    qaytarilib BIT DEFAULT 0 NOT NULL,
    qaytarma_tarixi DATETIME NULL,
    qaytarma_sebebi NVARCHAR(255) NULL,
    legv_tarixi DATETIME NULL,
    legv_eden_istifadeci_id INT NULL,
    legv_sebebi NVARCHAR(255) NULL,
    qeyd NVARCHAR(MAX) NULL,
    cek_nomresi NVARCHAR(50) NULL,
    fiskal_kod NVARCHAR(100) NULL,
    ip_adresi NVARCHAR(45) NULL,
    CONSTRAINT FK_satislar_filial FOREIGN KEY (filial_id) REFERENCES filiallar(id),
    CONSTRAINT FK_satislar_musteri FOREIGN KEY (musteri_id) REFERENCES musteriler(id),
    CONSTRAINT FK_satislar_istifadeci FOREIGN KEY (istifadeci_id) REFERENCES istifadeciler(id),
    CONSTRAINT FK_satislar_legv_eden FOREIGN KEY (legv_eden_istifadeci_id) REFERENCES istifadeciler(id),
    CONSTRAINT CHK_odenis CHECK (odenmis_mebleg >= 0 AND yekun_mebleg >= odenmis_mebleg),
    CONSTRAINT CHK_vergi_faizi CHECK (vergi_faizi >= 0 AND vergi_faizi <= 100),
    CONSTRAINT CHK_endirim_faizi CHECK (endirim_faizi >= 0 AND endirim_faizi <= 100)
);
GO

-- Satış məhsulları cədvəli
CREATE TABLE satis_mehsullari (
    id INT PRIMARY KEY IDENTITY(1,1),
    satis_id INT NOT NULL,
    mehsul_id INT NOT NULL,
    mehsul_kodu NVARCHAR(50) NULL,
    mehsul_adi NVARCHAR(255) NOT NULL,
    miqdar INT NOT NULL,
    vahid_adi NVARCHAR(50) NOT NULL,
    alis_qiymeti DECIMAL(18, 2) NOT NULL,
    qiymet_bir_edede DECIMAL(18, 2) NOT NULL,
    endirim_faizi DECIMAL(5, 2) DEFAULT 0 NOT NULL,
    endirim_meblegi DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    vergi_faizi DECIMAL(5, 2) DEFAULT 0 NOT NULL,
    vergi_meblegi DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    yekun_satish_qiymeti AS (miqdar * qiymet_bir_edede - endirim_meblegi + vergi_meblegi) PERSISTED,
    menfeet AS (yekun_satish_qiymeti - (miqdar * alis_qiymeti)) PERSISTED,
    parti_nomresi NVARCHAR(50) NULL,
    seriya_nomresi NVARCHAR(50) NULL,
    garantiya_muddeti INT NULL,
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT FK_satis_mehsullari_satis FOREIGN KEY (satis_id) REFERENCES satislar(id) ON DELETE CASCADE,
    CONSTRAINT FK_satis_mehsullari_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id),
    CONSTRAINT CHK_satis_miqdar CHECK (miqdar > 0),
    CONSTRAINT CHK_satis_endirim CHECK (endirim_faizi >= 0 AND endirim_faizi <= 100)
);
GO

-- Ödəniş növləri cədvəli
CREATE TABLE odenis_novleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) UNIQUE NOT NULL,
    kodu NVARCHAR(10) UNIQUE NOT NULL,
    tip NVARCHAR(50) NOT NULL CHECK (tip IN ('Nağd', 'Kartla', 'Bankda', 'Elektron', 'Nisyə', 'Puan', 'Digər')),
    komissiya_faizi DECIMAL(5, 2) DEFAULT 0 NOT NULL,
    minimum_mebleg DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    maksimum_mebleg DECIMAL(18, 2) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    siralama INT DEFAULT 0 NOT NULL,
    renk_kodu NVARCHAR(7) NULL CHECK (renk_kodu LIKE '#%' AND LEN(renk_kodu) = 7),
    tesvir NVARCHAR(255) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    CONSTRAINT CHK_komissiya CHECK (komissiya_faizi >= 0 AND komissiya_faizi <= 100)
);
GO

-- Ödənişlər cədvəli
CREATE TABLE odenisler (
    id INT PRIMARY KEY IDENTITY(1,1),
    satis_id INT NOT NULL,
    odenis_nov_id INT NOT NULL,
    odenis_meblegi DECIMAL(18, 2) NOT NULL,
    komissiya_meblegi DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    odenis_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    kart_novu NVARCHAR(50) NULL CHECK (kart_novu IN ('Visa', 'MasterCard', 'American Express', 'Digər')),
    kart_son_dord_reqem NVARCHAR(4) NULL,
    kart_sahibi_adi NVARCHAR(100) NULL,
    bank_adi NVARCHAR(100) NULL,
    terminal_id NVARCHAR(50) NULL,
    autorization_kodu NVARCHAR(50) NULL,
    referans_nomresi NVARCHAR(100) NULL,
    cek_nomresi NVARCHAR(50) NULL,
    status NVARCHAR(50) DEFAULT 'Uğurlu' NOT NULL CHECK (status IN ('Uğurlu', 'Gözləyən', 'Uğursuz', 'Ləğv edildi')),
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT FK_odenisler_satis FOREIGN KEY (satis_id) REFERENCES satislar(id) ON DELETE CASCADE,
    CONSTRAINT FK_odenisler_odenis_novleri FOREIGN KEY (odenis_nov_id) REFERENCES odenis_novleri(id),
    CONSTRAINT CHK_odenis_mebleg CHECK (odenis_meblegi > 0)
);
GO

-- ===============================================
-- 5. TƏMİR XİDMƏTLƏRİ MODULU
-- ===============================================

-- Təmir statusları cədvəli
CREATE TABLE temir_statuslari (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) UNIQUE NOT NULL,
    kodu NVARCHAR(10) UNIQUE NOT NULL,
    tesvir NVARCHAR(255) NULL,
    renk_kodu NVARCHAR(7) NULL CHECK (renk_kodu LIKE '#%' AND LEN(renk_kodu) = 7),
    siralama INT NOT NULL DEFAULT 0,
    icon_adi NVARCHAR(50) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    son_status BIT DEFAULT 0 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL
);
GO

-- Təmir növləri cədvəli
CREATE TABLE temir_novleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) UNIQUE NOT NULL,
    kodu NVARCHAR(20) UNIQUE NOT NULL,
    tesvir NVARCHAR(255) NULL,
    ortalama_muddet INT NULL,
    esas_xerc DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL
);
GO

-- Təmirlər cədvəli
CREATE TABLE temirler (
    id INT PRIMARY KEY IDENTITY(1,1),
    temir_kodu AS ('TMR-' + RIGHT('000000' + CAST(id AS VARCHAR(6)), 6)) PERSISTED,
    filial_id INT NULL,
    musteri_id INT NOT NULL,
    temir_nov_id INT NULL,
    cihaz_adi NVARCHAR(100) NOT NULL,
    cihaz_novu NVARCHAR(100) NULL,
    marka NVARCHAR(50) NULL,
    model NVARCHAR(50) NULL,
    seriya_nomresi NVARCHAR(100) NULL,
    rengi NVARCHAR(50) NULL,
    istehsal_ili INT NULL,
    garantiya_statusu NVARCHAR(50) NULL CHECK (garantiya_statusu IN ('Garantiyada', 'Garantiyadan çıxmış', 'Naməlum')),
    problem_tesviri NVARCHAR(MAX) NOT NULL,
    diaqnostika_neticesi NVARCHAR(MAX) NULL,
    qebul_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    texminen_tamamlama_tarixi DATETIME NULL,
    faktiki_tamamlama_tarixi DATETIME NULL,
    teslim_tarixi DATETIME NULL,
    status_id INT NOT NULL,
    temirci_id INT NULL,
    texminen_baxim_xerci DECIMAL(18,2) NULL,
    yekun_baxim_xerci DECIMAL(18,2) NULL,
    mexaric_qeyd_eden_istifadeci_id INT NULL,
    qeydler NVARCHAR(MAX) NULL,
    CONSTRAINT FK_temirler_filial FOREIGN KEY (filial_id) REFERENCES filiallar(id),
    CONSTRAINT FK_temirler_musteri FOREIGN KEY (musteri_id) REFERENCES musteriler(id),
    CONSTRAINT FK_temirler_temir_nov FOREIGN KEY (temir_nov_id) REFERENCES temir_novleri(id),
    CONSTRAINT FK_temirler_status FOREIGN KEY (status_id) REFERENCES temir_statuslari(id),
    CONSTRAINT FK_temirler_temirci FOREIGN KEY (temirci_id) REFERENCES istifadeciler(id),
    CONSTRAINT FK_temirler_mexaric_istifadeci FOREIGN KEY (mexaric_qeyd_eden_istifadeci_id) REFERENCES istifadeciler(id),
    CONSTRAINT CHK_tarixler CHECK (texminen_tamamlama_tarixi >= qebul_tarixi)
);
GO

-- Təmir hissələri cədvəli
CREATE TABLE temir_hisseleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    temir_id INT NOT NULL,
    mehsul_id INT NOT NULL,
    miqdar INT NOT NULL,
    qiymet_bir_edede DECIMAL(18, 2) NOT NULL,
    total_qiymet AS (miqdar * qiymet_bir_edede) PERSISTED,
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT FK_temir_hisseleri_temir FOREIGN KEY (temir_id) REFERENCES temirler(id) ON DELETE CASCADE,
    CONSTRAINT FK_temir_hisseleri_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id),
    CONSTRAINT CHK_temir_miqdar CHECK (miqdar > 0)
);
GO

-- Təmir işləri cədvəli
CREATE TABLE temir_isleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    temir_id INT NOT NULL,
    is_adi NVARCHAR(100) NOT NULL,
    is_tesviri NVARCHAR(MAX) NULL,
    baslama_tarixi DATETIME NULL,
    bitme_tarixi DATETIME NULL,
    status NVARCHAR(50) NOT NULL CHECK (status IN ('Gözləyir', 'Davam edir', 'Tamamlandı', 'Ləğv edildi')),
    xerc DECIMAL(18,2) DEFAULT 0 NOT NULL,
    temirci_id INT NULL,
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT FK_temir_isleri_temir FOREIGN KEY (temir_id) REFERENCES temirler(id) ON DELETE CASCADE,
    CONSTRAINT FK_temir_isleri_temirci FOREIGN KEY (temirci_id) REFERENCES istifadeciler(id)
);
GO

-- ===============================================
-- 6. NİSYƏ VƏ BORC İDARƏÇİLİYİ
-- ===============================================

-- Nisyə borcları cədvəli
CREATE TABLE nisye_borclar (
    id INT PRIMARY KEY IDENTITY(1,1),
    musteri_id INT NOT NULL,
    satish_id INT NULL,
    borc_meblegi DECIMAL(18, 2) NOT NULL,
    faiz_derecesi DECIMAL(5,2) DEFAULT 0 NOT NULL,
    toplam_borc_meblegi DECIMAL(18,2) NOT NULL,
    odenmis_mebleg DECIMAL(18,2) DEFAULT 0 NOT NULL,
    qaliq_borc AS (toplam_borc_meblegi - odenmis_mebleg) PERSISTED,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    odeme_baslama_tarixi DATE NOT NULL,
    odeme_bitme_tarixi DATE NOT NULL,
    status NVARCHAR(50) NOT NULL CHECK (status IN ('Aktiv', 'Tam ödənmiş', 'Gecikmiş', 'Ləğv edilmiş')),
    qeyd NVARCHAR(500) NULL,
    CONSTRAINT FK_nisye_borclar_musteri FOREIGN KEY (musteri_id) REFERENCES musteriler(id),
    CONSTRAINT FK_nisye_borclar_satis FOREIGN KEY (satish_id) REFERENCES satislar(id),
    CONSTRAINT CHK_borc_tarix CHECK (odeme_bitme_tarixi > odeme_baslama_tarixi)
);
GO

-- Ödəniş cədvəli cədvəli
CREATE TABLE odenis_cedveli (
    id INT PRIMARY KEY IDENTITY(1,1),
    nisye_id INT NOT NULL,
    odenecek_mebleg DECIMAL(18,2) NOT NULL,
    planlanan_tarix DATE NOT NULL,
    odenis_tarixi DATETIME NULL,
    odenis_usulu NVARCHAR(50) NULL,
    odenmis_miqdar DECIMAL(18,2) DEFAULT 0 NOT NULL,
    status NVARCHAR(50) NOT NULL CHECK (status IN ('Gözlənilir', 'Ödəndi', 'Gecikdi', 'Ləğv edildi')),
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT FK_odenis_cedveli_nisye FOREIGN KEY (nisye_id) REFERENCES nisye_borclar(id) ON DELETE CASCADE,
    CONSTRAINT CHK_odenis_miqdar CHECK (odenmis_miqdar >= 0)
);
GO

-- ===============================================
-- 7. XİDMƏTLƏR VƏ DİGƏR MODULLAR
-- ===============================================

-- Xidmətlər cədvəli
CREATE TABLE xidmetler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) NOT NULL,
    kodu NVARCHAR(20) UNIQUE NOT NULL,
    qiymet DECIMAL(18, 2) NOT NULL,
    ortalama_vaxt INT NULL,
    tesvir NVARCHAR(MAX) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL
);
GO

-- Kampaniyalar cədvəli
CREATE TABLE kampaniyalar (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) NOT NULL,
    kodu NVARCHAR(20) UNIQUE NOT NULL,
    baslama_tarixi DATETIME NOT NULL,
    bitme_tarixi DATETIME NOT NULL,
    endirim_faizi DECIMAL(5,2) NULL,
    endirim_meblegi DECIMAL(18,2) NULL,
    minimum_sebet DECIMAL(18,2) NULL,
    maksimum_endirim DECIMAL(18,2) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    tesvir NVARCHAR(MAX) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    CONSTRAINT CHK_kampaniya_tarix CHECK (bitme_tarixi > baslama_tarixi),
    CONSTRAINT CHK_kampaniya_endirim CHECK (
        (endirim_faizi IS NOT NULL AND endirim_meblegi IS NULL) OR 
        (endirim_faizi IS NULL AND endirim_meblegi IS NOT NULL)
    )
);
GO

-- Kampaniya məhsulları cədvəli
CREATE TABLE kampaniya_mehsullari (
    id INT PRIMARY KEY IDENTITY(1,1),
    kampaniya_id INT NOT NULL,
    mehsul_id INT NULL,
    kateqoriya_id INT NULL,
    endirim_faizi DECIMAL(5,2) NULL,
    endirim_meblegi DECIMAL(18,2) NULL,
    maksimum_endirim DECIMAL(18,2) NULL,
    CONSTRAINT FK_kampaniya_mehsullari_kampaniya FOREIGN KEY (kampaniya_id) REFERENCES kampaniyalar(id) ON DELETE CASCADE,
    CONSTRAINT FK_kampaniya_mehsullari_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id),
    CONSTRAINT FK_kampaniya_mehsullari_kateqoriya FOREIGN KEY (kateqoriya_id) REFERENCES kateqoriyalar(id),
    CONSTRAINT CHK_kampaniya_mehsul_endirim CHECK (
        (endirim_faizi IS NOT NULL AND endirim_meblegi IS NULL) OR 
        (endirim_faizi IS NULL AND endirim_meblegi IS NOT NULL)
    ),
    CONSTRAINT CHK_kampaniya_mehsul_obyekt CHECK (
        (mehsul_id IS NOT NULL AND kateqoriya_id IS NULL) OR 
        (mehsul_id IS NULL AND kateqoriya_id IS NOT NULL)
    )
);
GO

-- ===============================================
-- 8. İNDEKS VƏ PERFORMANS OPTİMALLAŞDIRMALARI
-- ===============================================

-- Optimallaşdırılmış indekslər
CREATE INDEX IX_mehsullar_barkod ON mehsullar(barkod) WHERE barkod IS NOT NULL;
CREATE INDEX IX_mehsullar_kateqoriya ON mehsullar(kateqoriya_id);
CREATE INDEX IX_mehsullar_tedarukcu ON mehsullar(tedarukcu_id) WHERE tedarukcu_id IS NOT NULL;
CREATE INDEX IX_mehsullar_stok ON mehsullar(cari_stok) WHERE aktivdir = 1 AND silinib = 0;

CREATE INDEX IX_satislar_tarix ON satislar(satis_tarixi);
CREATE INDEX IX_satislar_musteri ON satislar(musteri_id) WHERE musteri_id IS NOT NULL;
CREATE INDEX IX_satislar_status ON satislar(status);
CREATE INDEX IX_satislar_filial ON satislar(filial_id) WHERE filial_id IS NOT NULL;

CREATE INDEX IX_temirler_status ON temirler(status_id);
CREATE INDEX IX_temirler_musteri ON temirler(musteri_id);
CREATE INDEX IX_temirler_temirci ON temirler(temirci_id) WHERE temirci_id IS NOT NULL;
CREATE INDEX IX_temirler_tarix ON temirler(qebul_tarixi);

CREATE INDEX IX_anbar_hereketleri_mehsul ON anbar_hereketleri(mehsul_id);
CREATE INDEX IX_anbar_hereketleri_tarix ON anbar_hereketleri(hereket_tarixi);
CREATE INDEX IX_anbar_hereketleri_nov ON anbar_hereketleri(hereket_novu);

CREATE INDEX IX_musteriler_kateqoriya ON musteriler(kateqoriya_id) WHERE kateqoriya_id IS NOT NULL;
CREATE INDEX IX_musteriler_telefon ON musteriler(telefon);
CREATE INDEX IX_musteriler_aktiv ON musteriler(aktivdir) WHERE aktivdir = 1;

CREATE INDEX IX_istifadeciler_rol ON istifadeciler(rol_id);
CREATE INDEX IX_istifadeciler_filial ON istifadeciler(filial_id) WHERE filial_id IS NOT NULL;
CREATE INDEX IX_istifadeciler_aktiv ON istifadeciler(aktivdir) WHERE aktivdir = 1;
GO

-- ===============================================
-- 9. TRİGGERLƏR VƏ PROSEDURLAR
-- ===============================================

-- Stok avtomatik yeniləmə üçün trigger
CREATE TRIGGER TR_anbar_hereketleri_stok
ON anbar_hereketleri
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE m
    SET m.cari_stok = 
        CASE WHEN i.hereket_novu IN ('Giriş', 'Qaytarma') THEN m.cari_stok + i.miqdar
             WHEN i.hereket_novu IN ('Çıxış', 'İtki', 'Zərər') THEN m.cari_stok - i.miqdar
             ELSE m.cari_stok
        END,
        m.son_deyisiklik = GETDATE()
    FROM mehsullar m
    INNER JOIN inserted i ON m.id = i.mehsul_id;
    
    -- Əməliyyat jurnalına qeyd
    INSERT INTO emeliyyat_jurnali (istifadeci_id, emeliyyat_novu, emeliyyat_obyekti, obyekt_id, tesvir)
    SELECT i.istifadeci_id, 'Stok yeniləndi', 'Məhsul', i.mehsul_id, 
           'Hərəkət növü: ' + i.hereket_novu + ', Miqdar: ' + CAST(i.miqdar AS NVARCHAR(10))
    FROM inserted i;
END;
GO

-- Satış silindikdə ödənişlərin silinməsi üçün trigger
CREATE TRIGGER TR_satislar_silinende
ON satislar
AFTER DELETE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Əməliyyat jurnalına qeyd
    INSERT INTO emeliyyat_jurnali (istifadeci_id, emeliyyat_novu, emeliyyat_obyekti, obyekt_id, tesvir)
    SELECT d.legv_eden_istifadeci_id, 'Satış ləğv edildi', 'Satış', d.id, 
           'Yekun məbləğ: ' + CAST(d.yekun_mebleg AS NVARCHAR(50)) + ', Müştəri: ' + ISNULL(CAST(d.musteri_id AS NVARCHAR(10)), 'Yoxdur')
    FROM deleted d;
END;
GO

-- Müştəri balansını yeniləyən trigger
CREATE TRIGGER TR_satislar_musteri_balans
ON satislar
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    
    -- Yalnız tamamlanmış satışlar üçün
    UPDATE m
    SET 
        m.son_alis_tarixi = i.satis_tarixi,
        m.toplam_alis_meblegi = m.toplam_alis_meblegi + i.yekun_mebleg,
        m.alis_sayi = m.alis_sayi + 1,
        m.sadakat_puani = m.sadakat_puani + i.sadakat_puani
    FROM musteriler m
    INNER JOIN inserted i ON m.id = i.musteri_id
    WHERE i.status = 'Tamamlandı' AND i.musteri_id IS NOT NULL;
END;
GO

-- ===============================================
-- 10. VIEW-LAR VƏ FUNKSİYALAR
-- ===============================================

-- Aktiv məhsullar üçün view
CREATE VIEW vw_aktiv_mehsullar AS
SELECT 
    m.id, m.ad, m.kodu, m.barkod, m.kateqoriya_id, k.ad AS kateqoriya,
    m.brend_id, b.ad AS brend, m.vahid_id, v.ad AS vahid, v.qisaltma AS vahid_qisaltma,
    m.alis_qiymeti, m.satis_qiymeti, m.perakende_qiymeti, m.topdan_qiymeti,
    m.minimum_stok, m.maksimum_stok, m.cari_stok, m.rezerv_stok, m.kritik_stok_seviyyesi,
    m.tedarukcu_id, t.ad AS tedarukcu, m.tedarukcu_kodu,
    m.garantiya_muddeti, m.istehsal_tarixi, m.son_istifade_tarixi, m.raf_yeri,
    m.populyarliq_reytinqi, m.yaradilma_tarixi
FROM mehsullar m
JOIN kateqoriyalar k ON m.kateqoriya_id = k.id
JOIN vahidler v ON m.vahid_id = v.id
LEFT JOIN brendler b ON m.brend_id = b.id
LEFT JOIN tedarukcüler t ON m.tedarukcu_id = t.id
WHERE m.aktivdir = 1 AND m.silinib = 0;
GO

-- Stok xəbərdarlığı üçün view
CREATE VIEW vw_stok_xəbərdarlığı AS
SELECT 
    m.id, m.ad, m.kodu, m.cari_stok, m.minimum_stok, m.kritik_stok_seviyyesi,
    k.ad AS kateqoriya, b.ad AS brend,
    CASE 
        WHEN m.cari_stok <= 0 THEN 'Bitib'
        WHEN m.kritik_stok_seviyyesi IS NOT NULL AND m.cari_stok <= m.kritik_stok_seviyyesi THEN 'Kritik'
        WHEN m.cari_stok <= m.minimum_stok THEN 'Minimum'
        ELSE 'Normal'
    END AS stok_durumu
FROM mehsullar m
JOIN kateqoriyalar k ON m.kateqoriya_id = k.id
LEFT JOIN brendler b ON m.brend_id = b.id
WHERE m.aktivdir = 1 AND m.silinib = 0 AND 
      (m.cari_stok <= m.minimum_stok OR 
       (m.kritik_stok_seviyyesi IS NOT NULL AND m.cari_stok <= m.kritik_stok_seviyyesi));
GO

-- Satış hesabatı üçün view
CREATE VIEW vw_gunluk_satis_hesabati AS
SELECT 
    CAST(s.satis_tarixi AS DATE) AS satis_tarixi,
    f.ad AS filial,
    COUNT(*) AS satis_sayi,
    SUM(s.yekun_mebleg) AS toplam_mebleg,
    SUM(s.endirim_meblegi) AS toplam_endirim,
    SUM(s.vergi_meblegi) AS toplam_vergi,
    SUM(s.odenmis_mebleg) AS toplam_odenis,
    SUM(s.qaliq_mebleg) AS toplam_qaliq,
    COUNT(DISTINCT s.musteri_id) AS musteri_sayi
FROM satislar s
LEFT JOIN filiallar f ON s.filial_id = f.id
WHERE s.status = 'Tamamlandı'
GROUP BY CAST(s.satis_tarixi AS DATE), f.ad;
GO

-- ===============================================
-- 11. İLKİN MƏLUMATLARIN DOLDURULMASI
-- ===============================================

-- Sistem konfiqurasiyası
INSERT INTO sistem_konfiqurasiyasi (acar, deyer, tip, tesvir, varsayilan_deyer, modul)
VALUES 
('SISTEM_ADI', 'AzAgroPOS', 'STRING', 'Sistemin adı', 'AzAgroPOS', 'GENEL'),
('SISTEM_VERSIYA', '2.5', 'STRING', 'Sistem versiyası', '2.5', 'GENEL'),
('MAX_LOGIN_CEHDI', '5', 'INTEGER', 'Maksimum giriş cəhdi', '5', 'GENEL'),
('PAROL_MUDDETI', '90', 'INTEGER', 'Parolun etibarlılıq müddəti (gün)', '90', 'GENEL'),
('VERGI_FAIZI', '18', 'DECIMAL', 'Standart vergi faizi', '18', 'SATIS'),
('DEFAULT_ENDIRIM_FAIZI', '0', 'DECIMAL', 'Standart endirim faizi', '0', 'SATIS'),
('STOK_XEBERDARLIGI', '1', 'BOOLEAN', 'Stok xəbərdarlığı aktivdir', '1', 'STOK');
GO

-- Şirkət məlumatları
INSERT INTO sirket_melumatlari (sirket_adi, vergi_nomresi, unvan, telefon, email, website)
VALUES 
('AzAgro MMC', '123456789', 'Bakı şəhəri, Nəsimi rayonu, Əhməd Rəcəbli küçəsi 15', '+994124567890', 'info@azagro.az', 'www.azagro.az');
GO

-- Filiallar
INSERT INTO filiallar (ad, kodu, unvan, telefon, acilis_tarixi)
VALUES 
('Baş Ofis', 'MAIN', 'Bakı şəhəri, Nəsimi rayonu, Əhməd Rəcəbli küçəsi 15', '+994124567890', '2020-01-01'),
('Gəncə Filialı', 'GANJA', 'Gəncə şəhəri, Nizami küçəsi 25', '+994222345678', '2021-05-15');
GO

-- Rollar
INSERT INTO rollar (ad, tesvir, seviyye, sistem_rolu)
VALUES 
('Super Admin', 'Tam çıxış hüquqları', 5, 1),
('Admin', 'İnzibati hüquqlar', 4, 0),
('Satış meneceri', 'Satış və müştəri idarəçiliyi', 3, 0),
('Anbar meneceri', 'Stok idarəçiliyi', 3, 0),
('Kassir', 'Satış və qaytarma əməliyyatları', 2, 0),
('Təmirçi', 'Təmir proseslərinin idarə edilməsi', 2, 0);
GO

-- İstifadəçilər (parol: Admin123)
INSERT INTO istifadeciler (ad, soyad, istifadeci_adi, parol_hash, parol_salt, rol_id, filial_id, telefon, email)
VALUES 
('Sistem', 'Admini', 'admin', 
 '8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', 
 'B1A5CF3BCC9A8A9C6D4D4E2F3B8C1D5E', 
 1, 1, '+994501234567', 'admin@azagro.az'),
('Mehriban', 'Əliyeva', 'mehriban', 
 '8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918', 
 'B1A5CF3BCC9A8A9C6D4D4E2F3B8C1D5E', 
 3, 1, '+994552345678', 'mehriban@azagro.az');
GO

-- Kateqoriyalar
INSERT INTO kateqoriyalar (ad, kodu, tesvir)
VALUES 
('Traktor Ehtiyat Hissələri', 'TRK', 'Traktorlar üçün ehtiyat hissələri'),
('Suluq Avadanlıqları', 'SLQ', 'Sulama sistemləri üçün avadanlıqlar'),
('Əkin Alətləri', 'EKN', 'Torpaq işləmə alətləri'),
('Gübrələr', 'GBR', 'Kənd təsərrüfatı üçün gübrələr'),
('Toxumlar', 'TXM', 'Müxtəlif bitki toxumları');
GO

-- Vahidlər
INSERT INTO vahidler (ad, qisaltma, tip)
VALUES 
('Ədəd', 'əd.', 'Ədəd'),
('Kiloqram', 'kq', 'Çəki'),
('Litr', 'lt', 'Həcm'),
('Metr', 'm', 'Uzunluq'),
('Dəst', 'dəst', 'Ədəd');
GO

-- Brendlər
INSERT INTO brendler (ad, kodu, website)
VALUES 
('AgroTech', 'AGT', 'www.agrotech.com'),
('FarmPro', 'FRP', 'www.farmpro.com'),
('GreenField', 'GRF', 'www.greenfield.ag'),
('TurboTractor', 'TTR', 'www.turbotractor.com');
GO

-- Tədarükçülər
INSERT INTO tedarukcüler (ad, kodu, vergi_nomresi, telefon, email)
VALUES 
('AgroTech MMC', 'AGT', '123456789', '+994501234567', 'info@agrotech.az'),
('GreenFarm MMC', 'GRF', '987654321', '+994552345678', 'info@greenfarm.az');
GO

-- Məhsullar
INSERT INTO mehsullar (ad, kateqoriya_id, vahid_id, brend_id, alis_qiymeti, satis_qiymeti, minimum_stok, cari_stok)
VALUES 
('Traktor üçün yağ filtri', 1, 1, 4, 15.00, 25.00, 10, 50),
('Drip sulama sistemi', 2, 3, 1, 120.00, 180.00, 5, 20),
('Əkin aləti - kotan', 3, 1, 2, 250.00, 350.00, 3, 8),
('Azotlu gübrə', 4, 2, NULL, 1.20, 1.80, 100, 500),
('Buğda toxumu', 5, 2, 3, 0.80, 1.20, 200, 1000);
GO

-- Müştəri kateqoriyaları
INSERT INTO musteri_kateqoriyalari (ad, endirim_faizi, minimum_nisye_bali)
VALUES 
('Standart', 0.00, 0),
('Gümüş', 5.00, 1000),
('Qızıl', 10.00, 5000),
('Platin', 15.00, 15000);
GO

-- Müştərilər
INSERT INTO musteriler (ad, soyad, kateqoriya_id, telefon, email, nisye_limiti)
VALUES 
('Əli', 'Hüseynov', 1, '+994552345678', 'eli@mail.com', 500.00),
('Gülşən', 'Məmmədova', 2, '+994503456789', 'gulshan@mail.com', 1000.00),
('Kənd Təsərrüfatı MMC', 'N/A', 3, '+994124567890', 'info@ktm.az', 5000.00);
GO

-- Ödəniş növləri
INSERT INTO odenis_novleri (ad, kodu, tip, komissiya_faizi)
VALUES 
('Nağd', 'CASH', 'Nağd', 0.00),
('Kartla', 'CARD', 'Kartla', 1.50),
('Bank köçürməsi', 'BANK', 'Bankda', 0.50),
('Nisyə', 'CRED', 'Nisyə', 0.00);
GO

-- Təmir statusları
INSERT INTO temir_statuslari (ad, kodu, renk_kodu, siralama, son_status)
VALUES 
('Qəbul edildi', 'NEW', '#3498db', 1, 0),
('Diaqnostikada', 'DIAG', '#f39c12', 2, 0),
('Təmirdə', 'REP', '#e74c3c', 3, 0),
('Ehtiyat hissə gözləyir', 'PART', '#9b59b6', 4, 0),
('Təmir olunub', 'DONE', '#2ecc71', 5, 0),
('Təhvil verildi', 'DEL', '#27ae60', 6, 1);
GO

-- Təmir növləri
INSERT INTO temir_novleri (ad, kodu, ortalama_muddet, esas_xerc)
VALUES 
('Kiçik təmir', 'MINOR', 2, 20.00),
('Orta təmir', 'MED', 5, 50.00),
('Böyük təmir', 'MAJOR', 10, 100.00),
('Texniki baxış', 'SERV', 1, 15.00);
GO

PRINT 'AzAgroPOS verilənlər bazası uğurla quruldu və ilkin məlumatlarla dolduruldu';
GO