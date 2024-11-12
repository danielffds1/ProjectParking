# Projeto de Estacionamento

Este projeto é um sistema de gerenciamento de estacionamento que permite registrar, consultar e gerenciar veículos. 
O sistema utiliza o Entity Framework e o Dapper para operações com banco de dados, oferecendo flexibilidade e eficiência no acesso aos dados.

## Índice

- [Descrição do Projeto](#descrição-do-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Configuração](#configuração)
  - [Pré-requisitos](#pré-requisitos)
  - [Instalação](#instalação)
- [Uso](#uso)
- [Contribuição](#contribuição)
- [Licença](#licença)

## Descrição do Projeto

Este sistema foi desenvolvido para facilitar o gerenciamento de veículos em um estacionamento. 
Ele permite registrar entradas e saídas de veículos, bem como realizar consultas a partir de dados como placa, modelo ou proprietário.

O sistema foi estruturado utilizando boas práticas de design de software, como o padrão Repository, 
e implementa uma camada de persistência com suporte ao Entity Framework e ao Dapper para diferentes necessidades de acesso ao banco de dados.

## Tecnologias Utilizadas

- .NET Core 6
- Entity Framework Core
- Dapper
- SQL Server
- Swagger

## Estrutura do Projeto

A estrutura principal do projeto inclui os seguintes diretórios:


### Principais Componentes

- **ParkingDbContext.cs**: Define o contexto do Entity Framework, gerenciando o acesso ao banco de dados.
- **VehicleRepository.cs**: Implementa a interface de repositório de veículos, utilizando tanto Entity Framework quanto Dapper.
- **Vehicle.cs**: Representa a entidade de veículo, que contém as principais propriedades como placa, modelo, cor, e horários de entrada e saída.

## Configuração

### Pré-requisitos

- .NET Core 6
- SQL Server Express

### Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/seu-usuario/nome-do-projeto.git
   cd nome-do-projeto

2 - Configure o banco de dados SQL Server Express. No arquivo appsettings.json, defina a string de conexão:

   ```json
   "ConnectionStrings": {
	 "ParkingDb": "Server=localhost;Database=Parking;Trusted_Connection=True;"
   }
   ```
3 - Instale as dependências e compile o projeto:
	dotnet restore
	dotnet build

4 - Execute as migrações para configurar o banco de dados:
dotnet ef database update

Uso
Para rodar o projeto, use o comando:
dotnet run

Acesse o Swagger para testar os endpoints:
https://localhost:5001/swagger/index.html

