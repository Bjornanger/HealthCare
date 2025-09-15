# HealthCare

## Lagerhantering för medicinskt material – ASP.NET Core Blazor Web App

## 📌 Beskrivning
Denna applikation hanterar medicinskt material på ett lätt och intuitivt sätt genom enkla och beskrivande menyval.  
Användare kan:
- Registrera nytt material
- Uppdatera materials namn och enhetstyper
- Lägga beställningar när lagersaldot är lågt
- Plocka ut varor från lagret
- Avregistrera material som inte längre finns

Applikationen är byggd i **ASP.NET Core Blazor Server med .NET 8** och använder **Microsoft SQL Server** för datalagring.  
**Entity Framework Core** hanterar objektrelationell avbildning (ORM).  
**Swagger** används för att dokumentera och testa API‑endpoints.  

---

## 🔧 Funktioner

📦 **Lagerhantering**
- Registrera/skapa nya artiklar till lagret
- Uppdatera materialets namn och enhetstyp vid förändringar från leverantören
- Skapa nya enhetstyper, uppdatera deras namn och ta bort dem
- Om en enhetstyp tas bort och en artikel använder den, får artikeln en standardenhetstyp med namnet **"Åtgärd krävs"**
- Beställa nya artiklar av befintliga varor och automatiskt uppdatera lagersaldo
- Plocka ut artiklar och automatiskt uppdatera lagersaldo
- Färgvarning när lagersaldo närmar sig kritisk nivå (gul markering)
- Röd markering vid kritisk nivå
- Tydlig text **"Tillfälligt slut"** när en artikel är slut
- Förhindrar uttag av fler artiklar än vad som finns i lager, med tydlig varning
- Avregistrera produkter så att de försvinner helt från lagret

🔒 **Användarautentisering**
- Denna modul är en del av ett större system för vårdpersonal
- Ingen separat autentisering i denna modul

🏗️ **Modern arkitektur**
- **Blazor Server (.NET 8)**
- **Clean Architecture**
- **Designmönster**: Repository Pattern, Mapper Pattern
- **SOLID‑principer** för strukturerad och skalbar kod
- **Minimal API** istället för Controllers
- **Swagger** för test och dokumentation av API‑endpoints

---

## 🛠️ Tekniker och Verktyg
- **C# & .NET 8**
- **ASP.NET Core Blazor Server**
- **Entity Framework Core (ORM)**
- **Microsoft SQL Server**
- **HTML, CSS & Bootstrap**
- **Swagger**
- **Git (Versionshantering)**
- **Clean Architecture**

---

## 📌 Antaganden
- Applikationen används internt inom vårdorganisationen
- Användare har redan behörighet via det övergripande systemet
- Databasen är konfigurerad och tillgänglig vid installation
- Webbläsaren stöder moderna webbstandarder

---

## 🚀 Installation

### Förutsättningar
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Microsoft SQL Server
- Webbläsare som stöder moderna webbstandarder

### Konfiguration

Observera att `appsettings.json` inte ingår i repot av säkerhetsskäl.  
Skapa en egen `appsettings.json` i projektets rotmapp med följande struktur (anpassa värdena efter din miljö):

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "HealthCareConnection": ""
  }
}
