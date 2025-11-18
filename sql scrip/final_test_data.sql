-- ================================================================
-- AZAGROPOS - SON TEST DATA SCRIPT
-- ================================================================
USE AzAgroPOS_DB;

SET NOCOUNT ON;
PRINT '================================================================';
PRINT 'TEST DATA YUKLEME';
PRINT '================================================================';

BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @IstifadeciId INT, @TedarukcuId INT, @MusteriId1 INT, @IsciId1 INT, @IsciId2 INT;
    DECLARE @MehsulId1 INT, @MehsulId2 INT, @MehsulId3 INT, @SatisId INT, @BonusId INT;

    SELECT TOP 1 @IstifadeciId = Id FROM Istifadeciler WHERE Silinib = 0;
    SELECT TOP 1 @TedarukcuId = Id FROM Tedarukculer WHERE Silinib = 0;
    SELECT TOP 1 @MusteriId1 = Id FROM Musteriler WHERE Silinib = 0;
    SELECT TOP 1 @IsciId1 = Id FROM Isciler WHERE Silinib = 0;
    SELECT TOP 1 @IsciId2 = Id FROM Isciler WHERE Silinib = 0 AND Id != @IsciId1 ORDER BY Id DESC;
    SELECT TOP 1 @MehsulId1 = Id FROM Mehsullar WHERE Silinib = 0 ORDER BY NEWID();
    SELECT TOP 1 @MehsulId2 = Id FROM Mehsullar WHERE Silinib = 0 AND Id != @MehsulId1 ORDER BY NEWID();
    SELECT TOP 1 @MehsulId3 = Id FROM Mehsullar WHERE Silinib = 0 AND Id NOT IN (@MehsulId1, @MehsulId2) ORDER BY NEWID();
    SELECT TOP 1 @SatisId = Id FROM Satislar WHERE Silinib = 0;

    -- 1. Bonus Qeydleri
    PRINT '1. Bonus qeydleri...';
    SELECT TOP 1 @BonusId = Id FROM MusteriBonuslari;
    IF @BonusId IS NOT NULL
    BEGIN
        INSERT INTO BonusQeydleri (MusteriBonusId, EmeliyyatNovu, BalMiqdari, EmeliyyatTarixi, Aciklama, SatisId, Silinib)
        VALUES (@BonusId, 0, 50.00, DATEADD(DAY, -30, GETDATE()), N'Ilkin bonus', NULL, 0),
               (@BonusId, 0, 30.00, DATEADD(DAY, -20, GETDATE()), N'Alis bonusu', @SatisId, 0),
               (@BonusId, 1, 20.00, DATEADD(DAY, -10, GETDATE()), N'Istifade', NULL, 0);
        PRINT '  3 bonus qeydi elave edildi';
    END

    -- 2. Alis Sifarisleri
    PRINT '2. Alis sifarisleri...';
    IF @TedarukcuId IS NOT NULL AND @MehsulId1 IS NOT NULL
    BEGIN
        DECLARE @SifarisId1 INT, @SifarisId2 INT;

        INSERT INTO AlisSifarisleri (SifarisNomresi, YaradilmaTarixi, TesdiqTarixi, GozlenilenTehvilTarixi, FaktikiTehvilTarixi, TedarukcuId, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'PO-001', DATEADD(DAY, -20, GETDATE()), DATEADD(DAY, -19, GETDATE()), DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -8, GETDATE()), @TedarukcuId, 3500.00, 3, N'Tamamlandi', 0);
        SET @SifarisId1 = SCOPE_IDENTITY();

        INSERT INTO AlisSifarisleri (SifarisNomresi, YaradilmaTarixi, TesdiqTarixi, GozlenilenTehvilTarixi, FaktikiTehvilTarixi, TedarukcuId, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'PO-002', DATEADD(DAY, -10, GETDATE()), DATEADD(DAY, -9, GETDATE()), DATEADD(DAY, 5, GETDATE()), NULL, @TedarukcuId, 4200.00, 2, N'Qismen alindi', 0);
        SET @SifarisId2 = SCOPE_IDENTITY();

        PRINT '  2 sifaris yaradildi';

        INSERT INTO AlisSifarisSetirleri (AlisSifarisId, MehsulId, Miqdar, BirVahidQiymet, CemiMebleg, TehvilAlinanMiqdar, Silinib)
        VALUES (@SifarisId1, @MehsulId1, 100, 20.00, 2000.00, 100, 0),
               (@SifarisId1, @MehsulId2, 75, 20.00, 1500.00, 75, 0),
               (@SifarisId2, @MehsulId2, 80, 30.00, 2400.00, 40, 0),
               (@SifarisId2, @MehsulId3, 60, 30.00, 1800.00, 0, 0);
        PRINT '  4 setir elave edildi';

        -- 3. Alis Senedleri
        PRINT '3. Alis senedleri...';
        DECLARE @SenedId1 INT, @SenedId2 INT;

        INSERT INTO AlisSenetleri (SenedNomresi, YaradilmaTarixi, TedarukcuId, TehvilTarixi, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'INV-001', DATEADD(DAY, -15, GETDATE()), @TedarukcuId, DATEADD(DAY, -15, GETDATE()), 2000.00, 2, N'Odenildi', 0);
        SET @SenedId1 = SCOPE_IDENTITY();

        INSERT INTO AlisSenetleri (SenedNomresi, YaradilmaTarixi, TedarukcuId, TehvilTarixi, UmumiMebleg, Status, Qeydler, Silinib)
        VALUES (N'INV-002', DATEADD(DAY, -8, GETDATE()), @TedarukcuId, DATEADD(DAY, -8, GETDATE()), 3500.00, 1, N'Qismen', 0);
        SET @SenedId2 = SCOPE_IDENTITY();

        PRINT '  2 sened yaradildi';

        DECLARE @SifarisSetirId INT;
        SELECT TOP 1 @SifarisSetirId = Id FROM AlisSifarisSetirleri WHERE AlisSifarisId = @SifarisId1;

        INSERT INTO AlisSenedSetirleri (AlisSenedId, MehsulId, Miqdar, BirVahidQiymet, CemiMebleg, AlisSifarisSetiriId, Silinib)
        VALUES (@SenedId1, @MehsulId1, 100, 20.00, 2000.00, @SifarisSetirId, 0),
               (@SenedId2, @MehsulId1, 75, 20.00, 1500.00, NULL, 0),
               (@SenedId2, @MehsulId2, 50, 40.00, 2000.00, NULL, 0);
        PRINT '  3 sened setri elave edildi';

        -- 4. Tedarukcu Odemeleri
        PRINT '4. Tedarukcu odemeleri...';
        INSERT INTO TedarukcuOdemeleri (OdemeNomresi, YaradilmaTarixi, TedarukcuId, AlisSenedId, OdemeTarixi, Mebleg, OdemeUsulu, Status, Qeydler, BankMelumatlari, Silinib)
        VALUES (N'PAY-001', DATEADD(DAY, -14, GETDATE()), @TedarukcuId, @SenedId1, DATEADD(DAY, -14, GETDATE()), 2000.00, 1, 1, N'Bank', N'Kapital Bank', 0),
               (N'PAY-002', DATEADD(DAY, -7, GETDATE()), @TedarukcuId, @SenedId2, DATEADD(DAY, -7, GETDATE()), 1500.00, 1, 1, N'Bank', N'Kapital', 0),
               (N'PAY-003', DATEADD(DAY, -2, GETDATE()), @TedarukcuId, @SenedId2, DATEADD(DAY, -2, GETDATE()), 1000.00, 0, 1, N'Nagd', NULL, 0);
        PRINT '  3 odeme elave edildi';
    END

    -- 5. Qaytarmalar
    PRINT '5. Qaytarmalar...';
    IF @SatisId IS NOT NULL
    BEGIN
        DECLARE @QaytarmaId INT;
        INSERT INTO Qaytarmalar (Tarix, SatisId, UmumiMebleg, Sebeb, KassirId, Silinib)
        VALUES (DATEADD(DAY, -5, GETDATE()), @SatisId, 75.50, N'Defekt', @IstifadeciId, 0);
        SET @QaytarmaId = SCOPE_IDENTITY();

        DECLARE @QaytMehsulId INT;
        SELECT TOP 1 @QaytMehsulId = MehsulId FROM SatisDetallari WHERE SatisId = @SatisId;
        IF @QaytMehsulId IS NOT NULL
        BEGIN
            INSERT INTO QaytarmaDetallari (QaytarmaId, MehsulId, Miqdar, Qiymet, UmumiMebleg, Silinib)
            VALUES (@QaytarmaId, @QaytMehsulId, 2, 37.75, 75.50, 0);
        END
        PRINT '  1 qaytarma elave edildi';
    END

    -- 6. Giris Loqu
    PRINT '6. Giris loqu...';
    INSERT INTO GirisLoquKaydlari (IstifadeciAdi, Ugurlu, CehdTarixi, IpUnvani, KomputerAdi, UgursuzluqSebebi, Silinib)
    VALUES (N'admin', 1, DATEADD(HOUR, -8, GETDATE()), N'192.168.1.100', N'PC-01', NULL, 0),
           (N'kassir', 1, DATEADD(HOUR, -7, GETDATE()), N'192.168.1.101', N'POS-01', NULL, 0),
           (N'hacker', 0, DATEADD(HOUR, -6, GETDATE()), N'203.45.67.89', N'UNKNOWN', N'Sehv sifre', 0),
           (N'admin', 1, DATEADD(MINUTE, -30, GETDATE()), N'192.168.1.100', N'PC-01', NULL, 0);
    PRINT '  4 log elave edildi';

    -- 7. Sessiyalar
    PRINT '7. Sessiyalar...';
    IF @IstifadeciId IS NOT NULL
    BEGIN
        INSERT INTO IstifadeciSessiyalari (IstifadeciId, BaslamaTarixi, SonAktivlikTarixi, BitməTarixi, Aktivdir, IpUnvani, KomputerAdi, Silinib)
        VALUES (@IstifadeciId, DATEADD(HOUR, -8, GETDATE()), DATEADD(HOUR, -4, GETDATE()), DATEADD(HOUR, -4, GETDATE()), 0, N'192.168.1.100', N'PC-01', 0),
               (@IstifadeciId, DATEADD(MINUTE, -45, GETDATE()), GETDATE(), NULL, 1, N'192.168.1.100', N'PC-01', 0);
        PRINT '  2 sessiya elave edildi';
    END

    -- 8. Isci Performansi (Temizle ve yeniden yarat)
    PRINT '8. Isci performanslari...';
    IF @IsciId1 IS NOT NULL
    BEGIN
        DELETE FROM IsciPerformanslari WHERE IsciId IN (@IsciId1, @IsciId2);

        INSERT INTO IsciPerformanslari (IsciId, Tarix, QeydDovru, Qiymet, Qeydler, Emsallar, Teklifler, Silinib)
        VALUES (@IsciId1, DATEADD(MONTH, -1, GETDATE()), N'Iyul', 9, N'Ela', N'Liderlik', N'Mukafat', 0),
               (@IsciId1, GETDATE(), N'Avqust', 9, N'En yaxsi', N'Innovasiya', N'Terfi', 0);

        IF @IsciId2 IS NOT NULL
        BEGIN
            INSERT INTO IsciPerformanslari (IsciId, Tarix, QeydDovru, Qiymet, Qeydler, Emsallar, Teklifler, Silinib)
            VALUES (@IsciId2, GETDATE(), N'Avqust', 7, N'Yaxsi', N'Davamlilik', N'Telim', 0);
        END
        PRINT '  3 performans elave edildi';
    END

    COMMIT TRANSACTION;

    PRINT '';
    PRINT '================================================================';
    PRINT 'UGURLA TAMAMLANDI!';
    PRINT '================================================================';

END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION;
    PRINT 'XETA: ' + ERROR_MESSAGE();
END CATCH;

SET NOCOUNT OFF;
GO
