using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace UnitTests
{
    public sealed class LoadTest
    {
        [Test] public void TestLoadChangedAssemblyVersion()
        {
            var assembly = GetType().Assembly;
            var assemblyName = assembly.GetName();
            var newAssemblyName = new AssemblyName(assemblyName.FullName.Replace(assemblyName.Version.ToString(), new Version(1,2,3).ToString()));
            Assert.Throws<FileLoadException>(() => Assembly.Load(newAssemblyName));
        }
    }
}