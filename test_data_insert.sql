-- ================================================
-- Test Data Script for AzAgroPOS Database
-- ================================================
-- Bu script boş table-lara test data əlavə edir
-- ================================================

USE AzAgroPOS_DB;
GO

SET NOCOUNT ON;
PRINT '========================================';
PRINT 'Test Data Yaradılır...';
PRINT '========================================';
PRINT '';

-- ================================================
-- 1. Konfiqurasiyalar (System Configuration)
-- ================================================
PRINT '1. Konfiqurasiyalar əlavə edilir...';

IF NOT EXISTS (SELECT 1 FROM Konfiqurasiyalar WHERE Acar = 'SirketAdi')
BEGIN
    INSERT INTO Konfiqurasiyalar (Id, Acar, Deyer, Aciqlama, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), 'SirketAdi', 'AzAgroPOS MMC', 'Şirkətin rəsmi adı', 0, GETDATE(), GETDATE()),
        (NEWID(), 'Unvan', 'Bakı, Azərbaycan', 'Şirkət ünvanı', 0, GETDATE(), GETDATE()),
        (NEWID(), 'Telefon', '+994-12-XXX-XX-XX', 'Əlaqə nömrəsi', 0, GETDATE(), GETDATE()),
        (NEWID(), 'Email', 'info@azagropos.az', 'Email ünvanı', 0, GETDATE(), GETDATE()),
        (NEWID(), 'VOEN', '1234567890', 'Vergi ödəyicisinin eyniləşdirmə nömrəsi', 0, GETDATE(), GETDATE()),
        (NEWID(), 'CekBasliq', 'AzAgroPOS Satış Qəbzi', 'Çek başlığı', 0, GETDATE(), GETDATE()),
        (NEWID(), 'MinimumStokXeberdar', '5', 'Minimum stok səviyyəsi xəbərdarlığı', 0, GETDATE(), GETDATE()),
        (NEWID(), 'MusteriBalansLimiti', '5000', 'Müştəri maksimum borc limiti (AZN)', 0, GETDATE(), GETDATE()),
        (NEWID(), 'BonusFaizi', '2', 'Bonus faizi (%)', 0, GETDATE(), GETDATE()),
        (NEWID(), 'VergiFaizi', '18', 'ƏDV faizi (%)', 0, GETDATE(), GETDATE());

    PRINT '  ✓ 10 konfiqurasiya əlavə edildi';
END
ELSE
    PRINT '  - Konfiqurasiyalar artıq mövcuddur';

-- ================================================
-- 2. MusteriBonuslari (Customer Loyalty Points)
-- ================================================
PRINT '';
PRINT '2. Müştəri bonusları yaradılır...';

DECLARE @MusteriId1 UNIQUEIDENTIFIER, @MusteriId2 UNIQUEIDENTIFIER;

-- Mövcud müştəriləri götür
SELECT TOP 1 @MusteriId1 = Id FROM Musteriler WHERE Silinib = 0 ORDER BY YaradilmaTarixi;
SELECT TOP 1 @MusteriId2 = Id FROM Musteriler WHERE Silinib = 0 AND Id != @MusteriId1 ORDER BY YaradilmaTarixi DESC;

IF @MusteriId1 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM MusteriBonuslari WHERE MusteriId = @MusteriId1)
BEGIN
    INSERT INTO MusteriBonuslari (Id, MusteriId, CemBal, IstifadeOlunmusB al, QaliqBal, SonYenilenmeT arixi, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @MusteriId1, 125.50, 25.00, 100.50, GETDATE(), 0, DATEADD(DAY, -30, GETDATE()), GETDATE());

    PRINT '  ✓ Birinci müştəri üçün bonus yaradıldı';
END

IF @MusteriId2 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM MusteriBonuslari WHERE MusteriId = @MusteriId2)
BEGIN
    INSERT INTO MusteriBonuslari (Id, MusteriId, CemBal, IstifadeOlunmusB al, QaliqBal, SonYenilenmeT arixi, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @MusteriId2, 75.00, 0.00, 75.00, GETDATE(), 0, DATEADD(DAY, -15, GETDATE()), GETDATE());

    PRINT '  ✓ İkinci müştəri üçün bonus yaradıldı';
END

-- ================================================
-- 3. BonusQeydleri (Bonus Transaction History)
-- ================================================
PRINT '';
PRINT '3. Bonus əməliyyat tarixçəsi yaradılır...';

DECLARE @BonusId1 UNIQUEIDENTIFIER;
SELECT TOP 1 @BonusId1 = Id FROM MusteriBonuslari;

IF @BonusId1 IS NOT NULL
BEGIN
    INSERT INTO BonusQeydleri (Id, MusteriBonusId, SatisId, EmeliyyatTipi, Mebleg, Qeyd, EmeliyyatTarixi, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @BonusId1, NULL, 0, 50.00, 'İlkin bonus əlavəsi', DATEADD(DAY, -30, GETDATE()), 0, DATEADD(DAY, -30, GETDATE()), DATEADD(DAY, -30, GETDATE())),
        (NEWID(), @BonusId1, NULL, 0, 75.50, 'Alış-verişdən bonus', DATEADD(DAY, -20, GETDATE()), 0, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -20, GETDATE())),
        (NEWID(), @BonusId1, NULL, 1, 25.00, 'Bonus istifadəsi', DATEADD(DAY, -10, GETDATE()), 0, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -10, GETDATE()));

    PRINT '  ✓ 3 bonus qeydi əlavə edildi';
END

-- ================================================
-- 4. Xercler (Expenses)
-- ================================================
PRINT '';
PRINT '4. Xərc qeydləri yaradılır...';

DECLARE @IstifadeciId UNIQUEIDENTIFIER;
SELECT TOP 1 @IstifadeciId = Id FROM Istifadeciler WHERE Silinib = 0;

IF @IstifadeciId IS NOT NULL
BEGIN
    INSERT INTO Xercler (Id, Tarix, XercNovu, Mebleg, Aciqlama, IstifadeciId, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), DATEADD(DAY, -5, GETDATE()), 0, 150.00, 'Ofis ləvazimatları alışı', @IstifadeciId, 0, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, -5, GETDATE())),
        (NEWID(), DATEADD(DAY, -10, GETDATE()), 1, 80.00, 'Elektrik enerji ödənişi', @IstifadeciId, 0, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -10, GETDATE())),
        (NEWID(), DATEADD(DAY, -15, GETDATE()), 2, 120.00, 'İnternet və telefon', @IstifadeciId, 0, DATEADD(DAY, -15, GETDATE()), DATEADD(DAY, -15, GETDATE())),
        (NEWID(), DATEADD(DAY, -20, GETDATE()), 3, 300.00, 'Təmizlik xidməti', @IstifadeciId, 0, DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -20, GETDATE())),
        (NEWID(), DATEADD(DAY, -25, GETDATE()), 4, 200.00, 'Nəqliyyat xərcləri', @IstifadeciId, 0, DATEADD(DAY, -25, GETDATE()), DATEADD(DAY, -25, GETDATE()));

    PRINT '  ✓ 5 xərc qeydi əlavə edildi';
END

-- ================================================
-- 5. IsciPerformanslari (Employee Performance)
-- ================================================
PRINT '';
PRINT '5. İşçi performans qeydləri yaradılır...';

DECLARE @IsciId1 UNIQUEIDENTIFIER, @IsciId2 UNIQUEIDENTIFIER;
SELECT TOP 1 @IsciId1 = Id FROM Isciler WHERE Silinib = 0 ORDER BY YaradilmaTarixi;
SELECT TOP 1 @IsciId2 = Id FROM Isciler WHERE Silinib = 0 AND Id != @IsciId1 ORDER BY YaradilmaTarixi DESC;

IF @IsciId1 IS NOT NULL
BEGIN
    INSERT INTO IsciPerformanslari (Id, IsciId, DovrBaslangic, DovrBitis, SatisSayi, CemSatisMeblegi, TemirSayi, Qeyd, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @IsciId1, DATEADD(MONTH, -2, GETDATE()), DATEADD(MONTH, -1, GETDATE()), 45, 5500.00, 12, 'Yüksək performans', 0, DATEADD(MONTH, -1, GETDATE()), DATEADD(MONTH, -1, GETDATE())),
        (NEWID(), @IsciId1, DATEADD(MONTH, -1, GETDATE()), GETDATE(), 52, 6200.00, 15, 'Əla nəticə', 0, GETDATE(), GETDATE());

    PRINT '  ✓ Birinci işçi üçün performans qeydləri əlavə edildi';
END

IF @IsciId2 IS NOT NULL
BEGIN
    INSERT INTO IsciPerformanslari (Id, IsciId, DovrBaslangic, DovrBitis, SatisSayi, CemSatisMeblegi, TemirSayi, Qeyd, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @IsciId2, DATEADD(MONTH, -1, GETDATE()), GETDATE(), 38, 4200.00, 8, 'Orta performans', 0, GETDATE(), GETDATE());

    PRINT '  ✓ İkinci işçi üçün performans qeydi əlavə edildi';
END

-- ================================================
-- 6. IsciIznleri (Employee Leave Records)
-- ================================================
PRINT '';
PRINT '6. İşçi məzuniyyət qeydləri yaradılır...';

IF @IsciId1 IS NOT NULL AND @IsciId2 IS NOT NULL
BEGIN
    INSERT INTO IsciIznleri (Id, IsciId, IzinNovu, BaslangicTarixi, BitisTarixi, Sebeb, Statusu, MuracietTarixi, TesdiqEdenIsciId, TesdiqTarixi, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @IsciId1, 0, DATEADD(DAY, -45, GETDATE()), DATEADD(DAY, -31, GETDATE()), 'İllik məzuniyyət', 2, DATEADD(DAY, -50, GETDATE()), @IsciId2, DATEADD(DAY, -48, GETDATE()), 0, DATEADD(DAY, -50, GETDATE()), DATEADD(DAY, -30, GETDATE())),
        (NEWID(), @IsciId1, 1, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -9, GETDATE()), 'Ailə məsələsi', 2, DATEADD(DAY, -12, GETDATE()), @IsciId2, DATEADD(DAY, -11, GETDATE()), 0, DATEADD(DAY, -12, GETDATE()), DATEADD(DAY, -8, GETDATE())),
        (NEWID(), @IsciId2, 2, GETDATE(), DATEADD(DAY, 1, GETDATE()), 'Xəstəlik', 1, DATEADD(DAY, -1, GETDATE()), @IsciId1, NULL, 0, DATEADD(DAY, -1, GETDATE()), GETDATE());

    PRINT '  ✓ 3 məzuniyyət qeydi əlavə edildi';
END

-- ================================================
-- 7. EmekHaqqilari (Employee Salaries)
-- ================================================
PRINT '';
PRINT '7. Əmək haqqı qeydləri yaradılır...';

IF @IsciId1 IS NOT NULL AND @IstifadeciId IS NOT NULL
BEGIN
    INSERT INTO EmekHaqqilari (Id, IsciId, DovrBaslangic, DovrBitis, EsasMaas, Bonus, Tutma, XalisOdeme, OdemeStatusu, OdemeTarixi, Qeyd, IstifadeciId, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @IsciId1, DATEADD(MONTH, -2, DATEADD(DAY, 1 - DAY(GETDATE()), GETDATE())),
         DATEADD(DAY, -1, DATEADD(MONTH, -1, DATEADD(DAY, 1 - DAY(GETDATE()), GETDATE()))),
         1200.00, 200.00, 150.00, 1250.00, 2, DATEADD(MONTH, -1, GETDATE()), 'İyun ayı əmək haqqı', @IstifadeciId, 0, DATEADD(MONTH, -1, GETDATE()), DATEADD(MONTH, -1, GETDATE())),
        (NEWID(), @IsciId1, DATEADD(MONTH, -1, DATEADD(DAY, 1 - DAY(GETDATE()), GETDATE())),
         DATEADD(DAY, -1, DATEADD(DAY, 1 - DAY(GETDATE()), GETDATE())),
         1200.00, 250.00, 150.00, 1300.00, 1, NULL, 'İyul ayı əmək haqqı - gözləmədə', @IstifadeciId, 0, GETDATE(), GETDATE());

    PRINT '  ✓ Əmək haqqı qeydləri əlavə edildi';
END

IF @IsciId2 IS NOT NULL AND @IstifadeciId IS NOT NULL
BEGIN
    INSERT INTO EmekHaqqilari (Id, IsciId, DovrBaslangic, DovrBitis, EsasMaas, Bonus, Tutma, XalisOdeme, OdemeStatusu, OdemeTarixi, Qeyd, IstifadeciId, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @IsciId2, DATEADD(MONTH, -1, DATEADD(DAY, 1 - DAY(GETDATE()), GETDATE())),
         DATEADD(DAY, -1, DATEADD(DAY, 1 - DAY(GETDATE()), GETDATE())),
         1000.00, 100.00, 120.00, 980.00, 0, NULL, 'İyul ayı əmək haqqı hazırlanır', @IstifadeciId, 0, GETDATE(), GETDATE());

    PRINT '  ✓ İkinci işçi üçün əmək haqqı əlavə edildi';
END

-- ================================================
-- 8. AlisSifarisleri (Purchase Orders)
-- ================================================
PRINT '';
PRINT '8. Alış sifarişləri yaradılır...';

DECLARE @TedarukcuId UNIQUEIDENTIFIER;
SELECT TOP 1 @TedarukcuId = Id FROM Tedarukculer WHERE Silinib = 0;

IF @TedarukcuId IS NOT NULL AND @IstifadeciId IS NOT NULL
BEGIN
    DECLARE @SifarisId1 UNIQUEIDENTIFIER = NEWID();
    DECLARE @SifarisId2 UNIQUEIDENTIFIER = NEWID();

    INSERT INTO AlisSifarisleri (Id, TedarukcuId, SifarisNomresi, SifarisTarixi, TehvimTarixi, CemMebleg, Statusu, Qeyd, IstifadeciId, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (@SifarisId1, @TedarukcuId, 'PS-2024-001', DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -5, GETDATE()), 2500.00, 2, 'Təcili sifariş', @IstifadeciId, 0, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -5, GETDATE())),
        (@SifarisId2, @TedarukcuId, 'PS-2024-002', DATEADD(DAY, -3, GETDATE()), DATEADD(DAY, 7, GETDATE()), 3200.00, 1, 'Aylıq stok sifarişi', @IstifadeciId, 0, DATEADD(DAY, -3, GETDATE()), DATEADD(DAY, -3, GETDATE()));

    PRINT '  ✓ 2 alış sifarişi yaradıldı';

    -- Sifariş sətirləri
    DECLARE @MehsulId1 UNIQUEIDENTIFIER, @MehsulId2 UNIQUEIDENTIFIER, @MehsulId3 UNIQUEIDENTIFIER;
    SELECT TOP 1 @MehsulId1 = Id FROM Mehsullar WHERE Silinib = 0 ORDER BY NEWID();
    SELECT TOP 1 @MehsulId2 = Id FROM Mehsullar WHERE Silinib = 0 AND Id != @MehsulId1 ORDER BY NEWID();
    SELECT TOP 1 @MehsulId3 = Id FROM Mehsullar WHERE Silinib = 0 AND Id NOT IN (@MehsulId1, @MehsulId2) ORDER BY NEWID();

    IF @MehsulId1 IS NOT NULL AND @MehsulId2 IS NOT NULL
    BEGIN
        INSERT INTO AlisSifarisSetirleri (Id, AlisSifarisId, MehsulId, Miqdar, VahidQiymet, CemMebleg, QeydOlunmus Miqdar, Silinib, YaradilmaTarixi, YenilenmeT arixi)
        VALUES
            (NEWID(), @SifarisId1, @MehsulId1, 50, 25.00, 1250.00, 50, 0, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -5, GETDATE())),
            (NEWID(), @SifarisId1, @MehsulId2, 40, 31.25, 1250.00, 40, 0, DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -5, GETDATE()));

        PRINT '  ✓ Birinci sifariş üçün sətir ləri əlavə edildi';
    END

    IF @MehsulId2 IS NOT NULL AND @MehsulId3 IS NOT NULL
    BEGIN
        INSERT INTO AlisSifarisSetirleri (Id, AlisSifarisId, MehsulId, Miqdar, VahidQiymet, CemMebleg, QeydOlunmus Miqdar, Silinib, YaradilmaTarixi, YenilenmeT arixi)
        VALUES
            (NEWID(), @SifarisId2, @MehsulId2, 60, 30.00, 1800.00, 0, 0, DATEADD(DAY, -3, GETDATE()), DATEADD(DAY, -3, GETDATE())),
            (NEWID(), @SifarisId2, @MehsulId3, 70, 20.00, 1400.00, 0, 0, DATEADD(DAY, -3, GETDATE()), DATEADD(DAY, -3, GETDATE()));

        PRINT '  ✓ İkinci sifariş üçün sətirlər əlavə edildi';
    END
END

-- ================================================
-- 9. AlisSenetleri (Purchase Invoices)
-- ================================================
PRINT '';
PRINT '9. Alış sənədləri yaradılır...';

IF @TedarukcuId IS NOT NULL AND @IstifadeciId IS NOT NULL
BEGIN
    DECLARE @SenedId1 UNIQUEIDENTIFIER = NEWID();

    INSERT INTO AlisSenetleri (Id, TedarukcuId, SenedNomresi, SenedTarixi, CemMebleg, OdenmisMebleg, QaliqBorc, Statusu, Qeyd, IstifadeciId, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (@SenedId1, @TedarukcuId, 'INV-2024-001', DATEADD(DAY, -5, GETDATE()), 2500.00, 1000.00, 1500.00, 1, 'Qismən ödənilib', @IstifadeciId, 0, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, -2, GETDATE()));

    PRINT '  ✓ Alış sənədi yaradıldı';

    -- Sənəd sətirləri
    DECLARE @SifarisSetirId1 UNIQUEIDENTIFIER;
    SELECT TOP 1 @SifarisSetirId1 = Id FROM AlisSifarisSetirleri;

    IF @MehsulId1 IS NOT NULL
    BEGIN
        INSERT INTO AlisSenedSetirleri (Id, AlisSenedId, MehsulId, AlisSifarisSetiriId, Miqdar, VahidQiymet, CemMebleg, Silinib, YaradilmaTarixi, YenilenmeT arixi)
        VALUES
            (NEWID(), @SenedId1, @MehsulId1, @SifarisSetirId1, 50, 25.00, 1250.00, 0, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, -5, GETDATE())),
            (NEWID(), @SenedId1, @MehsulId2, NULL, 40, 31.25, 1250.00, 0, DATEADD(DAY, -5, GETDATE()), DATEADD(DAY, -5, GETDATE()));

        PRINT '  ✓ Sənəd sətirləri əlavə edildi';
    END

    -- Tədarükçü ödəməsi
    INSERT INTO TedarukcuOdemeleri (Id, TedarukcuId, AlisSenedId, Mebleg, OdemeMetodu, OdemeTarixi, Qeyd, IstifadeciId, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @TedarukcuId, @SenedId1, 1000.00, 1, DATEADD(DAY, -2, GETDATE()), 'Qismən ödəmə - bank köçürməsi', @IstifadeciId, 0, DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, -2, GETDATE()));

    PRINT '  ✓ Tədarükçü ödəməsi əlavə edildi';
END

-- ================================================
-- 10. Qaytarmalar (Product Returns)
-- ================================================
PRINT '';
PRINT '10. Məhsul qaytarma qeydləri yaradılır...';

DECLARE @SatisId UNIQUEIDENTIFIER;
SELECT TOP 1 @SatisId = Id FROM Satislar WHERE Silinib = 0 ORDER BY NEWID();

IF @SatisId IS NOT NULL AND @IstifadeciId IS NOT NULL
BEGIN
    DECLARE @QaytarmaId UNIQUEIDENTIFIER = NEWID();

    INSERT INTO Qaytarmalar (Id, SatisId, KassirId, QaytarmaTarixi, CemMebleg, OdemeMetodu, Sebeb, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (@QaytarmaId, @SatisId, @IstifadeciId, DATEADD(DAY, -2, GETDATE()), 45.50, 0, 'Defektli məhsul', 0, DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, -2, GETDATE()));

    PRINT '  ✓ Qaytarma qeydi yaradıldı';

    -- Qaytarma detalları
    DECLARE @QaytarmaMehsulId UNIQUEIDENTIFIER;
    SELECT TOP 1 @QaytarmaMehsulId = MehsulId FROM SatisDetallari WHERE SatisId = @SatisId;

    IF @QaytarmaMehsulId IS NOT NULL
    BEGIN
        INSERT INTO QaytarmaDetallari (Id, QaytarmaId, MehsulId, Miqdar, VahidQiymet, CemMebleg, Silinib, YaradilmaTarixi, YenilenmeT arixi)
        VALUES
            (NEWID(), @QaytarmaId, @QaytarmaMehsulId, 1, 45.50, 45.50, 0, DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, -2, GETDATE()));

        PRINT '  ✓ Qaytarma detalı əlavə edildi';
    END
END

-- ================================================
-- 11. GirisLoquKaydlari (Login Audit Logs)
-- ================================================
PRINT '';
PRINT '11. Giriş log qeydləri yaradılır...';

IF @IstifadeciId IS NOT NULL
BEGIN
    INSERT INTO GirisLoquKaydlari (Id, IstifadeciId, IstifadeciAdi, UgurluGiris, IPUnvani, CihazMelumat, GirisTarixi, UgursuzluqSebeb, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @IstifadeciId, 'admin', 1, '192.168.1.100', 'Windows 10 / Chrome 120', DATEADD(HOUR, -5, GETDATE()), NULL, 0, DATEADD(HOUR, -5, GETDATE()), DATEADD(HOUR, -5, GETDATE())),
        (NEWID(), @IstifadeciId, 'admin', 1, '192.168.1.100', 'Windows 10 / Chrome 120', DATEADD(HOUR, -3, GETDATE()), NULL, 0, DATEADD(HOUR, -3, GETDATE()), DATEADD(HOUR, -3, GETDATE())),
        (NEWID(), NULL, 'unknown_user', 0, '192.168.1.200', 'Windows 10 / Firefox 115', DATEADD(HOUR, -2, GETDATE()), 'İstifadəçi adı və ya şifrə səhvdir', 0, DATEADD(HOUR, -2, GETDATE()), DATEADD(HOUR, -2, GETDATE())),
        (NEWID(), @IstifadeciId, 'admin', 1, '192.168.1.100', 'Windows 10 / Chrome 120', DATEADD(MINUTE, -30, GETDATE()), NULL, 0, DATEADD(MINUTE, -30, GETDATE()), DATEADD(MINUTE, -30, GETDATE()));

    PRINT '  ✓ 4 giriş log qeydi əlavə edildi';
END

-- ================================================
-- 12. IstifadeciSessiyalari (User Sessions)
-- ================================================
PRINT '';
PRINT '12. İstifadəçi sessiya qeydləri yaradılır...';

IF @IstifadeciId IS NOT NULL
BEGIN
    INSERT INTO IstifadeciSessiyalari (Id, IstifadeciId, SessionToken, BaslangicZamani, SonAktivlik, BitisZamani, IPUnvani, CihazMelumat, Aktiv, Silinib, YaradilmaTarixi, YenilenmeT arixi)
    VALUES
        (NEWID(), @IstifadeciId, 'SES-' + CONVERT(VARCHAR(36), NEWID()), DATEADD(MINUTE, -45, GETDATE()), DATEADD(MINUTE, -2, GETDATE()), NULL, '192.168.1.100', 'Windows 10 / Chrome 120', 1, 0, DATEADD(MINUTE, -45, GETDATE()), DATEADD(MINUTE, -2, GETDATE())),
        (NEWID(), @IstifadeciId, 'SES-' + CONVERT(VARCHAR(36), NEWID()), DATEADD(HOUR, -8, GETDATE()), DATEADD(HOUR, -5, GETDATE()), DATEADD(HOUR, -5, GETDATE()), '192.168.1.100', 'Windows 10 / Chrome 120', 0, 0, DATEADD(HOUR, -8, GETDATE()), DATEADD(HOUR, -5, GETDATE()));

    PRINT '  ✓ 2 sessiya qeydi əlavə edildi';
END

-- ================================================
-- Xülasə
-- ================================================
PRINT '';
PRINT '========================================';
PRINT 'Test Data Uğurla Yaradıldı!';
PRINT '========================================';
PRINT '';
PRINT 'Əlavə edilən data:';
PRINT '  ✓ Konfiqurasiyalar: 10';
PRINT '  ✓ Müştəri bonusları: 2';
PRINT '  ✓ Bonus qeydləri: 3';
PRINT '  ✓ Xərclər: 5';
PRINT '  ✓ İşçi performansları: 3';
PRINT '  ✓ Məzuniyyətlər: 3';
PRINT '  ✓ Əmək haqqıları: 3';
PRINT '  ✓ Alış sifarişləri: 2 (4 sətir)';
PRINT '  ✓ Alış sənədləri: 1 (2 sətir)';
PRINT '  ✓ Tədarükçü ödəmələri: 1';
PRINT '  ✓ Qaytarmalar: 1 (1 sətir)';
PRINT '  ✓ Giriş logları: 4';
PRINT '  ✓ Sessiyalar: 2';
PRINT '';
PRINT 'Verilənlər bazası test üçün hazırdır!';
PRINT '========================================';

SET NOCOUNT OFF;
GO
