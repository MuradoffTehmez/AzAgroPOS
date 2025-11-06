-- ================================================================
-- AZAGROPOS - TAM TEST DATA SCRIPT
-- ================================================================
-- Bu script bütün boş table-lara real test data əlavə edir
-- Verilənlər bazası: AzAgroPOS_DB
-- Tarix: 2025
-- ================================================================

USE AzAgroPOS_DB;
GO

SET NOCOUNT ON;
PRINT '================================================================';
PRINT '   AZAGROPOS TEST DATA YUKLEME SKRIPTI';
PRINT '================================================================';
PRINT '';
PRINT 'Başlama vaxtı: ' + CONVERT(VARCHAR(20), GETDATE(), 120);
PRINT '';

BEGIN TRY
    BEGIN TRANSACTION;

    -- ================================================================
    -- DƏYIŞƏNLƏR
    -- ================================================================
    DECLARE @IstifadeciId INT;
    DECLARE @TedarukcuId INT;
    DECLARE @MusteriId1 INT, @MusteriId2 INT;
    DECLARE @IsciId1 INT, @IsciId2 INT;
    DECLARE @MehsulId1 INT, @MehsulId2 INT, @MehsulId3 INT;
    DECLARE @SatisId INT;
    DECLARE @BonusId INT;

    -- Mövcud dataları götür
    SELECT TOP 1 @IstifadeciId = Id FROM Istifadeciler WHERE Silinib = 0 ORDER BY Id;
    SELECT TOP 1 @TedarukcuId = Id FROM Tedarukculer WHERE Silinib = 0 ORDER BY Id;
    SELECT TOP 1 @MusteriId1 = Id FROM Musteriler WHERE Silinib = 0 ORDER BY Id;
    SELECT TOP 1 @MusteriId2 = Id FROM Musteriler WHERE Silinib = 0 AND Id != @MusteriId1 ORDER BY Id DESC;
    SELECT TOP 1 @IsciId1 = Id FROM Isciler WHERE Silinib = 0 ORDER BY Id;
    SELECT TOP 1 @IsciId2 = Id FROM Isciler WHERE Silinib = 0 AND Id != @IsciId1 ORDER BY Id DESC;
    SELECT TOP 1 @MehsulId1 = Id FROM Mehsullar WHERE Silinib = 0 ORDER BY NEWID();
    SELECT TOP 1 @MehsulId2 = Id FROM Mehsullar WHERE Silinib = 0 AND Id != @MehsulId1 ORDER BY NEWID();
    SELECT TOP 1 @MehsulId3 = Id FROM Mehsullar WHERE Silinib = 0 AND Id NOT IN (@MehsulId1, @MehsulId2) ORDER BY NEWID();
    SELECT TOP 1 @SatisId = Id FROM Satislar WHERE Silinib = 0 ORDER BY NEWID();

    -- ================================================================
    -- 1. BONUS QEYDLƏRİ (Bonus Transaction History)
    -- ================================================================
    PRINT '1. Bonus Qeydləri əlavə edilir...';

    SELECT TOP 1 @BonusId = Id FROM MusteriBonuslari;

    IF @BonusId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM BonusQeydleri WHERE MusteriBonusId = @BonusId)
    BEGIN
        INSERT INTO BonusQeydleri (MusteriBonusId, EmeliyyatNovu, BalMiqdari, EmeliyyatTarixi, Aciklama, SatisId, Silinib)
        VALUES
            (@BonusId, 0, 50.00, DATEADD(DAY, -30, GETDATE()), N'İlkin bonus əlavəsi', NULL, 0),
            (@BonusId, 0, 30.00, DATEADD(DAY, -20, GETDATE()), N'Alış-verişdən qazanılan bonus', @SatisId, 0),
            (@BonusId, 1, 20.00, DATEADD(DAY, -10, GETDATE()), N'Bonus istifadəsi', NULL, 0),
            (@BonusId, 0, 40.00, DATEADD(DAY, -5, GETDATE()), N'Kampaniya bonusu', NULL, 0);

        PRINT '  ✓ 4 bonus qeydi əlavə edildi';
    END
    ELSE
        PRINT '  - Bonus qeydləri üçün şərt ödənmir və ya artıq mövcuddur';

    -- ================================================================
    -- 2. ALIŞ SİFARİŞLƏRİ (Purchase Orders)
    -- ================================================================
    PRINT '';
    PRINT '2. Alış sifarişləri yaradılır...';

    IF @TedarukcuId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM AlisSifarisleri)
    BEGIN
        DECLARE @SifarisId1 INT, @SifarisId2 INT, @SifarisId3 INT;

        -- Sifariş 1 - Tamamlanmış
        INSERT INTO AlisSifarisleri (SifarisNomresi, YaradilmaTarixi, TesdiqTarixi, GozlenilenTehvilTarixi, FaktikiTehvilTarixi, TedarukcuId, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'PO-2024-001', DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -19, GETDATE()), DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -8, GETDATE()), @TedarukcuId, 3500.00, 3, N'Aylıq stok alışı - tamamlandı', 0);
        SET @SifarisId1 = SCOPE_IDENTITY();

        -- Sifariş 2 - Qismən təhvil alınmış
        INSERT INTO AlisSifarisleri (SifarisNomresi, YaradilmaTarixi, TesdiqTarixi, GozlenilenTehvilTarixi, FaktikiTehvilTarixi, TedarukcuId, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'PO-2024-002', DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -9, GETDATE()), DATEADD(DAY, 5, GETDATE()), NULL, @TedarukcuId, 4200.00, 2, N'Qismən təhvil alındı', 0);
        SET @SifarisId2 = SCOPE_IDENTITY();

        -- Sifariş 3 - Gözləmədə
        INSERT INTO AlisSifarisleri (SifarisNomresi, YaradilmaTarixi, TesdiqTarixi, GozlenilenTehvilTarixi, FaktikiTehvilTarixi, TedarukcuId, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'PO-2024-003', DATEADD(DAY, -2, GETDATE()), DATEADD(DAY, -1, GETDATE()), DATEADD(DAY, 15, GETDATE()), NULL, @TedarukcuId, 2800.00, 1, N'Təsdiq olundu, təhvil gözlənilir', 0);
        SET @SifarisId3 = SCOPE_IDENTITY();

        PRINT '  ✓ 3 alış sifarişi yaradıldı';

        -- Sifariş sətirləri
        IF @MehsulId1 IS NOT NULL
        BEGIN
            INSERT INTO AlisSifarisSetirleri (AlisSifarisId, MehsulId, Miqdar, BirVahidQiymet, CemiMebleg, TehvilAlinanMiqdar, Silinib)
            VALUES
                (@SifarisId1, @MehsulId1, 100, 20.00, 2000.00, 100, 0),
                (@SifarisId1, @MehsulId2, 50, 30.00, 1500.00, 50, 0),
                (@SifarisId2, @MehsulId2, 80, 30.00, 2400.00, 40, 0),
                (@SifarisId2, @MehsulId3, 60, 30.00, 1800.00, 0, 0),
                (@SifarisId3, @MehsulId1, 70, 20.00, 1400.00, 0, 0),
                (@SifarisId3, @MehsulId3, 70, 20.00, 1400.00, 0, 0);

            PRINT '  ✓ 6 sifariş sətri əlavə edildi';
        END
    END
    ELSE
        PRINT '  - Alış sifarişləri üçün şərt ödənmir və ya artıq mövcuddur';

    -- ================================================================
    -- 3. ALIŞ SƏNƏDLƏRİ (Purchase Invoices)
    -- ================================================================
    PRINT '';
    PRINT '3. Alış sənədləri yaradılır...';

    IF @TedarukcuId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM AlisSenetleri)
    BEGIN
        DECLARE @SenedId1 INT, @SenedId2 INT;
        DECLARE @SifarisSetirId INT;

        -- Sənəd 1 - Tam ödənilmiş
        INSERT INTO AlisSenetleri (SenedNomresi, YaradilmaTarixi, TedarukcuId, TehvilTarixi, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'INV-2024-001', DATEADD(DAY, -15, GETDATE()), @TedarukcuId, DATEADD(DAY, -15, GETDATE()), 2000.00, 2, N'Tam ödənildi', 0);
        SET @SenedId1 = SCOPE_IDENTITY();

        -- Sənəd 2 - Qismən ödənilmiş
        INSERT INTO AlisSenetleri (SenedNomresi, YaradilmaTarixi, TedarukcuId, TehvilTarixi, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'INV-2024-002', DATEADD(DAY, -8, GETDATE()), @TedarukcuId, DATEADD(DAY, -8, GETDATE()), 3500.00, 1, N'Qismən ödənildi', 0);
        SET @SenedId2 = SCOPE_IDENTITY();

        PRINT '  ✓ 2 alış sənədi yaradıldı';

        -- Sənəd sətirləri
        IF @MehsulId1 IS NOT NULL
        BEGIN
            SELECT TOP 1 @SifarisSetirId = Id FROM AlisSifarisSetirleri WHERE AlisSifarisId = @SifarisId1;

            INSERT INTO AlisSenedSetirleri (AlisSenedId, MehsulId, Miqdar, BirVahidQiymet, CemiMebleg, AlisSifarisSetiriId, Silinib)
            VALUES
                (@SenedId1, @MehsulId1, 100, 20.00, 2000.00, @SifarisSetirId, 0),
                (@SenedId2, @MehsulId1, 75, 20.00, 1500.00, NULL, 0),
                (@SenedId2, @MehsulId2, 50, 40.00, 2000.00, NULL, 0);

            PRINT '  ✓ 3 sənəd sətri əlavə edildi';
        END
    END
    ELSE
        PRINT '  - Alış sənədləri üçün şərt ödənmir və ya artıq mövcuddur';

    -- ================================================================
    -- 4. TƏDARÜKÇÜ ÖDƏMƏLƏRİ (Supplier Payments)
    -- ================================================================
    PRINT '';
    PRINT '4. Tədarükçü ödəmələri yaradılır...';

    IF @TedarukcuId IS NOT NULL AND @SenedId1 IS NOT NULL AND NOT EXISTS (SELECT 1 FROM TedarukcuOdemeleri)
    BEGIN
        INSERT INTO TedarukcuOdemeleri (OdemeNomresi, YaradilmaTarixi, TedarukcuId, AlisSenedId, OdemeTarixi, Mebleg, OdemeUsulu, Status, Qeydler, BankMelumatlari, Silinib)
        VALUES
            (N'PAY-2024-001', DATEADD(DAY, -14, GETDATE()), @TedarukcuId, @SenedId1, DATEADD(DAY, -14, GETDATE()), 2000.00, 1, 1, N'Tam ödəmə - bank köçürməsi', N'Bank: Kapital Bank, Hesab: AZ123456', 0),
            (N'PAY-2024-002', DATEADD(DAY, -7, GETDATE()), @TedarukcuId, @SenedId2, DATEADD(DAY, -7, GETDATE()), 1500.00, 1, 1, N'Qismən ödəmə', N'Bank: Kapital Bank', 0),
            (N'PAY-2024-003', DATEADD(DAY, -2, GETDATE()), @TedarukcuId, @SenedId2, DATEADD(DAY, -2, GETDATE()), 1000.00, 0, 1, N'Nağd ödəmə', NULL, 0);

        PRINT '  ✓ 3 tədarükçü ödəməsi əlavə edildi';
    END
    ELSE
        PRINT '  - Tədarükçü ödəmələri üçün şərt ödənmir və ya artıq mövcuddur';

    -- ================================================================
    -- 5. QAYTARMALAR (Product Returns)
    -- ================================================================
    PRINT '';
    PRINT '5. Qaytarma qeydləri yaradılır...';

    IF @SatisId IS NOT NULL AND @IstifadeciId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM Qaytarmalar)
    BEGIN
        DECLARE @QaytarmaId1 INT, @QaytarmaId2 INT;

        INSERT INTO Qaytarmalar (Tarix, SatisId, UmumiMebleg, Sebeb, KassirId, Silinib)
        VALUES
            (DATEADD(DAY, -5, GETDATE()), @SatisId, 75.50, N'Defektli məhsul', @IstifadeciId, 0),
            (DATEADD(DAY, -2, GETDATE()), @SatisId, 45.00, N'Müştəri istəyi', @IstifadeciId, 0);

        SET @QaytarmaId1 = SCOPE_IDENTITY() - 1;
        SET @QaytarmaId2 = SCOPE_IDENTITY();

        PRINT '  ✓ 2 qaytarma qeydi yaradıldı';

        -- Qaytarma detalları
        DECLARE @QaytMehsulId INT;
        SELECT TOP 1 @QaytMehsulId = MehsulId FROM SatisDetallari WHERE SatisId = @SatisId;

        IF @QaytMehsulId IS NOT NULL
        BEGIN
            INSERT INTO QaytarmaDetallari (QaytarmaId, MehsulId, Miqdar, Qiymet, UmumiMebleg, Silinib)
            VALUES
                (@QaytarmaId1, @QaytMehsulId, 2, 37.75, 75.50, 0),
                (@QaytarmaId2, @QaytMehsulId, 1, 45.00, 45.00, 0);

            PRINT '  ✓ 2 qaytarma detalı əlavə edildi';
        END
    END
    ELSE
        PRINT '  - Qaytarmalar üçün şərt ödənmir və ya artıq mövcuddur';

    -- ================================================================
    -- 6. GİRİŞ LOQU (Login Audit Logs)
    -- ================================================================
    PRINT '';
    PRINT '6. Giriş log qeydləri yaradılır...';

    IF NOT EXISTS (SELECT 1 FROM GirisLoquKaydlari)
    BEGIN
        INSERT INTO GirisLoquKaydlari (IstifadeciAdi, Ugurlu, CehdTarixi, IpUnvani, KomputerAdi, UgursuzluqSebebi, Silinib)
        VALUES
            (N'admin', 1, DATEADD(HOUR, -8, GETDATE()), N'192.168.1.100', N'WORKSTATION-01', NULL, 0),
            (N'kassir1', 1, DATEADD(HOUR, -7, GETDATE()), N'192.168.1.101', N'POS-TERMINAL-01', NULL, 0),
            (N'hacker', 0, DATEADD(HOUR, -6, GETDATE()), N'203.45.67.89', N'UNKNOWN', N'İstifadəçi adı və ya şifrə səhvdir', 0),
            (N'admin', 1, DATEADD(HOUR, -5, GETDATE()), N'192.168.1.100', N'WORKSTATION-01', NULL, 0),
            (N'kassir2', 1, DATEADD(HOUR, -4, GETDATE()), N'192.168.1.102', N'POS-TERMINAL-02', NULL, 0),
            (N'manager', 1, DATEADD(HOUR, -3, GETDATE()), N'192.168.1.105', N'MANAGER-PC', NULL, 0),
            (N'test_user', 0, DATEADD(HOUR, -2, GETDATE()), N'192.168.1.150', N'TEST-PC', N'Hesab deaktiv edilib', 0),
            (N'admin', 1, DATEADD(MINUTE, -30, GETDATE()), N'192.168.1.100', N'WORKSTATION-01', NULL, 0);

        PRINT '  ✓ 8 giriş log qeydi əlavə edildi';
    END
    ELSE
        PRINT '  - Giriş logları artıq mövcuddur';

    -- ================================================================
    -- 7. İSTİFADƏÇİ SESSİYALARI (User Sessions)
    -- ================================================================
    PRINT '';
    PRINT '7. İstifadəçi sessiyaları yaradılır...';

    IF @IstifadeciId IS NOT NULL AND NOT EXISTS (SELECT 1 FROM IstifadeciSessiyalari)
    BEGIN
        INSERT INTO IstifadeciSessiyalari (IstifadeciId, BaslamaTarixi, SonAktivlikTarixi, BitməTarixi, Aktivdir, IpUnvani, KomputerAdi, Silinib)
        VALUES
            (@IstifadeciId, DATEADD(HOUR, -8, GETDATE()), DATEADD(HOUR, -4, GETDATE()), DATEADD(HOUR, -4, GETDATE()), 0, N'192.168.1.100', N'WORKSTATION-01', 0),
            (@IstifadeciId, DATEADD(HOUR, -3, GETDATE()), DATEADD(HOUR, -1, GETDATE()), DATEADD(HOUR, -1, GETDATE()), 0, N'192.168.1.100', N'WORKSTATION-01', 0),
            (@IstifadeciId, DATEADD(MINUTE, -45, GETDATE()), GETDATE(), NULL, 1, N'192.168.1.100', N'WORKSTATION-01', 0);

        PRINT '  ✓ 3 sessiya qeydi əlavə edildi (1 aktiv)';
    END
    ELSE
        PRINT '  - Sessiyalar üçün şərt ödənmir və ya artıq mövcuddur';

    -- ================================================================
    -- 8. İŞÇİ PERFORMANSLARI (Employee Performance) - Düzəltilmiş
    -- ================================================================
    PRINT '';
    PRINT '8. İşçi performans qeydləri düzəldilir...';

    IF @IsciId1 IS NOT NULL
    BEGIN
        -- Mövcud boş qeydləri sil
        DELETE FROM IsciPerformanslari WHERE IsciId = @IsciId1;

        -- Yenilərini əlavə et
        INSERT INTO IsciPerformanslari (IsciId, Tarix, QeydDovru, Qiymet, Qeydler, Emsallar, Teklifler, Silinib)
        VALUES
            (@IsciId1, DATEADD(MONTH, -2, GETDATE()), N'İyun 2024', 8, N'Yaxşı performans', N'Davamlılıq, keyfiyyət', N'Təhsil proqramı', 0),
            (@IsciId1, DATEADD(MONTH, -1, GETDATE()), N'İyul 2024', 9, N'Əla performans', N'Liderlik, komanda işi', N'Mükafatlandırılmalıdır', 0),
            (@IsciId1, GETDATE(), N'Avqust 2024', 9, N'Ən yüksək performans', N'İnnovasiya, effektivlik', N'Terfi edilməlidir', 0);

        IF @IsciId2 IS NOT NULL
        BEGIN
            INSERT INTO IsciPerformanslari (IsciId, Tarix, QeydDovru, Qiymet, Qeydler, Emsallar, Teklifler, Silinib)
            VALUES
                (@IsciId2, DATEADD(MONTH, -1, GETDATE()), N'İyul 2024', 7, N'Orta-yaxşı performans', N'İşgüzarlıq', N'Təlim lazımdır', 0),
                (@IsciId2, GETDATE(), N'Avqust 2024', 8, N'Yaxşılaşma', N'İnkişaf, öyrənmə', N'Davam etməlidir', 0);
        END

        PRINT '  ✓ 5 performans qeydi əlavə edildi';
    END
    ELSE
        PRINT '  - Performans qeydləri üçün işçi tapılmadı';

    -- ================================================================
    -- COMMIT
    -- ================================================================
    COMMIT TRANSACTION;

    PRINT '';
    PRINT '================================================================';
    PRINT '   TEST DATA UĞURLA ƏLAVƏ EDİLDİ!';
    PRINT '================================================================';
    PRINT '';

    -- Yekun statistika
    PRINT 'ƏLAVƏ EDİLMİŞ DATA SAYI:';
    PRINT '  • Bonus qeydləri: ' + CAST((SELECT COUNT(*) FROM BonusQeydleri) AS VARCHAR(10));
    PRINT '  • Alış sifarişləri: ' + CAST((SELECT COUNT(*) FROM AlisSifarisleri) AS VARCHAR(10));
    PRINT '  • Alış sifariş sətirləri: ' + CAST((SELECT COUNT(*) FROM AlisSifarisSetirleri) AS VARCHAR(10));
    PRINT '  • Alış sənədləri: ' + CAST((SELECT COUNT(*) FROM AlisSenetleri) AS VARCHAR(10));
    PRINT '  • Alış sənəd sətirləri: ' + CAST((SELECT COUNT(*) FROM AlisSenedSetirleri) AS VARCHAR(10));
    PRINT '  • Tədarükçü ödəmələri: ' + CAST((SELECT COUNT(*) FROM TedarukcuOdemeleri) AS VARCHAR(10));
    PRINT '  • Qaytarmalar: ' + CAST((SELECT COUNT(*) FROM Qaytarmalar) AS VARCHAR(10));
    PRINT '  • Qaytarma detalları: ' + CAST((SELECT COUNT(*) FROM QaytarmaDetallari) AS VARCHAR(10));
    PRINT '  • Giriş logları: ' + CAST((SELECT COUNT(*) FROM GirisLoquKaydlari) AS VARCHAR(10));
    PRINT '  • Sessiyalar: ' + CAST((SELECT COUNT(*) FROM IstifadeciSessiyalari) AS VARCHAR(10));
    PRINT '  • İşçi performansları: ' + CAST((SELECT COUNT(*) FROM IsciPerformanslari) AS VARCHAR(10));
    PRINT '';
    PRINT 'Bitmə vaxtı: ' + CONVERT(VARCHAR(20), GETDATE(), 120);
    PRINT '';
    PRINT '✓ Verilənlər bazası tam test üçün hazırdır!';
    PRINT '================================================================';

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    PRINT '';
    PRINT '================================================================';
    PRINT '   XƏTA BAŞ VERDİ!';
    PRINT '================================================================';
    PRINT 'Xəta mesajı: ' + ERROR_MESSAGE();
    PRINT 'Xəta sətiri: ' + CAST(ERROR_LINE() AS VARCHAR(10));
    PRINT 'Xəta nömrəsi: ' + CAST(ERROR_NUMBER() AS VARCHAR(10));
    PRINT '================================================================';
END CATCH;

SET NOCOUNT OFF;
GO
