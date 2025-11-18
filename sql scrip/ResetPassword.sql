-- Admin hesabını blokdan çıxar və digər istifadəçinin parolunu kopyala
USE AzAgroPOS_DB;
GO

-- Əvvəlcə işləyən bir istifadəçinin hash-ini götürək (kassir)
DECLARE @WorkingHash NVARCHAR(MAX);
SELECT @WorkingHash = ParolHash FROM Istifadeciler WHERE Id = 2;

PRINT 'Kassir hash: ' + @WorkingHash;
PRINT 'Hash uzunluğu: ' + CAST(LEN(@WorkingHash) AS VARCHAR);

-- İndi admin123 üçün yeni hash yaradıb saxlayaq
-- BCrypt hash: $2a$11$bwcdAYMDlqwe.VycTkhzZes8.QNAGNFCj/Q8lYBV0.cQeoIpEoee.

DECLARE @NewHash NVARCHAR(MAX) = N'$' + N'2a$' + N'11$' + N'bwcdAYMDlqwe.VycTkhzZes8.QNAGNFCj/Q8lYBV0.cQeoIpEoee.';

UPDATE Istifadeciler
SET
    ParolHash = @NewHash,
    UgursuzGirisCehdi = 0,
    HesabKilidlenmeTarixi = NULL,
    SonSifreDeyismeTarixi = GETDATE(),
    HesabAktivdir = 1
WHERE Id = 1;

-- Yoxlayaq
SELECT
    Id,
    IstifadeciAdi,
    ParolHash,
    LEN(ParolHash) AS [Hash Uzunluğu],
    HesabAktivdir AS [Aktiv],
    UgursuzGirisCehdi AS [Uğursuz Cəhd],
    CASE WHEN HesabKilidlenmeTarixi IS NULL THEN 'Açıq' ELSE 'Kilidli' END AS [Status]
FROM Istifadeciler
WHERE Id = 1;

PRINT '';
PRINT '=== GİRİŞ MƏLUMATLARI ===';
PRINT 'İstifadəçi: admin';
PRINT 'Parol: admin123';
GO
