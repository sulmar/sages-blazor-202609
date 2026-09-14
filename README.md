# Przykłady ze szkolenia Tworzenie aplikacji Blazor

## Wprowadzenie

Witaj w repozytorium z materiałami do szkolenia **Tworzenie aplikacji Blazor**.

Repozytorium zawiera **gotowe zaplecze** — model domenowy, dane testowe i serwer
wystawiający tokeny JWT. Dzięki temu na szkoleniu zajmujemy się wyłącznie Blazorem,
a nie pisaniem od zera rzeczy, które i tak już umiesz.

Do rozpoczęcia tego kursu potrzebujesz następujących rzeczy:

1. [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)
2. Edytor: Visual Studio 2026, JetBrains Rider albo Visual Studio Code z rozszerzeniem C# Dev Kit

## Przygotowanie

1. Sklonuj repozytorium Git

```bash
git clone https://github.com/sulmar/blazor-template.git
cd blazor-template
```

2. Zbuduj

```bash
cd src
dotnet build
```

3. Zaufaj certyfikatowi deweloperskiemu (jednorazowo, potrzebne do HTTPS)

```bash
dotnet dev-certs https --trust
```

## Struktura repozytorium

| Katalog | Zawartość |
| --- | --- |
| `src/Domain` | Model domenowy (`Product`, `Customer`) i interfejsy repozytoriów |
| `src/Infrastructure` | Repozytoria w pamięci + generator danych testowych (Bogus) |
| `src/IdentityProvider.Api` | Serwer logowania wystawiający token JWT |
| `exercises` | Zadania do wykonania na szkoleniu |
| `docs` | Materiały pomocnicze (PDF, diagramy) |

## Dane testowe

Repozytoria w pamięci rejestrujesz **jedną linią** w `Program.cs` swojej aplikacji:

```csharp
builder.Services.AddInfrastructure();
```

Od tej chwili możesz wstrzykiwać `IProductRepository` i `ICustomerRepository`.

Dane pochodzą z biblioteki [Bogus](https://github.com/bchavez/Bogus) i mają **stały seed**,
więc po restarcie aplikacji produkt o `Id = 2` jest wciąż tym samym produktem.

### Ustawienia

| Opcja | Domyślnie | Do czego |
| --- | --- | --- |
| `ProductsCount` | `50` | Liczba wygenerowanych produktów |
| `CustomersCount` | `50` | Liczba wygenerowanych klientów |
| `Latency` | `2 s` | Opóźnienie `GetAllAsync` i `GetByIdAsync` — wskaźnik ładowania |
| `SearchLatency` | `500 ms` | Opóźnienie `GetByTextAsync` i `GetByColorAsync` — debounce |

```csharp
builder.Services.AddInfrastructure();                                // 2 s, jak teraz
builder.Services.AddInfrastructure(o => o.Latency = TimeSpan.Zero);  // szybkie iterowanie
builder.Services.AddInfrastructure(o => { o.Latency = TimeSpan.FromSeconds(5); o.ProductsCount = 500; });
```

Opóźnienia są **celowe** — bez nich nie da się przećwiczyć wyświetlania spinnera.
Oba pokrętła są niezależne, więc przy zadaniu z wyszukiwarką możesz wyłączyć
opóźnienie listy, a zostawić samo opóźnienie wyszukiwania:

```csharp
builder.Services.AddInfrastructure(o =>
{
    o.Latency = TimeSpan.Zero;
    o.SearchLatency = TimeSpan.FromMilliseconds(800);
});
```

## Uruchomienie serwera logowania

```bash
cd src
dotnet run --project IdentityProvider.Api
```

| Profil | Adres |
| --- | --- |
| `http` (domyślny) | <http://localhost:5143> |
| `https` | <https://localhost:7227> |

Aby wystartować z HTTPS:

```bash
dotnet run --project IdentityProvider.Api --launch-profile https
```

### Endpointy

| Metoda | Ścieżka | Opis |
| --- | --- | --- |
| `GET` | `/` | Sprawdzenie, czy serwer żyje |
| `POST` | `/api/login` | Zwraca `accessToken` (JWT) albo `401` |

Przykładowe żądania znajdziesz w pliku `src/IdentityProvider.Api/login.http` —
w Visual Studio, Riderze i VS Code możesz je wysłać wprost z edytora.

```bash
curl -X POST http://localhost:5143/api/login \
  -H "Content-Type: application/json" \
  -d '{"username":"alice","password":"alicepass"}'
```

### Użytkownicy testowi

| Login | Hasło | Role | Uprawnienia |
| --- | --- | --- | --- |
| `john` | `123` | — | — |
| `alice` | `alicepass` | `admin` | `canprint`, `canedit` |
| `bob` | `bobsecure` | `dev`, `support` | `canedit` |

Token jest podpisany algorytmem `HS256` i ważny 30 minut. Zawiera m.in. `role`,
`permission` i `Department` — wystarczy, żeby przećwiczyć autoryzację w Blazorze
na podstawie ról, uprawnień i własnego claima. Ustawienia zmienisz w sekcji
`JwtSettings` w `src/IdentityProvider.Api/appsettings.json`.

> Hasła są haszowane algorytmem PBKDF2 (domyślny `PasswordHasher<T>`).
> W katalogu `PasswordHashers` znajdziesz gotowe implementacje BCrypt i Argon2
> — wystarczy podmienić rejestrację w `Program.cs`, żeby je porównać.

## Aplikacja kliencka

Projekt Blazora tworzysz sam — to celowe, bo start od pustego szablonu jest
częścią szkolenia. Zestawienie poleceń `dotnet new` znajdziesz
w [docs/dotnet-new-blazor.md](docs/dotnet-new-blazor.md).

Serwer logowania dopuszcza w CORS jeden adres: `https://localhost:7034`.
Twój projekt najpewniej wystartuje na innym porcie — sprawdź go
w `Properties/launchSettings.json` i popraw wpis w
`src/IdentityProvider.Api/Program.cs`, inaczej logowanie z przeglądarki
zostanie zablokowane.

## Zadania

| Zadanie | Ćwiczy |
| --- | --- |
| [Dashboard](exercises/dashboard-page.md) | Komponent wielokrotnego użytku, parametry |
| [Lista produktów](exercises/product-list-page.md) | Pobieranie danych z serwisu, tabela |
| [Strona produktu](exercises/product-landing-page.md) | Budowa komponentów, przekazywanie danych |
| [Panel wyszukiwania](exercises/product-search-panel.md) | Query string, parametry trasy |
| [Formularz z walidacją](exercises/product-form-validation.md) | `EditForm`, DataAnnotations / FluentValidation |
