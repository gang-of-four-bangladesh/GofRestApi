using System;
using System.Linq;
using System.Collections.Generic;
using Autofac;

namespace Gof.Test.Console.Funcs
{
    public class FuncYouUp
    {
        static List<Func<string>> funcs = new List<Func<string>>();
        public static void RegisterFunc(Func<string> func)
        {
            funcs.Add(func);
        }

        public static void Register<T>(Func<IComponentContext, T> input) where T : class
        {
            //System.Console.WriteLine(typeof(T));
        }

        public static void Execute()
        {

            Func<int> aFunctionWithNoParameter = () =>
            {
                return 10;
            };

            //System.Console.WriteLine(aFunctionWithNoParameter());

            Func<int, int> aSquareFunction = (int data) => data * data;
            //System.Console.WriteLine(aSquareFunction(10));

            Func<string, Customer> aBuildCustomerFunction = (string data) =>
            {
                var customer = new Customer();
                customer.Name = data;
                return customer;
            };
            //System.Console.WriteLine(aBuildCustomerFunction("Gang").Name);

            Func<Type, object> aGenericFunction = (Type type) =>
            {
                var typeOfSendType = type.GetType();
                object convertedType = (object)type;
                return convertedType;
            };
            //System.Console.WriteLine(aGenericFunction(typeof(Customer)).ToString());

            Func<string> toRegisterFunc = () => "Registered";
            RegisterFunc(toRegisterFunc);
            var funType = funcs.First()();
            //System.Console.WriteLine(funType);
            
            Register<Func<Type, object>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();
                System.Console.WriteLine(c);
                System.Console.WriteLine("XX");
                System.Console.WriteLine(ctx);
                return ctx.Resolve;
            });
        }
    }

    public class Customer
    {
        public string Name { get; set; }
    }
}