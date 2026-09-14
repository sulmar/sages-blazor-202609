
# ✅ Zestawienie poleceń dotnet new dla Blazora (.NET 8+)

| Typ aplikacji                                  | Polecenie `dotnet new`                          | Opis                                                                                     |
| ---------------------------------------------- | ----------------------------------------------- | ---------------------------------------------------------------------------------------- |
| **Blazor Web App – interaktywny (Auto)**       | `dotnet new blazor --interactivity Auto`        | Domyślna opcja – interaktywność dopasowana do środowiska (SSR + opcjonalnie WASM/Server) |
| **Blazor Web App – bez interaktywności (SSR)** | `dotnet new blazor --interactivity None`        | Tylko prerendering po stronie serwera (np. do HTMX), brak komponentów interaktywnych     |
| **Blazor Web App – Server**                    | `dotnet new blazor --interactivity Server`      | Interaktywność realizowana przez SignalR (jak Blazor Server)                             |
| **Blazor Web App – WebAssembly**               | `dotnet new blazor --interactivity WebAssembly` | Wszystkie komponenty renderowane i działające po stronie klienta (WebAssembly)           |
| **Blazor WebAssembly Standalone**              | `dotnet new blazorwasm`                         | Klasyczny Blazor WASM bez backendu                                                       |
| **Blazor WebAssembly Hosted**                  | `dotnet new blazorwasm --hosted`                | Frontend + backend w jednym rozwiązaniu                                                  |
