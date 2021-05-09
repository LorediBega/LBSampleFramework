using LBSampleFramework.Domain.Concrete;
using LBSampleFramework.Domain.Interface;
using System.Web.Http;
using LBSampleFramework.DependencyInjection;
using LBSampleFramework.Entity;
using System;

namespace LBSampleFramework.Controllers
{
    public class SampleController : ApiController
    {
        private ITestDomain testDomain;
        public SampleController(IFactory factory)
        {
            testDomain = factory.GetDomain<TestDomain>();
        }

        // GET api/sample
        public IHttpActionResult Get()
        {
            try
            {
                SampleTable st = testDomain.GetFirst();

                return Ok(st);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
