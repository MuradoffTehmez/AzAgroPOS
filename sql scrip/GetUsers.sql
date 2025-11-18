-- SQL sorğusu: Bütün istifadəçilərin adını və rolunu göstərmək üçün
-- Qeyd: Parollar BCrypt ilə hash edilib, açıq formada görünməyəcək

USE AzAgroPOS_DB;
GO

SELECT
    i.Id,
    i.IstifadeciAdi AS [İstifadəçi Adı],
    i.TamAd AS [Tam Ad],
    r.Ad AS [Rol],
    i.HesabAktivdir AS [Aktiv],
    i.SonGirisTarixi AS [Son Giriş],
    i.UgursuzGirisCehdi AS [Uğursuz Cəhd],
    i.HesabKilidlenmeTarixi AS [Kilidlənmə Tarixi],
    -- Parol hash formatında saxlanır, açıq görmək mümkün deyil
    LEFT(i.ParolHash, 20) + '...' AS [Parol Hash (Qismən)]
FROM
    Istifadeciler i
    LEFT JOIN Rollar r ON i.RolId = r.Id
ORDER BY
    i.Id;

GO

-- Admin istifadəçisini tapmaq üçün
SELECT
    i.Id,
    i.IstifadeciAdi AS [İstifadəçi Adı],
    i.TamAd AS [Tam Ad],
    r.Ad AS [Rol],
    i.HesabAktivdir AS [Aktiv]
FROM
    Istifadeciler i
    LEFT JOIN Rollar r ON i.RolId = r.Id
WHERE
    r.Ad = 'Admin' OR i.Id = 1;
