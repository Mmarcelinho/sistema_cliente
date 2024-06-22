global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using MediatR;

global using SistemaCliente.Infrastructure;
global using SistemaCliente.Infrastructure.Migrations;
global using SistemaCliente.Infrastructure.AcessoRepositorio;

global using SistemaCliente.Application;
global using SistemaCliente.Application.UseCases.Cliente.Commands.Registrar;
global using SistemaCliente.Application.UseCases.Cliente.Queries.RecuperarTodos;
global using SistemaCliente.Application.UseCases.Cliente.Queries.RecuperarPorId;
global using SistemaCliente.Application.UseCases.Cliente.Commands.Deletar;
global using SistemaCliente.Application.UseCases.Cliente.Commands.Atualizar;

global using SistemaCliente.Communication.Requisicoes.Cliente;
global using SistemaCliente.Communication.Respostas.Cliente;

global using SistemaCliente.Exceptions;


