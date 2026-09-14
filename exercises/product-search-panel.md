# 🔍 Zadanie: Panel wyszukiwania i szczegóły produktów

## 🧩 Cel:

Twoim zadaniem jest rozbudowanie strony z listą produktów o możliwość filtrowania za pomocą parametrów w *query string* oraz stworzenie strony ze szczegółami produktu z obsługą parametrów trasy i opcjonalnego rabatu.
Celem zadania jest nauczenie się wyświetlania danych z repozytorium w formie tabeli w aplikacji Blazor.

---

## Wymagania funkcjonalne:

1. **Strona** `ProductList.razor`
- Wyświetla listę wszystkich produktów (np. z `IProductService`)
- Obsługuje filtrację po kolorze na podstawie query string:

**Przykład:**
```bash
/products?color=red
```

- Dla każdego produktu dodaj przycisk „Szczegóły”, który:
	- przekierowuje do `Product/View.razor`
	- przekazuje `productId` jako parametr trasy
	- przekazuje `discount=true` lub `false` jako *query string*

---

## 💡 Przykładowe adresy URL

`/products?color=red` — pokazuje produkty w kolorze czerwonym

`/products?1?discount=true` — pokazuje obniżoną cenę.

`/products/2?discount=false` — cena bez rabatu.

`/products/3` — brak rabatu, cena domyślna.

---


## ⏱️ Czas realizacji: **30 minut**


W razie pytań — zapytaj prowadzącego 🙂