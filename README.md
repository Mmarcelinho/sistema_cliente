Este projeto é um **sistema de cadastro da empresa dos clientes** . Ele utiliza uma abordagem de Clean Architecture, Domain-Driven Design (DDD), e o padrão CQRS com MediatR.

## Sobre o Projeto

O objetivo deste sistema é fornecer uma interface para gerenciar clientes, categorizando-os pelo porte da empresa e armazenando informações essenciais. O frontend foi desenvolvido em Angular, enquanto o backend foi construído em C# com .NET.

#### Técnicas utilizadas para a construção do projeto:

- Clean Architecture
- Domain-Driven Design (DDD)
- CQRS Pattern with MediatR
- SOLID Principles

## Build With

![Ubuntu](https://img.shields.io/badge/Ubuntu-E95420?style=for-the-badge&logo=ubuntu&logoColor=white)
![Visual Studio Code](https://img.shields.io/badge/Visual%20Studio%20Code-0078d7.svg?style=for-the-badge&logo=visual-studio-code&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![Angular](https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white)
![SqlServer](https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Swagger](https://camo.githubusercontent.com/6e4dd9644d5327ffad6433ecb2f4c0a8f41531fcfe142ae36d7e1cb162774fc3/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f537761676765722d3230354533423f7374796c653d666f722d7468652d6261646765266c6f676f3d73776167676572266c6f676f436f6c6f723d7768697465)


## Diagrama

![diagrama](images/diagrama_sistema_cliente.png)

## Features

### Cliente:

- [x] Cadastro de cliente
- [x] Atualização de dados do cliente
- [x] Listagem de clientes
- [x] Exclusão de cliente

## Como Executar

1. Clone o repositório.
2. Configure o banco de dados SQLServer.
3. Atualize as configurações do banco de dados no arquivo `appsettings.json`.
4. Execute as migrações do Entity Framework.
5. Inicie a aplicação backend em .NET.
6. Navegue até o diretório `frontend` e execute `npm install`.
7. Inicie a aplicação frontend com `ng serve`.

## Autores

[Marcelo](https://github.com/Mmarcelinho) é responsável pela criação e manutenção destes projetos.

## Licença

Este projeto não possui uma licença específica e é fornecido apenas para fins de aprendizado e demonstração.

