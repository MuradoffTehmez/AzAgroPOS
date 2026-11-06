# Ekran baxışı üçün nümunə məlumatlar

6 noyabr 2026-da lokal `AzAgroPOS_DB` bazasında 34 tətbiq cədvəlinin hamısı dolduruldu. Yeni kateqoriya, məhsul, müştəri və sənədlər `TEST-UI` prefiksi ilə tanınır. Nümunələr satış, nisyə, qaytarma, alış, stok, təchizatçı ödənişi, növbə, kassa, işçi, əmək haqqı, xərc, bonus və təmir axınlarını əlaqəli göstərir. Mövcud admin hesabı, rollar və konfiqurasiya dəyişdirilmir.

Eyni nümunələri yalnız **boş və ya ayrıca sınaq bazasında** yaratmaq üçün:

```powershell
dotnet run --project AzAgroPOS.Verilenler -c Release -- --seed-demo
```

Əmr bir tranzaksiyada işləyir; `TEST-UI Ərzaq` kateqoriyası artıq varsa, qeydlər təkrar yaradılmır. Əmr işlədilmədən əvvəl verilənlər layihəsinin mövcud migrasiyalar davranışını nəzərə alın: `Program.cs` pending migrasiyaları tətbiq edir.

Bu nümunələr real satış və maliyyə hesabatlarına daxil olur. İstifadəçi vizual baxış bitdikdən sonra məlumatları özü siləcək. Ona görə avtomatik silmə əmri verilməyib. Təkcə məhsul/müştəri silmək kifayət etmir: satış, stok, nisyə, kassa və digər əlaqəli sənədlər də nəzərə alınmalıdır. Nümunələr əlavə edilməzdən əvvəl bazanın ehtiyat nüsxəsi varsa, tam bərpa ən rahat yoldur.
