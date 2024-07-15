global using System.Data;
global using Microsoft.Data.SqlClient;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;

global using Dapper;

global using SistemaCliente.Domain.Entidades;
global using SistemaCliente.Domain.Repositorios;
global using SistemaCliente.Domain.Repositorios.Cliente;

global using SistemaCliente.Infrastructure.AcessoRepositorio;
global using SistemaCliente.Infrastructure.AcessoRepositorio.Queries;
global using SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.Dapper;
global using SistemaCliente.Infrastructure.AcessoRepositorio.Repositorio.EF;
global using SistemaCliente.Infrastructure.Factory;

