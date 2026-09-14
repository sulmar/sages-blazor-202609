# 🛍️ Zadanie: Strona produktu z podglądem i kodem QR

## 🧩 Cel:

Twoim zadaniem jest stworzenie strony prezentującej informacje o produkcie w formie prostej *landing page*. Strona ma zawierać podstawowe dane o produkcie, a opcjonalnie – również wygenerowany kod QR z linkiem do strony produktu.
Celem zadania jest nauczenie się budowy komponentów w Blazorze oraz przekazywania danych.

---

## ✅ Wymagania funkcjonalne:

1. **Utwórz stronę** Blazor `Pages/Products/View.razor`
2. Na stronie **umieść podstawowe informacje o produkcie**:
- Nazwa produktu `Name`
- Opis `Description`
- Cena `Price`
3. **Wyświetl zdjęcie produktu** na podstawie pola `ImageUrl`


## 🧠 Rozszerzenie (dla chętnych):

- Dodaj komponent `QrCode.razor`, który umożliwi wyświetlenie kodu QR zawierającego link do strony produktu.
- Dodaj parametr `Value` –  zawartość kodu QR (np. pełny adres URL strony produktu)
- Dodaj parametr `Size` *(opcjonalny)* – rozmiar wygenerowanego kodu QR w pikselach (domyślnie `200`)


### 👉 Do wygenerowania kodu QR użyj zewnętrznego API 
```bash
https://api.qrserver.com/v1/create-qr-code/?data=...&size=...
```

### 💡 Przykład użycia komponentu QR:

```razor
<QrCode Value="https://twojadomena.pl/products/123" Size="150" />
```


## 📌 Wskazówki
- Do testów możesz zakodować dowolną przykładową stronę produktu 
(np. `https://localhost:5001/products/abc123`)

- Komponent `QrCode.razor` może generować `<img>` z odpowiednim adresem URL API jako źródłem

---


## ⏱️ Czas realizacji: **45 minut**


W razie pytań — zapytaj prowadzącego 🙂