using System;
using System.Reflection;
using Lesson21;

namespace ReflectionBiography
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly _biographyAssembly = Assembly.LoadFrom(@"C:\Users\пк\source\repos\Lesson21\Lesson21\bin\Debug\netcoreapp3.1\Lesson21.dll");

            Console.WriteLine($"--- Types of Bigraphy Assembly ---");

            var types = _biographyAssembly.GetTypes();

            foreach (var type in types)
            {
                Console.WriteLine($"{type.Name}");
            }

            Console.WriteLine();

            var biography = _biographyAssembly.GetType("Lesson21.Biography", false, true);
            var objBiography = Activator.CreateInstance(biography);

            var biographyFile = _biographyAssembly.GetType("Lesson21.BiographyFile", false, true);
            var objBiographyFile = Activator.CreateInstance(biographyFile);

            var attributes = biographyFile.GetCustomAttributes(false);

            var typeAttribute = attributes[0].GetType();

            Console.WriteLine($"--- Attributes of BiographyFile ---");

            foreach (var attr in attributes)
            {
                Console.WriteLine(attr);
            }

            Console.WriteLine();

            var properties = typeAttribute.GetProperties();

            Console.WriteLine("--- Properties of InfoMetadataAttribute ---");

            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name} - {property.GetValue(attributes[0])}");
            }

            Console.WriteLine();

            var CompressOrDecompressBio = biographyFile.GetMethod("CompressOrDecompressBio");
            CompressOrDecompressBio.Invoke(objBiographyFile, new object[] { objBiography, Mode.Deserialize});

            var objBioProperty = biographyFile.GetProperty("Biography");

            var GetBiography = biographyFile.GetMethod("GetBiography");
            GetBiography.Invoke(objBiographyFile, new object[] { objBioProperty.GetValue(objBiographyFile)});
        }
    }
}
