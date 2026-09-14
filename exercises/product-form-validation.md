# ✅ Zadanie: Formularz dodawania produktu z walidacją

## 🧩 Cel:
Twoim zadaniem jest stworzenie formularza Blazor umożliwiającego dodanie nowego produktu. Formularz powinien zawierać walidację danych wejściowych z użyciem **DataAnnotations** lub **FluentValidation** (do wyboru). Ćwiczenie pozwala przećwiczyć poprawną obsługę walidacji i formularzy w aplikacjach Blazor.

---

## ✅ Wymagania funkcjonalne

1. Pola formularza:
Formularz powinien zawierać następujące pola:
- 🏷️ **Nazwa produktu** – wymagane, maksymalnie 20 znaków
- 🆔 **Kod produktu** – wymagany, zgodny z formatem `XXX-NNNNN` (np. `ABC-12345`)
- 🎨 **Kolor** – pusty lub wybrany z listy: `Red`, `Green`, `Blue`
- 💰 **Cena** – wymagana, większa niż `0`, maksymalna `1999.99`
- 📝 **Opis** – wymagany, maksymalnie 50 znaków
- 📅 **Data ważności** – wymagana, **data w przyszłości**

---

## 🧪 Walidacja
- Błędne dane powinny skutkować komunikatami o błędach pod odpowiednimi polami
- Formularz nie powinien się wysłać, dopóki wszystkie dane nie będą poprawne

Możesz wykorzystać:
- `EditForm` + `DataAnnotationsValidator`
- lub bibliotekę `FluentValidation` z Blazorem

---


## 🧾 Obsługa formularza

- Po poprawnym wypełnieniu formularza i kliknięciu przycisku „Zapisz”:
	- W konsoli (Console.WriteLine) powinien pojawić się komunikat:
```text
Produkt zapisany poprawnie!
```

- Nie zapisujemy danych do bazy ani pliku – skupiamy się na samej walidacji


## 🧠 Rozszerzenie (dla chętnych)
- Dodaj komponent `ValidationSummary` nad formularzem
- Dodaj dynamiczne podświetlenie poprawnych/pustych pól (klasa CSS `is-valid` / `is-invalid`)
- Zastosuj własne atrybuty walidujące (np. `ProductCodeAttribute`)

## ⏱️ Czas realizacji: 45 minut

W razie pytań — zapytaj prowadzącego 🙂