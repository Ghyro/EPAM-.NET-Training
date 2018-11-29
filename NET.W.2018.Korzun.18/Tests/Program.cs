using Ninject;
using System;
using Task.NinjectDependencyResolver;
using Task.BLL.Interfaces;
using Task.DAL.Interfaces;

namespace Tests
{
    class Program
    {
        private IKernel kernel = new NinjectConfiguration().Kernel;

        static void Main(string[] args)
        {
            new Program().Parsing();

            Console.ReadLine();
        }
            
        public void Parsing()
        {
            var xmlFileSource = this.kernel.Get<IFileSource>();

            var xmlCreator = this.kernel.Get<IXmlCreator>();

            var xmlSaver = this.kernel.Get<IXmlRepository>();

            var result = xmlCreator.CreateXml(xmlFileSource.GetRows());

            xmlSaver.Save(result);
        }
    }
}
