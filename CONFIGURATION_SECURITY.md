# Configuration Security Guide - AzAgroPOS

## Connection String Management

Connection string-lər təhlükəsizlik səbəblərindən appsettings.json fayllarında saxlanmır.

### Development Environment

Development mühitində **User Secrets** istifadə olunur:

```bash
# User secret-ləri konfiqurasiya etmək üçün:
cd AzAgroPOS.Teqdimat
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "YOUR_CONNECTION_STRING_HERE"
```

User Secrets qoşulu olanlar:
- UserSecretsId: `8064af30-8b8d-4aa4-8bcc-a400a5459f41`
- Fayl yeri: `%APPDATA%\Microsoft\UserSecrets\8064af30-8b8d-4aa4-8bcc-a400a5459f41\secrets.json`

### Staging/Production Environment

Production və Staging mühitlərində **Environment Variables** istifadə edilməlidir:

#### Windows (PowerShell)
```powershell
$env:ConnectionStrings__DefaultConnection="YOUR_CONNECTION_STRING_HERE"
```

#### Windows (System Environment Variables)
1. System Properties → Advanced → Environment Variables
2. Yeni system variable yarat:
   - Ad: `ConnectionStrings__DefaultConnection`
   - Dəyər: connection string

#### Linux/Mac
```bash
export ConnectionStrings__DefaultConnection="YOUR_CONNECTION_STRING_HERE"
```

#### Docker
```yaml
environment:
  - ConnectionStrings__DefaultConnection=YOUR_CONNECTION_STRING_HERE
```

## Environment-Specific Configuration

### appsettings.json Hierarkiyası

1. **appsettings.json** - Base configuration (connection string boşdur)
2. **appsettings.Development.json** - Development-specific settings
3. **appsettings.Staging.json** - Staging-specific settings
4. **appsettings.Production.json** - Production-specific settings
5. **User Secrets** - Development override (git-ə daxil edilmir)
6. **Environment Variables** - Production/Staging override

### Prioritet Sırası

Environment Variables > User Secrets > appsettings.{Environment}.json > appsettings.json

## Security Best Practices

### ✅ DOs (Etməli)

1. **Connection string-ləri User Secrets-də saxlayın** (Development)
2. **Production-da Environment Variables istifadə edin**
3. **appsettings.json-u git-ə commit edin** (connection string boş olduqda)
4. **Strong passwords və Trusted_Connection istifadə edin**
5. **TrustServerCertificate=True yalnız development-də istifadə edin**

### ❌ DON'Ts (Etməməli)

1. **Connection string-ləri appsettings.json-da saxlamayın**
2. **Credentials-ı source code-a hard-code etməyin**
3. **appsettings.Production.json-u real credentials ilə commit etməyin**
4. **Connection string-ləri log-lara yazmayın**
5. **Weak authentication methods istifadə etməyin**

## Testing Environment

Test mühitində in-memory database istifadə olunur:

```csharp
var options = new DbContextOptionsBuilder<AzAgroPOSDbContext>()
    .UseInMemoryDatabase(databaseName: "AzAgroPOSTestDb")
    .Options;
```

## Troubleshooting

### "Connection string not found" xətası

1. User Secrets düzgün konfiqurasiya edildiyini yoxlayın:
   ```bash
   cd AzAgroPOS.Teqdimat
   dotnet user-secrets list
   ```

2. Environment variable qurulduğunu yoxlayın:
   ```powershell
   echo $env:ConnectionStrings__DefaultConnection
   ```

3. appsettings.{Environment}.json faylının mövcud olduğunu yoxlayın

### User Secrets sıfırlamaq

```bash
cd AzAgroPOS.Teqdimat
dotnet user-secrets clear
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "NEW_CONNECTION_STRING"
```

## Log Files Location

Əməliyyat zamanı yaranan log faylları **logs** qovluğunda saxlanılır:

### Log Fayllarının Yeri
- **Ümumi log (JSON format)**: `logs/app-YYYYMMDD.json`
- **Xəta log (JSON format)**: `logs/error-YYYYMMDD.json`
- **Debug log (Text format)**: `logs/debug-YYYYMMDD.txt`

### Logs qovluğunun tam yolu
```
C:\Users\murad\Tam\AzAgroPOS\AzAgroPOS.Teqdimat\logs\
```

### Log Fayllarına Baxış
```bash
# Ən son debug log-u oxumaq
cd AzAgroPOS.Teqdimat
type logs\debug-20251106.txt

# JSON log-u oxumaq (bu gün)
type logs\app-20251106.json

# Xəta log-u oxumaq
type logs\error-20251106.json
```

**Qeyd**: Log faylları hər gün yeni fayla bölünür (rolling interval), maksimum fayl həcmi 10 MB-dır.

## Additional Resources

- [ASP.NET Core Configuration](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/)
- [Safe Storage of App Secrets](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets)
- [Environment Variables in .NET](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-environment-variables)

---

**Qeyd**: Bu sənəd layihənin təhlükəsizlik strategiyasının bir hissəsidir. Bütün team members bu qaydaları gözləməlidir.
