global using System.Net;
global using System.Text.Json;
global using System.Net.Http.Json;

global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using FluentAssertions;

global using CommonTestUtilities.Entidades;
global using CommonTestUtilities.Requisicoes;

global using SistemaCliente.Domain.Entidades;
global using SistemaCliente.Infrastructure.AcessoRepositorio;

global using SistemaCliente.Exceptions.MensagensDeErro;