using System;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Nanny.Infrastructure
{
    public static class ObjectFactory
    {
        //public static string Get

        public static ModuleBuilder GetModuleBuilder(string assembly, out AssemblyBuilder assemblyBuilder)
        {
            AssemblyName myAssemblyName = new AssemblyName
            {
                Name = assembly,
                Version = new Version(1, 0, 0, 0)
            };

            assemblyBuilder = AppDomain
                .CurrentDomain
                .DefineDynamicAssembly(myAssemblyName, AssemblyBuilderAccess.RunAndSave);
            
            //AppDomain.CurrentDomain
            //    .Load(myAssemblyName);

            return assemblyBuilder.DefineDynamicModule(assemblyBuilder.GetName().Name, $"{assemblyBuilder.GetName().Name}.dll");
        }

        public static Type MakeFrom(ModuleBuilder moduleBuilder, Type sourceType, string typeName, out Type baseType, params Type[] generic)
        {
            var typeBuilder = moduleBuilder.DefineType(typeName, TypeAttributes.Public | TypeAttributes.Class);
            
            baseType = sourceType.MakeGenericType(generic);
            typeBuilder.SetParent(baseType);

            var baseCtor = baseType
                .GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance)
                .First();

            var ctorFieldTypes = ((TypeInfo)baseCtor.DeclaringType).DeclaredFields.Select(f => f.FieldType).ToArray();

            var ctor = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard | CallingConventions.HasThis, ctorFieldTypes);
            var ilGenerator = ctor.GetILGenerator();

            // i want to call the constructor of the baseclass with eventName as param
            ilGenerator.Emit(OpCodes.Ldarg_0); // push "this"
            ilGenerator.Emit(OpCodes.Ldstr, baseCtor); // push the param
            ilGenerator.Emit(OpCodes.Call, baseCtor);
            ilGenerator.Emit(OpCodes.Ret);

            return typeBuilder.CreateType();
        }
    }
}