using ClientPoint.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests {
    [TestClass]
    public class ApiFixture {
        [TestMethod]
        public void LoadAdvertising() {
            var res = ApiQuery.LoadAdvertising();
            Assert.IsNotNull(res);
        }
    }
}
