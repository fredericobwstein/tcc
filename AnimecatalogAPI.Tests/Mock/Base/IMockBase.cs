using Moq;

namespace AnimecatalogAPI.Tests.Mock.Base
{
    public interface IMockBase<T> where T : class
    {
        public Mock<T> SetupQueries();
    }
}
