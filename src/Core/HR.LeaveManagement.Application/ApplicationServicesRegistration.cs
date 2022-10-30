namespace HR.LeaveManagement.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this 
      IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediaterR(Assembly.GetExecutingAssembly());

        return services;
    }
}
