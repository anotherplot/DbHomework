using HW.Migrator;
using Microsoft.Extensions.DependencyInjection;

using var serviceProvider = AppConfig.CreateServices();
using var scope = serviceProvider.CreateScope();
// Put the database update into a scope to ensure
// that all resources will be disposed.
AppConfig.UpdateDatabase(scope.ServiceProvider);
