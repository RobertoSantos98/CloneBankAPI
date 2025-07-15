# CloneBankAPI 🏦

Um backend desenvolvido em ASP.NET Core com Entity Framework que simula funcionalidades básicas de um sistema bancário, inspirado no Desafio PicPay.

## 🚀 Funcionalidades

- 📌 Cadastro e login de usuários
- 💼 Criação de contas bancárias (Corrente ou Poupança)
- 🔁 Transferência de valores entre contas
- 🔎 Consulta de saldo e extrato
- 🧾 Histórico de transações

## 🛠️ Tecnologias Utilizadas

- [.NET 8](https://dotnet.microsoft.com/)
- [Entity Framework Core](https://learn.microsoft.com/ef/)
- [PostgreSQL](https://www.postgresql.org/)
- [Swagger](https://swagger.io/) para documentação da API
- [JWT](https://jwt.io/) para autenticação

## 📂 Estrutura de Pastas

```
CloneBankAPI/
├── Application/       # Regras de negócio e serviços
├── Controllers/       # Endpoints da API
├── Domain/            # Entidades e enums
├── Infrastructure/    # Acesso a dados (Repositories, Migrations)
├── Models/            # Models de requisição/resposta e response padrão
├── Program.cs         # Ponto de entrada da aplicação
└── appsettings.json   # Configurações da aplicação
```

## 📦 Como Executar Localmente

1. **Clone o repositório:**

```bash
git clone https://github.com/RobertoSantos98/CloneBankAPI.git
cd CloneBankAPI
```

2. **Configure o `appsettings.json`:**

Adicione sua string de conexão com o PostgreSQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=clonebank;Username=seu_usuario;Password=sua_senha"
}
```

3. **Execute as migrações:**

```bash
dotnet ef database update
```

> Certifique-se de ter o pacote `dotnet-ef` instalado globalmente.

4. **Execute a aplicação:**

```bash
dotnet run
```

A API estará disponível em `https://localhost:5001` ou `http://localhost:5000`.

## 📑 Documentação da API

Acesse a documentação interativa gerada pelo Swagger em:

```
https://localhost:5001/swagger
```

## 🧪 Testes

> *(Adicionar aqui instruções sobre testes, se forem incluídos futuramente.)*

## 🤝 Contribuições

Contribuições são bem-vindas! Sinta-se livre para abrir issues ou enviar pull requests.

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

Desenvolvido com 💻 por [Roberto Santos](https://github.com/RobertoSantos98)
