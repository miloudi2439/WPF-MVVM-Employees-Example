using MVVM_FIRST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Model
{
    public class UnitOfWork : IDisposable
    {
        private WorkDbContext _Context = new WorkDbContext();
        private GenericRepository<Enterprise> _EnterprisesRepository;
        private GenericRepository<User> _UsersRepository;
        private EmployeesRepository<Employee> _EmployeesRepository;

        public GenericRepository<Enterprise> EnterprisesRepository
        {
            get
            {

                if (_EnterprisesRepository == null)
                {
                    _EnterprisesRepository = new GenericRepository<Enterprise>(_Context);
                }
                return _EnterprisesRepository;

            }
        }

        public GenericRepository<User> UsersRepository
        {
            get
            {

                if (_UsersRepository == null)
                {
                    _UsersRepository = new GenericRepository<User>(_Context);
                }
                return _UsersRepository;

            }
        }


        public EmployeesRepository<Employee> EmployeesRepository
        {
            get
            {

                if (_EmployeesRepository == null)
                {
                    _EmployeesRepository = new EmployeesRepository<Employee>(_Context);
                }
                return _EmployeesRepository;

            }
        }
        public void Save()
        {
            _Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

