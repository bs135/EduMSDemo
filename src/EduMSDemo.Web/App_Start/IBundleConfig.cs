using System.Web.Optimization;

namespace EduMSDemo.Web
{
    public interface IBundleConfig
    {
        void RegisterBundles(BundleCollection bundles);
    }
}
