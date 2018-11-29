using Ninject;
using Task.BLL.BussinessModel;
using Task.BLL.Interfaces;
using Task.DAL.Interfaces;
using Task.DAL.Repository;

namespace Task.NinjectDependencyResolver
{
    public class NinjectConfiguration
    {       
        public NinjectConfiguration()
        {
            this.Kernel = new StandardKernel();

            this.Kernel.Bind<IXmlService>().To<IXmlService>();

            this.Kernel.Bind<IFileSource>().To<FileSource>();

            this.Kernel.Bind<IXmlRepository>().To<XmlRepository>();

            this.Kernel.Bind<IXmlCreator>().To<XmlCreator>();
        }

        public IKernel Kernel { get; set; }
    }
}
