<div align="center">

<img src="ProjetoFinal/Resources/CRM_Logo_1.png" alt="Logo CRM Jardinagem" width="120"/>

# 🌿 CRM para Empresas de Jardinagem

Aplicação desktop em **C# WinForms** para gestão de clientes, serviços e finanças de uma empresa de jardinagem — com painéis distintos para **Administrador** e **Utilizador**, gráficos de faturação e persistência de dados em XML.

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![WinForms](https://img.shields.io/badge/Windows%20Forms-0078D6?style=for-the-badge&logo=windows&logoColor=white)
![XML](https://img.shields.io/badge/Dados-XML-orange?style=for-the-badge&logo=xml&logoColor=white)

</div>

---

## 📖 Sobre o projeto

Este projeto foi desenvolvido como **trabalho final** e simula um sistema de **CRM (Customer Relationship Management)** dedicado a pequenas empresas de jardinagem. Permite gerir a carteira de clientes, registar os serviços prestados a cada um (com data, descrição, valor e notas) e acompanhar a saúde financeira do negócio através de um dashboard com gráficos.

O sistema tem **dois tipos de acesso**, cada um com o seu próprio conjunto de permissões:

| Perfil | Acesso |
|---|---|
| 👑 **Administrador** | Gestão total: criar, editar e eliminar clientes e serviços, consultar finanças e análises detalhadas por cliente |
| 👤 **Utilizador (Funcionário)** | Acesso de consulta: ver clientes, pesquisar e consultar o histórico de serviços |

---

## ✨ Funcionalidades

- 🔐 **Autenticação** com validação de utilizador/palavra-passe e níveis de acesso (Admin / User)
- 🏠 **Dashboard (Home)** com totais em tempo real: nº de clientes, nº de serviços realizados e cidades servidas
- 👥 **Gestão de Clientes** — adicionar, editar, eliminar e pesquisar clientes por nome
- 🧾 **Gestão de Serviços** — associar serviços a clientes com data, descrição, valor e notas, com validação de formato de data e de campos obrigatórios
- 💰 **Painel de Finanças** — receita total, análise de serviços por cliente (DataGridView) e **gráfico de faturação mensal** (linha temporal)
- 💾 **Persistência em XML** — os dados são guardados localmente em `CRM.xml` (clientes/serviços) e `Users.xml` (utilizadores), sem necessidade de servidor de base de dados
- 🧱 **Arquitetura orientada a objetos** — hierarquia de classes com herança (`Pessoa` → `Cliente` / `Utilizador`) e construtores sobrecarregados

---

## 🖼️ Capturas de ecrã

<div align="center">

**Painel de Login**

<img width="400" alt="Painel Login" src="https://github.com/user-attachments/assets/f1dadffc-6fa2-4f50-9744-af524356a2ad" />

**Painel Home**

<img width="600" alt="Painel Home" src="https://github.com/user-attachments/assets/7700c158-805b-4ab0-a3fb-536927ad6016" />


**Painel Clientes**

<img width="600" alt="Painel Clientes" src="https://github.com/user-attachments/assets/5343e4e1-5516-438d-be20-1d8dafad8e25" />


**Painel Serviços**

<img width="600" alt="Painel Serviços" src="https://github.com/user-attachments/assets/e4c17fa9-5f87-4c8a-920d-3cf0b69a99c1" />


**Painel Finanças**

<img width="600" alt="Painel Finanças" src="https://github.com/user-attachments/assets/d28cf5e6-f232-4ad7-8c17-b40d744e582c" />

</div>

---

## 🛠️ Tecnologias utilizadas

- **C#** (.NET Framework 4.8)
- **Windows Forms** para a interface gráfica
- **System.Windows.Forms.DataVisualization.Charting** para os gráficos de faturação
- **LINQ to XML** (`System.Xml.Linq`) para leitura e escrita dos dados
- **XmlSerializer** para serialização dos utilizadores

## 📁 Estrutura do projeto

```
CRM-para-Empresas-de-Jardinagem/
├── ProjetoFinal.sln              # Solução do Visual Studio
└── ProjetoFinal/
    ├── Program.cs                # Ponto de entrada da aplicação
    ├── Login.cs                  # Ecrã de autenticação
    ├── PainelAdmin.cs            # Dashboard do Administrador
    ├── PainelClientes.cs         # CRUD de clientes (Admin)
    ├── PainelServicos.cs         # CRUD de serviços (Admin)
    ├── PainelFinancas.cs         # Análises e gráfico de faturação
    ├── User_PainelHome.cs        # Dashboard do Utilizador
    ├── User_PainelClientes.cs    # Consulta de clientes (User)
    ├── User_PainelServicos.cs    # Consulta de serviços (User)
    ├── Pessoa.cs                 # Classe base (herança)
    ├── Cliente.cs                # Cliente (herda de Pessoa)
    ├── Utilizador.cs             # Utilizador do sistema (herda de Pessoa)
    ├── Servico.cs                # Modelo de serviço prestado
    ├── GestorXML.cs              # Camada de persistência (leitura/escrita XML)
    └── Resources/                # Ícones e imagens da interface
```

---

## 🚀 Como executar

### Pré-requisitos

- **Windows** com [.NET Framework 4.8](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net48) instalado
- **Visual Studio 2019/2022** (ou superior) com a carga de trabalho "Desenvolvimento para desktop com .NET"

### Passos

1. Clonar o repositório:
   ```bash
   git clone https://github.com/rafaellopes03/CRM-para-Empresas-de-Jardinagem.git
   ```
2. Abrir o ficheiro **`ProjetoFinal.sln`** no Visual Studio
3. Definir `ProjetoFinal` como projeto de arranque (se necessário)
4. Compilar e executar com **F5**

> Na primeira execução, o sistema cria automaticamente um ficheiro `Users.xml` com duas contas de teste:

| Utilizador | Password | Perfil |
|---|---|---|
| `admin` | `admin1234` | Administrador |
| `user` | `user1234` | Utilizador |

---

## 🧠 Conceitos de POO aplicados

Este projeto foi também um exercício de **Programação Orientada a Objetos**, aplicando:

- **Herança** — `Cliente` e `Utilizador` derivam de `Pessoa`
- **Encapsulamento** — propriedades com getters/setters e listas encapsuladas (`HistoricoServicos`)
- **Sobrecarga de construtores** — construtores vazios (para serialização XML) e construtores parametrizados
- **Propriedades calculadas** — conversão de `string` para `DateTime`/`decimal` sob pedido (`Data`, `Valor`)

---

## 👤 Autor

Desenvolvido por [**Rafael Lopes**](https://github.com/rafaellopes03) e Gonçalo Chora

---

<div align="center">

Se este projeto te foi útil, considera deixar uma ⭐!

</div>
