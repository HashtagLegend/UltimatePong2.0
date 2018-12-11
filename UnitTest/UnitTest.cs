using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControlsUdpReciever;
using System.Net;


namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public async System.Threading.Tasks.Task TestSendReciverAsync()
        {
            string direction = "Test";
            string recieve = await ControlsUdpReciever.Program.SendControl(direction);
            Assert.AreEqual(HttpStatusCode.OK.ToString(), recieve);
            
        }
    }
}
