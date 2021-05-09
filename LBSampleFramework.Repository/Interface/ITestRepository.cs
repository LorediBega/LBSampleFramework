using LBSampleFramework.Entity;

namespace LBSampleFramework.Repository.Interface
{
    public interface ITestRepository
    {
        SampleTable GetFirst();
    }
}
