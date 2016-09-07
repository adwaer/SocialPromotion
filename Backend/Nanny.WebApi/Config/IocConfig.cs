using System;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Web.Http;
using Adwaer.Identity;
using Adwaer.Identity.Config;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Nanny.Commands;
using Nanny.Cqrs;
using Nanny.Dal;
using Nanny.DicApi;
using Nanny.Domain.Entities;
using Nanny.Domain.Entities.Base;
using Nanny.Domain.Entities.Localization;
using Nanny.Infrastructure;
using Nanny.Queries;
using Nanny.WebApi.Identity;

namespace Nanny.WebApi.Config
{
    public class IocConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder
                .RegisterType<DefaultCtx>()
                .As<DbContext>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<SaveCommand>()
                .AsSelf()
                .InstancePerRequest();

            builder.RegisterType<SendEmailCommand>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<SaveLangResourceCommand>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IQuery<,,,>))
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IQuery<,,>))
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IQuery<,>))
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .AsClosedTypesOf(typeof(IQuery<>))
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
                .As<IQuery>()
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterType<OnCreateUserAction>()
                .As<IOnCreateUserAction<SimpleCustomerAccount>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Scope>()
                .As<IScope>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TypeCache<DomainCultureQuery, string, LangCulture[]>>()
                .AsSelf()
                .SingleInstance();

            builder
                .Register(c => DtoMapping.Register())
                .Keyed<IMapper>("identityMapping")
                .As<IMapper>()
                .SingleInstance();

            IdentityConfig<SimpleCustomerAccount, UserRole>.Ioc(builder);


            //var typeDictionaryEntity = typeof(DictionaryEntity);
            //var types = Assembly
            //    .GetAssembly(typeDictionaryEntity)
            //    .GetTypes()
            //    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeDictionaryEntity));

            //AssemblyBuilder assemblyBuilder;
            //var moduleBuilder = ObjectFactory.GetModuleBuilder("Nanny.DictionaryApi", out assemblyBuilder);

            //Type apiType = null;
            //foreach (var type in types)
            //{
            //    Type baseType;
            //    apiType = ObjectFactory.MakeFrom(moduleBuilder, typeof(AbstractApi<>),
            //        $"Nanny.DictionaryApi.Controllers.{type.Name}Controller", out baseType, type);

            //    builder.RegisterType(apiType)
            //        .Named<ApiController>($"{type.Name}s", baseType);
            //}

            //if (apiType != null)
            //{


            //    builder.RegisterAssemblyTypes(apiType.Assembly)
            //        .Where(t => !t.IsAbstract && typeof (AbstractApi<>).IsAssignableFrom(t))
            //        .InstancePerMatchingLifetimeScope();
            //}
            //assemblyBuilder.Save("aaaaaaaaa.dll");

            //var type1 = System.Type.GetType("Nanny.DictionaryApi.Controllers.LanguageController");

            //builder.RegisterApiControllers(apiType.Assembly);
            builder.RegisterApiControllers(Assembly.GetCallingAssembly(), Assembly.GetExecutingAssembly());

            return builder.Build();
        }
    }
}
