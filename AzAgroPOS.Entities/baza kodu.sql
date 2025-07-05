-- Verilənlər bazası yaradılması (əgər yoxdursa)
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'AzAgroPOS_DB')
BEGIN
    CREATE DATABASE AzAgroPOS_DB;
END
GO

USE AzAgroPOS_DB;
GO

-- Verilənlər bazası səviyyəsində optimallaşdırma parametrləri
ALTER DATABASE AzAgroPOS_DB SET RECOVERY SIMPLE;
ALTER DATABASE AzAgroPOS_DB SET AUTO_UPDATE_STATISTICS ON;
GO


CREATE TABLE rollar (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) UNIQUE NOT NULL,
    tesvir NVARCHAR(255) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL
);

CREATE TABLE istifadeciler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) NOT NULL,
    soyad NVARCHAR(50) NOT NULL,
    istifadeci_adi NVARCHAR(50) UNIQUE NOT NULL,
    parol_hash NVARCHAR(512) NOT NULL,
    parol_salt NVARCHAR(128) NOT NULL,
    rol_id INT NOT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    son_giris_tarixi DATETIME NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    deaktivasiya_tarixi DATETIME NULL,
    CONSTRAINT CHK_istifadeci_adi CHECK (LEN(istifadeci_adi) >= 4)
);

CREATE TABLE emeliyyat_jurnali (
    id INT PRIMARY KEY IDENTITY(1,1),
    istifadeci_id INT NOT NULL,
    emeliyyat_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    emeliyyat_novu NVARCHAR(100) NOT NULL,
    emeliyyat_obyekti NVARCHAR(100) NULL,
    obyekt_id INT NULL,
    tesvir NVARCHAR(MAX) NULL,
    ip_adresi NVARCHAR(45) NULL
);

CREATE TABLE kateqoriyalar (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) UNIQUE NOT NULL,
    tesvir NVARCHAR(255) NULL,
    ana_kateqoriya_id INT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL
);

CREATE TABLE vahidler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) UNIQUE NOT NULL,
    qisaltma NVARCHAR(10) NULL
);

CREATE TABLE tedarukcüler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) NOT NULL,
    vergi_nomresi NVARCHAR(20) NULL,
    elaqe_shexsi NVARCHAR(100) NULL,
    telefon NVARCHAR(20) NULL,
    unvan NVARCHAR(255) NULL,
    email NVARCHAR(100) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    qeyd NVARCHAR(500) NULL
);

CREATE TABLE mehsullar (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(255) NOT NULL,
    barkod NVARCHAR(50) UNIQUE NULL,
    kateqoriya_id INT NOT NULL,
    vahid_id INT NOT NULL,
    alis_qiymeti DECIMAL(18, 2) NOT NULL,
    satis_qiymeti DECIMAL(18, 2) NOT NULL,
    minimum_stok INT DEFAULT 0 NOT NULL,
    cari_stok INT DEFAULT 0 NOT NULL,
    kritik_stok_seviyyesi INT NULL,
    tedarukcu_id INT NULL,
    tesvir NVARCHAR(MAX) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    silinib BIT DEFAULT 0 NOT NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    son_deyisiklik DATETIME NULL,
    CONSTRAINT CHK_qiymet CHECK (satis_qiymeti >= alis_qiymeti)
);

CREATE TABLE anbar_hereketleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    mehsul_id INT NOT NULL,
    hereket_novu NVARCHAR(50) NOT NULL, -- 'Giriş', 'Çıxış', 'Qaytarma', 'Inventarizasiya'
    miqdar INT NOT NULL,
    hereket_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    istifadeci_id INT NOT NULL,
    sened_nomresi NVARCHAR(50) NULL,
    qeyd NVARCHAR(MAX) NULL,
    CONSTRAINT CHK_miqdar CHECK (miqdar > 0)
);

CREATE TABLE musteriler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) NOT NULL,
    soyad NVARCHAR(50) NOT NULL,
    telefon NVARCHAR(20) UNIQUE NOT NULL,
    unvan NVARCHAR(255) NULL,
    email NVARCHAR(100) NULL,
    nisye_limiti DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    cari_nisye_borcu DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    endirim_faizi DECIMAL(5,2) DEFAULT 0 NOT NULL,
    aktivdir BIT DEFAULT 1 NOT NULL,
    qeyd NVARCHAR(500) NULL,
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL
);

CREATE TABLE satislar (
    id INT PRIMARY KEY IDENTITY(1,1),
    satis_kodu AS ('SAT-' + RIGHT('000000' + CAST(id AS VARCHAR(6)), 6)), -- Avtomatik generasiya
    satis_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    musteri_id INT NULL,
    istifadeci_id INT NOT NULL,
    yekun_mebleg DECIMAL(18, 2) NOT NULL,
    odenmis_mebleg DECIMAL(18, 2) NOT NULL,
    qaliq_mebleg AS (yekun_mebleg - odenmis_mebleg),
    endirim_meblegi DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    qaytarilib BIT DEFAULT 0 NOT NULL,
    legv_tarixi DATETIME NULL,
    legv_eden_istifadeci_id INT NULL,
    qeyd NVARCHAR(MAX) NULL,
    CONSTRAINT CHK_odenis CHECK (odenmis_mebleg >= 0 AND yekun_mebleg >= odenmis_mebleg)
);

CREATE TABLE satis_mehsullari (
    id INT PRIMARY KEY IDENTITY(1,1),
    satis_id INT NOT NULL,
    mehsul_id INT NOT NULL,
    miqdar INT NOT NULL,
    qiymet_bir_edede DECIMAL(18, 2) NOT NULL,
    endirim_meblegi DECIMAL(18, 2) DEFAULT 0 NOT NULL,
    yekun_satish_qiymeti AS (miqdar * qiymet_bir_edede - endirim_meblegi),
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT CHK_satis_miqdar CHECK (miqdar > 0)
);

CREATE TABLE odenis_novleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) UNIQUE NOT NULL, -- 'Nağd', 'Kart', 'Nisyə'
    aktivdir BIT DEFAULT 1 NOT NULL,
    qeyd NVARCHAR(255) NULL
);

CREATE TABLE odenisler (
    id INT PRIMARY KEY IDENTITY(1,1),
    satis_id INT NOT NULL,
    odenis_nov_id INT NOT NULL,
    odenis_meblegi DECIMAL(18, 2) NOT NULL,
    odenis_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    kart_son_dord_reqem NVARCHAR(4) NULL,
    bank_ad NVARCHAR(100) NULL,
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT CHK_odenis_mebleg CHECK (odenis_meblegi > 0)
);

CREATE TABLE temir_statuslari (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(50) UNIQUE NOT NULL,
    siralama INT NOT NULL DEFAULT 0,
    icon_ad NVARCHAR(50) NULL
);

CREATE TABLE temirler (
    id INT PRIMARY KEY IDENTITY(1,1),
    temir_kodu AS ('TMR-' + RIGHT('000000' + CAST(id AS VARCHAR(6)), 6)), -- Avtomatik generasiya
    musteri_id INT NOT NULL,
    cihaz_adi NVARCHAR(100) NOT NULL,
    marka NVARCHAR(50) NULL,
    model NVARCHAR(50) NULL,
    seriya_nomresi NVARCHAR(100) NULL,
    problem_tesviri NVARCHAR(MAX) NOT NULL,
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
    CONSTRAINT CHK_tarixler CHECK (texminen_tamamlama_tarixi >= qebul_tarixi)
);

CREATE TABLE temir_hisseleri (
    id INT PRIMARY KEY IDENTITY(1,1),
    temir_id INT NOT NULL,
    mehsul_id INT NOT NULL,
    miqdar INT NOT NULL,
    qiymet_bir_edede DECIMAL(18, 2) NOT NULL,
    total_qiymet AS (miqdar * qiymet_bir_edede),
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT CHK_temir_miqdar CHECK (miqdar > 0)
);

CREATE TABLE nisye_borclar (
    id INT PRIMARY KEY IDENTITY(1,1),
    musteri_id INT NOT NULL,
    satish_id INT NULL,
    borc_meblegi DECIMAL(18, 2) NOT NULL,
    faiz_derecesi DECIMAL(5,2) DEFAULT 0 NOT NULL,
    toplam_borc_meblegi DECIMAL(18,2) NOT NULL,
    odenmis_mebleg DECIMAL(18,2) DEFAULT 0 NOT NULL,
    qaliq_borc AS (toplam_borc_meblegi - odenmis_mebleg),
    yaradilma_tarixi DATETIME DEFAULT GETDATE() NOT NULL,
    odeme_baslama_tarixi DATE NOT NULL,
    odeme_bitme_tarixi DATE NOT NULL,
    status NVARCHAR(50) NOT NULL, -- 'Aktiv', 'Tam ödənmiş', 'Gecikmiş', 'Ləğv edilmiş'
    qeyd NVARCHAR(500) NULL,
    CONSTRAINT CHK_borc_tarix CHECK (odeme_bitme_tarixi > odeme_baslama_tarixi)
);

CREATE TABLE odenis_cedveli (
    id INT PRIMARY KEY IDENTITY(1,1),
    nisye_id INT NOT NULL,
    odenecek_mebleg DECIMAL(18,2) NOT NULL,
    planlanan_tarix DATE NOT NULL,
    odenis_tarixi DATETIME NULL,
    odenis_usulu NVARCHAR(50) NULL,
    odenmis_miqdar DECIMAL(18,2) DEFAULT 0 NOT NULL,
    status NVARCHAR(50) NOT NULL, -- 'Gözlənilir', 'Ödəndi', 'Gecikdi', 'Ləğv edildi'
    qeyd NVARCHAR(255) NULL,
    CONSTRAINT CHK_odenis_miqdar CHECK (odenmis_miqdar >= 0)
);

CREATE TABLE xidmetler (
    id INT PRIMARY KEY IDENTITY(1,1),
    ad NVARCHAR(100) NOT NULL,
    qiymet DECIMAL(18, 2) NOT NULL,
    ortalama_vaxt INT NULL, -- Dəqiqə ilə
    tesvir NVARCHAR(MAX) NULL,
    aktivdir BIT DEFAULT 1 NOT NULL
);
GO

-- Optimallaşdırılmış indekslər
CREATE INDEX IX_mehsullar_barkod ON mehsullar(barkod) WHERE barkod IS NOT NULL;
CREATE INDEX IX_satislar_tarix ON satislar(satis_tarixi);
CREATE INDEX IX_satislar_musteri ON satislar(musteri_id) WHERE musteri_id IS NOT NULL;
CREATE INDEX IX_temirler_status ON temirler(status_id);
CREATE INDEX IX_temirler_musteri ON temirler(musteri_id);
CREATE INDEX IX_anbar_hereketleri_mehsul ON anbar_hereketleri(mehsul_id);
CREATE INDEX IX_anbar_hereketleri_tarix ON anbar_hereketleri(hereket_tarixi);
GO

-- Əlaqələrin (Foreign Keys) yaradılması
ALTER TABLE istifadeciler ADD CONSTRAINT FK_istifadeciler_rollar FOREIGN KEY (rol_id) REFERENCES rollar(id);
ALTER TABLE emeliyyat_jurnali ADD CONSTRAINT FK_emeliyyat_istifadeci FOREIGN KEY (istifadeci_id) REFERENCES istifadeciler(id);
ALTER TABLE mehsullar ADD CONSTRAINT FK_mehsullar_kateqoriya FOREIGN KEY (kateqoriya_id) REFERENCES kateqoriyalar(id);
ALTER TABLE mehsullar ADD CONSTRAINT FK_mehsullar_vahid FOREIGN KEY (vahid_id) REFERENCES vahidler(id);
ALTER TABLE mehsullar ADD CONSTRAINT FK_mehsullar_tedarukcu FOREIGN KEY (tedarukcu_id) REFERENCES tedarukcüler(id);
ALTER TABLE anbar_hereketleri ADD CONSTRAINT FK_anbar_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id);
ALTER TABLE anbar_hereketleri ADD CONSTRAINT FK_anbar_istifadeci FOREIGN KEY (istifadeci_id) REFERENCES istifadeciler(id);
ALTER TABLE satislar ADD CONSTRAINT FK_satislar_musteri FOREIGN KEY (musteri_id) REFERENCES musteriler(id);
ALTER TABLE satislar ADD CONSTRAINT FK_satislar_istifadeci FOREIGN KEY (istifadeci_id) REFERENCES istifadeciler(id);
ALTER TABLE satislar ADD CONSTRAINT FK_satislar_legv_eden_istifadeci FOREIGN KEY (legv_eden_istifadeci_id) REFERENCES istifadeciler(id);
ALTER TABLE satis_mehsullari ADD CONSTRAINT FK_satis_mehsullari_satis FOREIGN KEY (satis_id) REFERENCES satislar(id) ON DELETE CASCADE;
ALTER TABLE satis_mehsullari ADD CONSTRAINT FK_satis_mehsullari_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id);
ALTER TABLE odenisler ADD CONSTRAINT FK_odenisler_satis FOREIGN KEY (satis_id) REFERENCES satislar(id) ON DELETE CASCADE;
ALTER TABLE odenisler ADD CONSTRAINT FK_odenisler_odenis_novleri FOREIGN KEY (odenis_nov_id) REFERENCES odenis_novleri(id);
ALTER TABLE temirler ADD CONSTRAINT FK_temirler_musteri FOREIGN KEY (musteri_id) REFERENCES musteriler(id);
ALTER TABLE temirler ADD CONSTRAINT FK_temirler_status FOREIGN KEY (status_id) REFERENCES temir_statuslari(id);
ALTER TABLE temirler ADD CONSTRAINT FK_temirler_temirci FOREIGN KEY (temirci_id) REFERENCES istifadeciler(id);
ALTER TABLE temirler ADD CONSTRAINT FK_temirler_mexaric_istifadeci FOREIGN KEY (mexaric_qeyd_eden_istifadeci_id) REFERENCES istifadeciler(id);
ALTER TABLE temir_hisseleri ADD CONSTRAINT FK_temir_hisseleri_temir FOREIGN KEY (temir_id) REFERENCES temirler(id) ON DELETE CASCADE;
ALTER TABLE temir_hisseleri ADD CONSTRAINT FK_temir_hisseleri_mehsul FOREIGN KEY (mehsul_id) REFERENCES mehsullar(id);
ALTER TABLE nisye_borclar ADD CONSTRAINT FK_nisye_borclar_musteri FOREIGN KEY (musteri_id) REFERENCES musteriler(id);
ALTER TABLE nisye_borclar ADD CONSTRAINT FK_nisye_borclar_satis FOREIGN KEY (satish_id) REFERENCES satislar(id);
ALTER TABLE odenis_cedveli ADD CONSTRAINT FK_odenis_cedveli_nisye FOREIGN KEY (nisye_id) REFERENCES nisye_borclar(id) ON DELETE CASCADE;
GO

-- Stok avtomatik yeniləmə üçün trigger
CREATE TRIGGER TR_anbar_hereketleri_stok
ON anbar_hereketleri
AFTER INSERT
AS
BEGIN
    SET NOCOUNT ON;
    
    UPDATE m
    SET m.cari_stok = 
        CASE WHEN i.hereket_novu = 'Giriş' THEN m.cari_stok + i.miqdar
             WHEN i.hereket_novu = 'Çıxış' THEN m.cari_stok - i.miqdar
             ELSE m.cari_stok
        END,
        m.son_deyisiklik = GETDATE()
    FROM mehsullar m
    INNER JOIN inserted i ON m.id = i.mehsul_id;
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
           'Yekun məbləğ: ' + CAST(d.yekun_mebleg AS NVARCHAR(50))
    FROM deleted d;
END;
GO

-- İlkin məlumatların daxil edilməsi
INSERT INTO rollar (ad, tesvir) VALUES 
('Admin', 'Tam çıxış hüquqları'),
('Kassir', 'Satış və qaytarma əməliyyatları'),
('Anbarçı', 'Stok idarəçiliyi'),
('Təmirçi', 'Təmir proseslərinin idarə edilməsi'),
('Hesabdar', 'Maliyyə hesabatları və nisyə idarəçiliği');

INSERT INTO odenis_novleri (ad) VALUES 
('Nağd'), 
('Kart'), 
('Nisyə');

INSERT INTO temir_statuslari (ad, siralama) VALUES 
('Qəbul edildi', 1),
('Diaqnostikada', 2),
('Təmirdə', 3),
('Ehtiyat hissə gözləyir', 4),
('Təmir olunub (ödəniş gözləyir)', 5),
('Təhvil verildi', 6);

INSERT INTO vahidler (ad, qisaltma) VALUES 
('Ədəd', 'əd.'),
('kq', 'kq'),
('Litr', 'lt'),
('Metr', 'm'),
('Dəst', 'dəst');

-- Nümunə Admin istifadəçisi (Parol real tətbiqdə hash-lənəcək)
INSERT INTO istifadeciler (ad, soyad, istifadeci_adi, parol_hash, parol_salt, rol_id)
VALUES ('Sistem', 'Admini', 'admin', 
        'BURAGÜCLÜHASHGƏLƏCƏK', 
        'SALTDƏYƏRİ', 
        1);

-- Nümunə kateqoriyalar
INSERT INTO kateqoriyalar (ad, tesvir) VALUES
('Traktor Ehtiyat Hissələri', 'Traktorlar üçün ehtiyat hissələri'),
('Suluq Avadanlıqları', 'Sulama sistemləri üçün avadanlıqlar'),
('Əkin Alətləri', 'Torpaq işləmə alətləri');

-- Nümunə tədarükçü
INSERT INTO tedarukcüler (ad, vergi_nomresi, telefon, email) VALUES
('AgroTech MMC', '123456789', '+994501234567', 'info@agrotech.az');
GO

-- View-ların yaradılması
CREATE VIEW vw_aktiv_mehsullar AS
SELECT m.*, k.ad AS kateqoriya, v.ad AS vahid, t.ad AS tedarukcu
FROM mehsullar m
JOIN kateqoriyalar k ON m.kateqoriya_id = k.id
JOIN vahidler v ON m.vahid_id = v.id
LEFT JOIN tedarukcüler t ON m.tedarukcu_id = t.id
WHERE m.aktivdir = 1 AND m.silinib = 0;
GO

CREATE VIEW vw_stok_xəbərdarlığı AS
SELECT m.id, m.ad, m.cari_stok, m.minimum_stok, k.ad AS kateqoriya
FROM mehsullar m
JOIN kateqoriyalar k ON m.kateqoriya_id = k.id
WHERE m.cari_stok <= m.minimum_stok AND m.aktivdir = 1 AND m.silinib = 0;
GO

PRINT 'AzAgroPOS verilənlər bazası uğurla quruldu və konfiqurasiya edildi';