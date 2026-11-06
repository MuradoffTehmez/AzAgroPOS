# AzAgroPOS ekran və məlumat auditi — 6 noyabr 2026

## Əhatə və metod

Bu baxış istifadəçinin göndərdiyi ekran görüntülərinə, 31 əsas WinForms forma dizaynerinə, köməkçi endirim formasına və forma koduna əsaslanır. Hər formanın işlək ekranda ayrıca vizual sınağı aparılmayıb. Buna görə aşağıdakı dizayn qeydləri mənbə kodu və təqdim olunmuş görüntülərlə təsdiqlənən problemləri və konkret düzəliş istiqamətlərini göstərir.

Müqayisə üçün real POS axınında məhsul axtarışı/barkod, səbət, müştəri və ödənişin eyni satış kontekstində əlçatan olması, qısa yol məhsul plitələri və səbətdə miqdar redaktəsi götürülüb. Bu axın [Square satış səbəti](https://squareup.com/help/us/en/article/8238-build-your-customer-s-cart-in-the-square-retail-pos-app), [Square məhsul şəbəkəsi](https://squareup.com/help/us/en/article/8334-set-up-item-grid) və [Lightspeed satış ekranı](https://retail-support.lightspeedhq.com/hc/en-us/articles/360035206534-Using-the-Retail-POS-R-Series-Sales-screen) sənədlərində də göstərilir. AzAgroPOS bu əsas hissələrə malikdir, lakin hazırkı ölçü və sıxlıq xüsusən satış ekranında operatorun diqqətini dağıdır.

## Məlumatların vəziyyəti

`--seed-demo` əmri `AzAgroPOS_DB` bazasına əlaqəli, `TEST-UI` işarəli nümunələr əlavə edib. 34 tətbiq cədvəlinin hamısında ən azı bir qeyd olduğu SQL sorğusu ilə təsdiqlənib. Rollar, admin hesabı və konfiqurasiya saxlanılıb. Seeder bir tranzaksiyada işləyir və `TEST-UI Ərzaq` kateqoriyası mövcud olduqda ikinci dəfə əlavə etmir. Bu əmri real məlumatlı bazada işlətmək olmaz. İstifadəçi nümunələri sonradan özü siləcəyini bildirib; avtomatik silmə tətbiq edilməyib.

## Dizayn prinsipləri

1. **Satış masası:** axtarış və səbət əsas iş sahəsi, sürətli məhsullar köməkçi sahə, cəm/ödəniş isə sabit alt sahə olmalıdır. Tam ekran enində cədvəl sütunları təkrarlanmamalı, dar ekranda minimum enlər və şüurlu üfüqi sürüşmə olmalıdır.
2. **Bir dil və bir vizual sistem:** başlıq, sahə etiketi, əsas/ikinci dərəcəli düymə, xəbərdarlıq, rəqəm formatı və boş cədvəl mesajı bütün formalarda eyni olmalıdır. Qarışıq mavi/yaşıl başlıqlar və sistemin hazır `DataGridView` görünüşü mərhələlərlə aradan qaldırılmalıdır.
3. **Dolu və boş vəziyyət:** siyahılar həm nümunə məlumatla, həm də boş olduqda izahlı görünməlidir. Məlumat olmayan ekran xəta kimi görünməməlidir.
4. **Ölçüyə uyğunlaşma:** 100% və 125% Windows miqyasında əsas əməliyyat düymələri kəsilməməli, detallı formalar üçün minimum ölçü/scroll təmin edilməlidir.
5. **Əməliyyat təhlükəsizliyi:** silmə, qaytarma, borc və stok düzəlişi ayrıca səbəb, təsdiq və nəticə mesajı ilə göstərilməlidir.

## Forma üzrə nəticələr

| Forma | Mənbədə / görüntüdə görünən vəziyyət | Konkret dizayn işi | Prioritet |
|---|---|---|---|
| `LoginFormu` | 810×1050 ölçülü uzun mavi ekran və ortada kiçik kart; verilən görüntüdə böyük boş sahə. | 1020×690 yığcam iki sahəli giriş, yaşıl brend paneli, oxunaqlı giriş kartı və aktual versiya altlığı bu mərhələdə tətbiq edildi. Windows miqyasında canlı vizual yoxlama qalır. | P0 |
| `AnaMenuFormu` | MenuStrip və panel ilə dashboard birlikdədir; forma üçün 1503×908 başlanğıc ölçü. | Menyu başlıqları üçün ölçü/overflow yoxlaması, aktiv bölmə işarəsi, dashboard kartlarının kiçik ekranda yenidən düzülməsi. | P1 |
| `SatisFormu` | 1780×858 başlanğıc ölçü; ekran görüntüsündə səbət başlıqları təkrarlanır və kəsilir, məhsul siyahısı dar qalır, səbət boşluğu izahsızdır. | Avtomatik sütun yaradılması bağlandı, axtarış sütunları paneli doldurur, səbət boşluğu izah olunur. Sonrakı mərhələdə sürətli satış plitələrinin sahəsi və aşağı ödəniş paneli kiçik ekranlarda yenidən tərtib edilməlidir. | P0 |
| `MusteriIdareetmeFormu` | Siyahı/redaktə SplitContainer; əvvəlki görüntüdə yeni müştəri üçün mövcud qeydin sahələri qalırdı. | “Yeni” halında seçim və forma vəziyyətinin aydın göstəricisi, siyahıda borc/limit rənginin mənası, boş nəticə mesajı. | P0 |
| `NisyeIdareetmeFormu` | Müştəri və borc hərəkətləri üçün iki cədvəl, aşağıda ödəniş sahəsi. | Seçilmiş müştəri, cari borc, köhnə borc və ödəniş tarixçəsini ayrıca vizual qruplaşdırmaq; səlahiyyət imtinasında hansı icazə lazım olduğunu və yerini göstərmək. | P0 |
| `MehsulIdareetmeFormu` | İki cədvəl və redaktə kartı; əvvəlki görüntüdə alış qiyməti görünmürdü. | Alış və satış qiymətlərini yanaşı, vahid və vergi ilə birlikdə göstərmək; 1432×912 formanın sağ panelində düymələrin görünməsi. | P0 |
| `AnbarFormu` | Məhsul və tarixçə cədvəlləri SplitContainer-də; əvvəlki görüntüdə çox dar, oxunmayan sütunlar. | Sütunları əməliyyat üçün vacib 5–6 sahəyə endirmək, qalanını detallara keçirmək, stok artır/azalt/düzəliş üçün eyni ölçülü fəaliyyət paneli. | P1 |
| `AlisSifarisFormu` | İki cədvəl və tab; 1633×912 sabit başlanğıc ölçü. | Sifariş statusu, təchizatçı, gözlənilən/faktiki təhvil və ümumi məbləği oxunaqlı sütunlarda göstərmək; redaktə tabında cəmi sabit saxlamaq. | P1 |
| `AlisSenedFormu` | Sənəd və sətir cədvəlləri iki kartda. | Seçilən sənədin sətirlərini vizual əlaqələndirmək, boş sətir və təsdiqlənmiş sənəd halını ayrıca göstərmək. | P1 |
| `TedarukcuIdareetmeFormu` | Siyahı və redaktə SplitContainer-də; çoxlu `Dock=Fill` sahə. | Formada redaktə/yeni rejimini başlıqla bildirmək, telefon/VÖEN sütunlarını düzgün enləndirmək, əlaqə detallarını qruplaşdırmaq. | P1 |
| `TedarukcuOdemeFormu` | Yuxarı forma, alt cədvəl və düymələr. | Təchizatçı borcu, ödənən məbləğ, qalıq və sənəd istinadını eyni baxışda göstərmək; aşağı siyahı üçün boş vəziyyət. | P1 |
| `KassaFormu` | TabControl və iki cədvəl. | Kassa qalığını, giriş/çıxışı və növbə fərqini yuxarı xülasədə göstərmək; iki tabın status rənglərini uyğunlaşdırmaq. | P1 |
| `NovbeIdareetmesiFormu` | Yalnız iki kart, 770×398 ölçü. | Açıq növbə, kassir, başlanğıc məbləği və bağlanma nəticəsini bir ekran ardıcıllığına salmaq. | P1 |
| `QaytarmaFormu` | Bir satış məhsulları cədvəli və əməliyyat paneli. | Orijinal satış və qaytarılan miqdarı yanaşı göstərmək; qaytarma səbəbi və məbləğini təsdiqdən əvvəl vurğulamaq. | P1 |
| `QebzFormu` | 504×461 qəbz pəncərəsi. | Printer eninə uyğun önizləmə, kəsilmə və konfiqurasiyadan gələn şirkət məlumatlarının canlı əks olunması. | P1 |
| `KonfiqurasiyaFormu` | Bir neçə TableLayoutPanel və çox tab/sahə. | Saxlanmamış dəyişiklik göstəricisi, hər tab üçün aydın saxla/imtina əlaqəsi, qəbz önizləməsi ilə sinxron görünüş. | P1 |
| `IstifadeciIdareetmeFormu` | SplitContainer, siyahı və kart. | Admin/redaktə/rol icazələrini ayrıca qruplar; hesab aktivliyi və icazə mənbəyini görünən etmək. | P1 |
| `IsciIdareetmeFormu` | Bir cədvəl və çoxlu sahə/panel. | Şəxsi, iş və ödəniş məlumatlarını bölmək; 1000×660 pəncərədə scroll və saxla düyməsinin əlçatanlığını yoxlamaq. | P2 |
| `IsciIzniFormu` | Bir cədvəl, çoxlu Anchor. | Təqvim aralığı, status və qalıq günləri xülasələşdirmək; ardıcıl tarix formatı. | P2 |
| `EmekHaqqiFormu` | Yuxarı forma və alt cədvəl. | Ay, işçi, baza maaşı, əlavə/çıxılma və yekunu vahid hesab panelində göstərmək. | P2 |
| `BonusIdareetmeFormu` | TabControl və iki cədvəl. | Bonus balansı, verilən/xərclənən tarixçə və müştəri konteksti; iki tabın terminləri uyğun olsun. | P2 |
| `XercIdareetmeFormu` | Detal paneli, cədvəl və aşağı fəaliyyət paneli. | Xərc kateqoriyası, tarix və məbləği ilk baxışda oxunan sütunlara salmaq; formanın çoxlu nested layout boşluqlarını azaltmaq. | P2 |
| `TemirIdareetmeFormu` | Siyahı/redaktə SplitContainer və çoxlu sahə. | Müştəri, cihaz, mərhələ, təhvil və qiyməti solda xülasə; texniki qeydləri sağda bölmək. | P2 |
| `EhtiyatHissəsiFormu` | İki cədvəl və üç TableLayoutPanel. | Ehtiyat hissəsinin stok, alış və təmirə sərfini ayrı vizual bloklarda göstərmək. | P2 |
| `HesabatFormu` | KPI kartları və bir satış cədvəli. | Filtr tarixini görünən saxlamaq, nisyə satışı ilə nağd pul daxilolmasını ayrı ölçü kimi işarələmək. | P1 |
| `MehsulSatisHesabatFormu` | Filtr, üç xülasə kartı və cədvəl. | Cədvəl başlıqları/uzun adlar, tarix filtri və məbləğ formatı eyni sistemə salınmalı. | P2 |
| `AnbarQaliqHesabatFormu` | Filtr, dörd KPI və cədvəl. | Kritik/tükənmiş stok rəngləri, say və dəyərin fərqli vahidlərdə görünməsi. | P2 |
| `MinimumStokMehsullariFormu` | SplitContainer, siyahı və düymələr. | Minimum, mövcud və çatışmayan miqdarı yanaşı göstərmək; tədarük sifarişinə keçid. | P2 |
| `ZHesabatArxivFormu` | Filtr, KPI, növbə siyahısı və detal paneli. | Seçilmiş Z-hesabatın dövriyyə/ödəniş fərqini dərhal göstərmək; detalları siyahıya bağlamaq. | P2 |
| `BarkodCapiFormu` | Axtarış və çap siyahıları SplitContainer-də. | Etiket ölçüsü, say və printer önizləməsini çapdan əvvəl göstərmək; uzun məhsul adını kəsməmək. | P2 |
| `BazaIdareetmeFormu` | Əməliyyat forması, cədvəl yoxdur. | Yedəkləmə/bərpa üçün son nəticə, vaxt və fayl yerini konkret göstərmək; bərpadan əvvəl təsdiq mətni. | P2 |
| `Yardimcilar/EndirimFormu` | Kiçik köməkçi dialoq. | Faiz/məbləğ rejimini açıq etiketləmək, endirimdən sonrakı yekunu təsdiqdən əvvəl göstərmək. | P2 |

## İcra sırası

1. Bu mərhələdə nümunə məlumat, giriş ekranının quruluşu və satış cədvəllərinin görünüşü düzəldildi.
2. Sonrakı vizual mərhələdə tətbiqi 100% və 125% miqyasda açaraq giriş, satış, məhsul, müştəri, nisyə və anbar formalarını ekran görüntüsü ilə yoxlamaq lazımdır.
3. Sonra ümumi cədvəl və forma üslubu bir komponentdə toplanmalı; satınalma, kassa, qaytarma, işçi və hesabat formalarına tətbiq edilməlidir.

Avtomatlaşdırılmış test əlavə edilmədi; istifadəçinin bu barədə istəyi nəzərə alınıb.
