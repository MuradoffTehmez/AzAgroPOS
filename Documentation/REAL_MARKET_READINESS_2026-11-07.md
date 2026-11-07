# AzAgroPOS: real marketə hazırlıq icmalı (7 noyabr 2026)

## Bu mərhələdə edilənlər

- `satici_test` adlı aktiv `Kassir` hesabı yaradıldı. Rolun bazadakı icazələri yalnız `SatisYarat`, `MusteriGoruntule`, `MusteriElaveEt` olaraq yoxlandı.
- Giriş zamanı həmin istifadəçinin açıq növbəsi yoxdursa, başlanğıc məbləği 0 olan növbə avtomatik açılır. Normal proqram çıxışında cari növbə avtomatik bağlanır. Admin növbəni əl ilə də bağlaya bilər; satıcının əl ilə növbə formu və digər idarəetmə menyuları açılmır.
- Avtomatik bağlanmış növbədə pul sayılmadığı `SayimAparilib` ilə saxlanır. Z hesabatında faktiki məbləğ və fərq uydurulmur.
- Satıcıya yalnız satış menyusu göstərilir. Satışdakı `+` düyməsi satıcı üçün yalnız ad, telefon və ünvanla yeni müştəri yaratma pəncərəsi açır; müştəri siyahısındakı redaktə/silmə formuna aparmır. Endirim icazəsi də ayrıca yoxlanır.
- Nisyə satışının qəbzi üçün müştəri adı, bu satışın borcu və satışdan sonrakı ümumi borc satış anında saxlanır. Çap və təkrar qəbz baxışında göstərilir. Köhnə satışlarda saxlanmamış tarixi borc qalığı təxmin edilmir.
- Qəbzin printerə göndərilməsi UI axınından ayrılıb. Satış düyməsinin sürətli təkrar basılması ikinci əməliyyat yaratmır. Yükləmə örtüyü əvvəldən qapalı düymələri sonradan səhvən aktivləşdirmir.
- Admin ana səhifəsinə günlük satış sayı, nağd/kart/nisyə məbləğləri və stokun alış dəyəri əlavə edilib. Satıcı ana səhifəsində ümumi maliyyə göstəriciləri gizlədilib.
- Yeni verilənlər bazası scope-larında audit istifadəçisi `admin` kimi qalmır; aktiv sessiyanın istifadəçisi ötürülür.

## Satışa çıxmazdan əvvəl bağlanmalı əsas boşluqlar

| Prioritet | Mövzu | Kodda görünən vəziyyət və tələb |
|---|---|
| P0 | Fiskal qəbz və ödəniş terminalı | `CapServisi` Windows printerinə adi `PrintDocument` göndərir. Fiskal cihaz və kart terminalı ilə təsdiqli əməliyyat axını görünmür. Marketdə istifadə ediləcək konkret cihazlarla inteqrasiya və uçdan uca uyğunlaşdırma lazımdır. |
| P0 | Kassa uzlaşması | `NovbeManager` gözlənilən pulu başlanğıc + nağd satış + nağd borc ödənişi kimi hesablayır. Qaytarma və kassa çıxışlarının hamısı bu hesabda nəzərə alınmır; bəzi kassa hərəkətlərində `NovbeId` yazılmır. Növbəyə aid bütün nağd hərəkətlərin vahid ledger üzrə uzlaşması lazımdır. Avtomatik bağlanma faktiki pul sayımı əvəz etmir. |
| P0 | Çap etibarlılığı | Çap artıq satış ekranını bloklamır, amma proses bağlanarsa fon axınındakı çap işi itə bilər. Davamlı çap növbəsi, uğursuz işlərin siyahısı və yenidən çap audit izi lazımdır. |
| P0 | Eyni anda iş və qəza bərpası | Açıq növbə girişdə təkrar istifadə edilir. Qəza sonrası köhnə növbə ilə yeni girişin, habelə eyni hesabın iki kassada işləməsinin ayrıca sessiya siyasəti yoxdur. Çox kassa üçün növbə mülkiyyəti və atomik idempotent satış identifikatoru lazımdır. |
| P0 | Satıcı hüquqlarının bütün qatlarda tətbiqi | Menyu, satış/endirim və müştəri CRUD axınında icazə yoxlamaları var; digər menecerlərin hamısında vahid məcburi yoxlama yoxdur. Birbaşa SQL Server bağlantılı masaüstü tətbiq üçün DB hesabının səlahiyyətləri də ayrıca məhdudlaşdırılmalıdır. |
| P1 | Avtomatik ehtiyat nüsxə və bərpa sınağı | `BazaIdareetmeManager` əl ilə backup/restore edir. Cədvəlli avtomatik backup, başqa diskə saxlama, bərpa sınağı və monitorinq görünmür. |
| P1 | Stok partiyası və son istifadə tarixi | Məhsul və stok hərəkəti mövcuddur, lakin partiya/lot, yararlılıq müddəti, FEFO və vaxtı keçmiş məhsul bloklaması görünmür. Ərzaq marketi üçün bu məlumatlar lazımdır. |
| P1 | Qaytarma və alış uzlaşması | Satış qaytarması var. Alışın tədarükçüyə qaytarılması, qiymət fərqi və anbar/maliyyə uzlaşması üçün ayrıca tam axın görünmür. |
| P1 | Performans | Dashboard hazırda bir neçə cədvəli bütövlükdə yükləyir. Böyük məhsul, satış və müştəri bazasında SQL tərəfdə aqreqasiya, səhifələmə və yüklənmə vaxtı ölçülməlidir. |
| P1 | Rol üzrə əməliyyat sınağı | Admin və satıcı ilə normal/nisyə satış, mənfi stok, yeni müştəri, qəbz, proqram çıxışı və növbə arxivi eyni build üzərində UI-dən yoxlanmalıdır. |

## Yoxlama nəticəsi və sərhədi

- `dotnet build AzAgroPOS.sln -c Release --no-restore`: 0 xəta. Mövcud layihədə 384 xəbərdarlıq var.
- SQL Server `AzAgroPOS_DB` üzərində iki yeni migrasiya tətbiq edildi: avtomatik növbə sayımı və nisyə qəbz borc məlumatları.
- Satıcı hesabı aktivdir, BCrypt şifrəsi yoxlandı, rol icazələri SQL-də təsdiqləndi.
- Mövcud test paketi: 60 keçdi, 2 uğursuz. Hər iki uğursuz sınaq `SatisManagerTests` içində stok yoxlamasının köhnə davranışını gözləyir; hazırkı tələb sıfırdan aşağı stoka da satışa icazə verir. Test faylları bu mərhələdə dəyişdirilmədi.
- Computer Use bu sessiyada `GetCursorPos failed: Erişim engellendi (0x80070005)` xətası verdi; tətbiq UI-sinin yeni build üzrə vizual təsdiqi tamamlanmayıb. Computer Use qaydası giriş dialoqunu avtomatlaşdırmağa da icazə vermir. Satıcı ilə UI testinin nəticəsi kimi təqdim etmək olmaz.
