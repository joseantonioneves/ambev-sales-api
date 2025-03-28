using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.IoC.ModuleInitializers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Ambev.DeveloperEvaluation.IoC;

public static class DependencyResolver
{
    public static void RegisterDependencies(this WebApplicationBuilder builder)
    {
        new ApplicationModuleInitializer().Initialize(builder); // Registra IsalesService
        new InfrastructureModuleInitializer().Initialize(builder); // Registra ISaleRepository
        new WebApiModuleInitializer().Initialize(builder);
    }
}