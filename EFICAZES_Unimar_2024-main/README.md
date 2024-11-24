# PROJETO FACULDADE

### Recriacao do projeto

**GABINE HEADSET**
**nome ficticio do nosso:** EFICAZES

---

![Banner do Projeto](<(frontend/src/assets/images/Capa.png)> "Imagem de capa do figma utilizado para recriação")

## 📚 **Descrição**

> Uma landpage do projeto GABINI HEADSET para um projeto da faculdade em conjunto com a empresa EFICAZ.
> Sistema de Login e criação de usuários com conexão ao banco de dados via MySQL através de entradas API em C#

---

## 🛠️ **Funcionalidades**

- ✅ Criação de Usuário
- ✅ Sistema de Autenticação utilizando TOKEN JWT
- ✅ Sistema de Login
- ✅ Sistema de Edição de informações do Usuário
- 🚧 Sistema de Auth - route protect em página (em desenvolvimento)

---

## 🚀 **Tecnologias Utilizadas**

- [Vue.js](https://vuejs.org/)
- [Vue Router](https://router.vuejs.org/)
- [Axios](https://router.vuejs.org/)
- [CSS](https://www.w3schools.com/cssref/index.php)
- [Tailwind](https://tailwindcss.com/)
- [C#](https://learn.microsoft.com/pt-br/dotnet/csharp/tour-of-csharp/overview)
- [Javascript](hhttps://developer.mozilla.org/pt-BR/docs/Web/JavaScript)

---

## 🖥️ Como Executar a parte do Front-end

### Clone este repositório:

```bash
git clone https://github.com/GoFDD/EFICAZES_Unimar_2024
```

### Acesse o diretório do projeto:

```bash
cd frontend
```

### Instale as dependências:

```bash
npm install
```

### Inicie a aplicação:

```bash
npm run dev
```

---

## 🖥️ Back-end

A estrutura do projeto é organizada em várias camadas, cada uma com responsabilidades bem definidas:

**Application:** Contém a lógica de negócios e serviços.

**Core:** Inclui as entidades de domínio, DTOs (Data Transfer Objects) e interfaces de repositórios.

**Infrastructure:** Gerencia a camada de dados, incluindo a configuração do Entity Framework Core, o contexto do banco de dados e as migrações.

**Presentation:** Contém a API Web, controladores e configurações da aplicação.

## Requisitos

Para executar o projeto, você precisará dos seguintes requisitos:

```bash
.NET SDK 8.0
MySQL
Ferramenta de linha de comando dotnet format e dotnet ef
```

## Conexão do Banco de Dados:

**Instruções para Configuração do Banco de Dados:**

1. Criar o Banco de Dados no MySQL

   - Abra o o MySQL e execute o seguinte comando para criar o banco de dados:
     CREATE DATABASE NOME_BANCO_AQUI;

2. Configurar a Conexão no Arquivo de Configuração

   - Navegue até a pasta Presentation e localize o arquivo chamado appsettings.json.
   - Abra o arquivo e localize a seção DefaultConnection. Atualize-a com as informações do seu banco de dados, exemplo:
     "DefaultConnection": "server=localhost;user id=root;password=SENHA_AQUI;database=NOME_BANCO_AQUI"

3. Atualizar o Banco de Dados com Entity Framework
   - No terminal, navegue até a pasta Infrastructure usando o comando:
     cd Infrastructure
   - Em seguida, execute o seguinte comando para aplicar as migrações e atualizar o banco de dados:
     dotnet ef database update -s ../Presentation/Presentation.csproj

---

## Grupo Eficazes

### Integrantes

```bash
Higor Miguel Pavim Lopes | RA ->1971780
Lucas Garcia Ribeiro | RA ->1971977
Luiz Fernando Ferreira do Carmo | RA ->1965671
João Victor Marque Seixas | RA ->1974858
Josué Miguel Ramos de Souza | RA ->1976990
Julio Cesar Golfredo Carneiro | RA ->1963824
```

---

## 📂 **Estrutura do Projeto - Necessario abrir o readme em um Editor de texto**

EFICAZES/
├── frontend/
│ ├── src/
│ │ ├── assets/
│ │ │ ├── Fonts/
│ │ │ ├── icons/
│ │ │ ├── images/
│ │ │ ├── fonts.css
│ │ │ └── tailwind.css
│ │ ├── components/
│ │ │ ├── AddressUser.vue
│ │ │ ├── BoxSwipe.vue
│ │ │ ├── Footer-Home.vue
│ │ │ ├── GiftSelection.vue
│ │ │ ├── Hero.vue
│ │ │ ├── Login.vue
│ │ │ ├── NavBar.vue
│ │ │ ├── NewProducts.vue
│ │ │ ├── Offer.vue
│ │ │ ├── ProductEmphasis.vue
│ │ │ ├── RegistrationUser.vue
│ │ │ └── UserProfile.vue
│ │ ├── router/
│ │ │ └── index.js
│ │ ├── services/
│ │ │ └── PostUserDataService.js
│ │ ├── stores/
│ │ │ └── auth.js
│ │ ├── views/
│ │ │ ├── AddressUserView.vue
│ │ │ ├── BoxSwipeView.vue
│ │ │ ├── FooterHomeView.vue
│ │ │ ├── GiftSelectionView.vue
│ │ │ ├── HeroView.vue
│ │ │ ├── HomePageView.vue
│ │ │ ├── LoginView.vue
│ │ │ ├── NavBarView.vue
│ │ │ ├── NewProductsView.vue
│ │ │ ├── OfferView.vue
│ │ │ ├── ProductEmphasisView.vue
│ │ │ ├── RegistrationUserView.vue
│ │ │ └── UserProfileView.vue
│ │ ├── App.vue
│ │ ├── http-common.js
│ │ └── main.js
│
├── backend/
│ ├── Application/
│ │ ├── Services/
│ │ │ ├── ClienteService.cs
│ │ │ └── EnderecoService.cs
│ ├── Core/
│ │ ├── DTO/
│ │ │ ├── ClienteDTO.cs
│ │ │ ├── EnderecoDTO.cs
│ │ │ └── SignInClienteDTO.cs
│ │ ├── Models/
│ │ │ ├── Cliente.cs
│ │ │ ├── Endereco.cs
│ │ │ └── Imagem.cs
│ │ ├── Repositories/
│ │ └── Services/
│ ├── Infrastructure/
│ │ ├── Repositories/
│ │ │ ├── AuthRepository.cs
│ │ │ ├── ClienteRepository.cs
│ │ │ ├── EnderecoRepository.cs
│ │ │ └── Data/
│ │ │ ├── EficazesDbContext.cs
│ │ │ └── Migrations/
│ │ └── Services/
│ │ └── ImagemService.cs
│ ├── Presentation/
│ │ ├── Controllers/
│ │ │ ├── AuthController.cs
│ │ │ ├── ClienteController.cs
│ │ │ └── EnderecoController.cs
│ │ └── Services/
│ │ ├── AuthService.cs
│ │ └── TokenService.cs
