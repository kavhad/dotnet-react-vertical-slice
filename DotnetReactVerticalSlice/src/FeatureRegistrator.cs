using System.Reflection;

namespace DotnetReactVerticalSlice;

internal static class FeatureRegistrator
{
    internal static void RegisterAllFeatures(this IServiceCollection serviceCollection)
    {
        //This method register all features dynamically.
        //It scans the current assembly for startup class types (a type that name ends with 'Startup') and which have a static method name 'Register' with 
        //a single parameter of type IServiceCollection and invokes it to register all it dependencies. 
        foreach (var methodInfo in typeof(Program).Assembly.GetTypes()
                     .Where(t => t.Name.EndsWith("Startup"))
                     .SelectMany(t => 
                         t.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic)
                             .Where(m => 
                                 m.Name == "Register" &&
                                 m.GetParameters().SingleOrDefault() is {} param && 
                                 param.ParameterType == typeof(IServiceCollection))
                     ))
        {
            methodInfo.Invoke(null, BindingFlags.Static, null, new object[]{ serviceCollection }, null);
        }
    }

}