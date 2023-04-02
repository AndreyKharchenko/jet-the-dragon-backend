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
    internal class AuthCustomerProvider : IAuthCustomerProvider
    {
        private readonly ILoginNameProvider _loginNameProvider;
        private readonly IRepository<Customer> _customerRepository;

        public AuthCustomerProvider(ILoginNameProvider loginNameProvider, IRepository<Customer> customerRepository)
        {
            _loginNameProvider = loginNameProvider;
            _customerRepository = customerRepository;
        }
        public Customer GetAuthCustomer()
        {
            var login = _loginNameProvider.CurrentLoginName;
            return _customerRepository.GetByExpression(a => a.Email == login).FirstOrDefault();
        }
    }
}
