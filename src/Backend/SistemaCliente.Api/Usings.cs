global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Diagnostics;

global using MediatR;

global using SistemaCliente.Infrastructure;
global using SistemaCliente.Infrastructure.Migrations;

global using SistemaCliente.Application;
global using SistemaCliente.Application.UseCases.Cliente.Registrar;
global using SistemaCliente.Application.UseCases.Cliente.RecuperarTodos;
global using SistemaCliente.Application.UseCases.Cliente.RecuperarPorId;
global using SistemaCliente.Application.UseCases.Cliente.Deletar;
global using SistemaCliente.Application.UseCases.Cliente.Atualizar;

global using SistemaCliente.Communication.Requisicoes.Cliente;
global using SistemaCliente.Communication.Respostas.Cliente;

global using SistemaCliente.Exceptions;