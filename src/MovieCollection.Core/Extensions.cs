using Microsoft.Extensions.DependencyInjection;

namespace MovieCollection.Models;

public static class Extensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {

        //services.AddScoped<IParentTypologyRepository, ParentTypologyRepository>();
        //services.AddScoped<IChildrenTypologyRepository, ChildrenTypologyRepository>();
        //services.AddScoped<IQuestionRepository, QuestionRepository>();
        //services.AddScoped<ISkillRepository, SkillRepository>();
        //services.AddScoped<ICallInfoRepository, CallInfoRepository>();

        ////services.AddScoped<ISMSService, InfobipSMSService>();
        //services.AddScoped<ISMSService, MasivSMSService>();


        return services;
    }
}