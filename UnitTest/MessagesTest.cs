using Dto;
using Dto.Message;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using Xunit;

namespace UnitTest
{
    public class MessagesTest : IntegrationTestBuilder
    {
        [Fact]
        public void GetMessages()
        {
            var carga = this.TestClient.GetAsync("/api/Message/GetMessages").Result;
            carga.EnsureSuccessStatusCode();

            var content = carga.Content.ReadAsStringAsync().Result;
        }
    }
}