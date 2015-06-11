using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using Ninject;
using RegisterNotes.Domain.Abstract;
using RegisterNotes.Domain.Concrete;
using RegisterNotes.Domain.Entities;
using RegisterNotes.WebUI.Infrastructure.Abstract;
using RegisterNotes.WebUI.Infrastructure.Concrete;

namespace RegisterNotes.WebUI.Infrastructure {
    public class NinjectDependencyResolver : IDependencyResolver  {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            // Ninject to return the same mock object whenever it gets a request for an implementation of the IProductRepository interface, which is
            // why used the ToConstant method to set the Ninject scope, like this:
            // Rather than create a new instance of the implementation object each time, Ninject will always satisfy requests for
            // the IProductRepository interface with the same mock object.

            // Mock<INoteRepository> mock = new Mock<INoteRepository>();
            // mock.Setup(m => m.Notes).Returns(new List<Note> { 
            //    new Note { UserId = 1,  Title = "Football",       Body = "Football Football Football",                 CreateTime = DateTime.Now,  Pblc = "Public"},
            //    new Note { UserId = 3,  Title = "Surf board",     Body = "Surf board Surf board Surf board",           CreateTime = DateTime.Now,  Pblc = "Private"},
            //    new Note { UserId = 2,  Title = "Running shoes",  Body = "Running shoes Running shoes Running shoes",  CreateTime = DateTime.Now,  Pblc = "Public"}        
            //});            

            // kernel.Bind<INoteRepository>().ToConstant(mock.Object);

            // Adding the Real Repository Binding

            kernel.Bind<INoteRepository>().To<EFNoteRepository>();

            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}