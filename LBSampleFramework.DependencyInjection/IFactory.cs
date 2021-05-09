using System;
using System.Collections.Generic;
using System.Text;

namespace LBSampleFramework.DependencyInjection
{
    public interface IFactory
    {
        TRepository GetRepository<TRepository>() where TRepository : class;
        TDomain GetDomain<TDomain>() where TDomain : class;
    }
}
