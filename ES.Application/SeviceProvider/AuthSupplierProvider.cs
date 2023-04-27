using ES.Application.Infrastructure;
using ES.Application.Services;
using ES.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ES.Application.SeviceProvider
{
    internal class AuthSupplierProvider : IAuthSupplierProvider
    {
        private readonly ILoginNameProvider _loginNameProvider;
        private readonly IRepository<Supplier> _supplierRepository;

        public AuthSupplierProvider(ILoginNameProvider loginNameProvider, IRepository<Supplier> supplierRepository)
        {
            _loginNameProvider = loginNameProvider;
            _supplierRepository = supplierRepository;
        }
        public Supplier GetAuthSupplier()
        {
            var login = _loginNameProvider.CurrentLoginName;
            return _supplierRepository.GetByExpression(a => a.Customer.Email == login).FirstOrDefault();
        }
    }
}
