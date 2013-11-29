using NBtce;
using NBtce.Model;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Nbtce.Test
{
    [TestFixture]
    public class CancelResponseSerializationTests
    {
        [Test]
        public void deserialize_sample_data()
        {
            const string sampleData = @"{
	            'success':1,
	            'return':{
		            'order_id':343154,
		            'funds':{
			            'usd':325,
			            'btc':24.998,
			            'sc':121.998,
			            'ltc':0,
			            'ruc':0,
			            'nmc':0
		            }
	            }
            }";

            var response = JsonConvert.DeserializeObject<ApiResponse<CancelResponse>>(sampleData);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success);

            var cancel = response.Return;
            Assert.That(cancel, Is.Not.Null);
            Assert.That(cancel.OrderId, Is.EqualTo(343154));
            
            var funds = cancel.Funds;
            Assert.That(funds, Is.Not.Null);
            Assert.That(funds.Usd, Is.EqualTo(325m));
            Assert.That(funds.Btc, Is.EqualTo(24.998m));
            // TODO: What is sc??
            Assert.That(funds.Ltc, Is.EqualTo(0m));
            // TODO: What is ruc?
            Assert.That(funds.Nmc, Is.EqualTo(0m));
        }

    }
}