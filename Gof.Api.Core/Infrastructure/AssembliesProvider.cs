using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Linq;
using System.Runtime.Loader;

namespace Gof.Api.Core.Infrastructure
{         
    public interface IAssembliesProvider
    {
        IEnumerable<Assembly> Assemblies { get; }
    }

    public class AssembliesProvider : IAssembliesProvider
    {
        private static readonly IAssembliesProvider Singleton = new AssembliesProvider();

        private static readonly object SyncLock = new object();
        private static IEnumerable<Assembly> _assemblies;

        public static IAssembliesProvider Instance
        {
            get { return Singleton; }                              
        }

        public IEnumerable<Assembly> Assemblies
        {
            get
            {
                if (_assemblies != null)
                {
                    return _assemblies;
                }

                var available = AvailableAssemblies();

                lock (SyncLock)
                {
                    if (_assemblies == null)
                    {
                        _assemblies = available;
                    }
                }

                return _assemblies;
            }
        }

        private static IEnumerable<Assembly> AvailableAssemblies()
        {            
             return ConsoleAssemblies();
        }

        private static IEnumerable<Assembly> ConsoleAssemblies()
        {
            var path = Path.GetDirectoryName(
                Assembly.GetExecutingAssembly().Location);

            if (path == null)
            {
                throw new InvalidOperationException("Unable to get directory location.");
            }

            var files = Directory.GetFiles(path, "Gof.Api.*.dll");

            var allAssemblies = files.Select(LoadAssemblyFile).ToList();

            allAssemblies.Add(Assembly.GetEntryAssembly());

            var result = allAssemblies.Where(a => a != null).Distinct().OrderBy(a => a.FullName).ToList();
            return result;
        }
        private static Assembly LoadAssemblyFile(string path)
        {
            try
            {
                return AssemblyLoadContext.Default.LoadFromAssemblyPath(path);                
            }
            catch (Exception ex)
            {
                Trace.TraceError("Error while loading asembly file: {0}. Exception: '{1}'. {2}", path, ex.GetType().FullName, ex.Message);
                throw;
            }
        }
    }
}