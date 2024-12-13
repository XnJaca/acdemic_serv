using acdemic_serv.Utils;
using FluentValidation; 

namespace acdemic_serv.Extensions {
    public static class ValidationServiceExtensions {
        public static IServiceCollection AddValidationServices ( this IServiceCollection services ) {
            
            var fluentValidatorCamelCaseResolver = ( Type type, System.Reflection.MemberInfo member,
                System.Linq.Expressions.LambdaExpression expression ) => {
                    if ( member is not null ) {
                        return member.Name.ToCamelCase();
                    } 
                    return null;
                };
            ValidatorOptions.Global.DisplayNameResolver = fluentValidatorCamelCaseResolver;
            ValidatorOptions.Global.PropertyNameResolver = fluentValidatorCamelCaseResolver;
             
            services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()); 
            services.AddScoped(typeof(ValidationFilter<>)); 

            return services;
        }
    }
}
