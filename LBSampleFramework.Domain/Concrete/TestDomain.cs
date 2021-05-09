using LBSampleFramework.Domain.Interface;
using LBSampleFramework.DependencyInjection;
using LBSampleFramework.Repository.Interface;
using LBSampleFramework.Entity;

namespace LBSampleFramework.Domain.Concrete
{
    public class TestDomain : ITestDomain
    {
        private ITestRepository TestRepository;
        public TestDomain(IFactory factory)
        {
            TestRepository = factory.GetRepository<ITestRepository>();
        }

        public SampleTable GetFirst()
        {
            return TestRepository.GetFirst();
        }
    }
}
