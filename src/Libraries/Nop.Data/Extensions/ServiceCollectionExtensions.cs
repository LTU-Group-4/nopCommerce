using System;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using Nop.Data.Migrations;

namespace Nop.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds NopCommerce database engines
        /// </summary>
        public static IMigrationRunnerBuilder AddNopDbEngines(this IMigrationRunnerBuilder builder)
        {
            return builder.AddSqlServer()
                          .AddMySql5()
                          .AddPostgres();
        }
    }
}