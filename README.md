
# **Projeto RPA + Web API**

</br>

🔹 ****Descrição****

Este projeto combina **RPA (Worker/Console App)** e uma **API RESTful**.

- O **RPA** automatiza a coleta de notícias de sites específicos.
- A **API** disponibiliza os dados coletados em formato JSON, permitindo que outras aplicações consumam essas informações.

</br>

🛠 ****Tecnologias utilizadas****

- **.NET 8** → Backend e API
- **Entity Framework Core** → Banco de dados SQLite
- **SQLite** → Armazenamento local das notícias
- **RPA / Worker Service** → Automação da coleta de notícias
- **HttpClient** → Consumo de dados via scraping (coletar/extrair)
- **Swagger** → Documentação da API

</br>

⚙️ ****Estrutura do projeto****

Solution: **DesafioTecnicoRPA**

- Projeto: **Api**
    - **Controllers/NoticiaController.cs** → Endpoints para acessar notícias
    - **Program.cs** → Configuração de entrada de entrada do servidor web
    - **Properties/launchSettings.json** → Configuração inicial do ambiente de desenvolvimento
    - **Dockerfile.cs** → Criar uma imagem (pacote) docker

- Projeto: **Core**
    - **Entities/Noticia.cs** → Modelos de dados
    - **Interfaces/INoticiaRepository.cs** → Interfaces do repositório

- Projeto: **Infrastructure**
    - **Data/AppDbContext.cs** → Configuração do banco de dados
    - **Repositories/NoticiaRepository.cs** → Implementação do repositório

- Projeto: **Worker**
    - **Services/ScraperService.cs** → Implementação do serviço de scraping (coletar/extrair)
    - **Workers/ScraperWorker.cs** → Worker que executa a coleta periodicamente
    - **Program.cs** → Configuração de entrada do serviço em background
    - **Dockerfile.cs** → Criar uma imagem (pacote) docker

</br>

🔹 ****Explicação das camadas****

- **Core** → contém entidades, interfaces e regras de negócio da aplicação. Não depende de nada além de si mesma.

- **Infrastructure** → contém implementações concretas, como acesso ao banco de dados e serviços externos. Depende do Core.

- **API** → expõe os endpoints HTTP e referencia Core + Infrastructure.

- **RPA/Workers** → automatiza tarefas recorrentes, como scraping, usando serviços da Infrastructure.

</br>

📝 ****Funcionalidades****

- **RPA**
  - Acessa sites de notícias automaticamente
  - Extrai título, url e data de notícias
  - Armazena os dados no SQLite

- **API**
  - Retorna todas as notícias
  - Permite filtrar as 5 primeiras notícias
  - Documentação interativa com Swagger

</br>

🚀 ****Como rodar o projeto****

    1. Clone o repositório:
        - git clone https://github.com/usuario/projeto-rpa-api.git
  
    2. Abra o projeto no Visual Studio / VS Code

    3. Configure o caminho do banco de dados no Program.cs:
        - var dbPath = @"C:\Caminho\Para\Noticia.db";

    4. Execute a aplicação:
        - dotnet run

    5. Acesse a API:
        - http://localhost:5000/api/noticias

    6. Acesse a API:
        - http://localhost:5000/swagger

</br>

📦 ****Dependências****

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.Extensions.Hosting
- Swashbuckle.AspNetCore (Swagger)

</br>

📫 ****Melhorias****

- Retornar as urls exatas de cada notícia gravada no banco de dados.
- Estruturar uma pasta na hora que o banco de dados Noticia.db for criado.

</br>

🛡 ****Autor****

- Linkedin: [@rodrigoohashi](https://www.linkedin.com/in/rodrigoohashi/)
- Github: [@rodrigo-ohashi](https://github.com/rodrigo-ohashi)

