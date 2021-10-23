# Api Game Catalog

Desenvolveremos uma Web Api que consiste em um catálogo de Jogos usando ASP.NET Web Api. Começamos criando a estrutura inicial do projeto. Começamos abrindo o terminal em seguida criando o diretório da nossa aplicação, agora entramos neste diretório e finalizamos com o comando para gerar o projeto conforme mostramos a seguir:

```
mkdir ApiGameCatalog
cd ApiGameCatalog
dotnet new webapi
```
Com isto geramos a estrutura inicial do projeto.

Para executarmos a aplicação utilizamos os seguintes comandos:
```
dotnet build
dotnet run
```
Colocando no browser a url: ```https://localhost:5001/weatherforecast``` obtemos como retorno a seguinte lista
```
[
    {
        "date": "2021-10-23T22:38:41.0451643-03:00",
        "temperatureC": 41,
        "temperatureF": 105,
        "summary": "Bracing"
    },
    {
        "date": "2021-10-24T22:38:41.045465-03:00",
        "temperatureC": 47,
        "temperatureF": 116,
        "summary": "Warm"
    },
    {
        "date": "2021-10-25T22:38:41.0454672-03:00",
        "temperatureC": -12,
        "temperatureF": 11,
        "summary": "Scorching"
    },
    {
        "date": "2021-10-26T22:38:41.0454675-03:00",
        "temperatureC": 34,
        "temperatureF": 93,
        "summary": "Bracing"
    },
    {
        "date": "2021-10-27T22:38:41.0454678-03:00",
        "temperatureC": 29,
        "temperatureF": 84,
        "summary": "Balmy"
    }
]
```

Criação do controller com verbos Https get, post, put, patch e delete.