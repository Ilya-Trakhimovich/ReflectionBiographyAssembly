using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ReflectionBiography
{
    class BiographyAssembly
    {
        private Assembly _biographyAssembly;
        private Type _concreteType;
        private Type _attribute;

        public Type ConcreteType
        {
            get => _concreteType; 
        }

        public BiographyAssembly(string path)
        {
            _biographyAssembly = Assembly.LoadFrom(path);
        }

        public void TypesOfAssembly()
        {
            var types = _biographyAssembly.GetTypes();

            Console.WriteLine($"--- Types of {_biographyAssembly.FullName} ---");

            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);

                if (type.Name == "InfoMetadataAttribute")
                {
                    _attribute = type;
                }
            }

            Console.WriteLine();
        }

        public void SetConccreteType(string pathToType)
        {
            _concreteType = _biographyAssembly.GetType(pathToType, false, true);

            object obj = Activator.CreateInstance(_concreteType);

            var customAttribute = _concreteType.GetCustomAttribute(_attribute);

        }
    }
}
