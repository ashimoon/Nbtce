using NBtce;
using NBtce.Model;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Nbtce.Test
{
    [TestFixture]
    public class TradeReceiptSerializationTests
    {
        [Test]
        public void deserialize_sample_data()
        {
            const string sampleData = @"{
	            'success':1,
	            'return':{
		            'received':0.1,
		            'remains':0,
		            'order_id':0,
		            'funds':{
			            'usd':325,
			            'btc':2.498,
			            'sc':121.998,
			            'ltc':0,
			            'ruc':0,
			            'nmc':0
		            }
	            }
            }";

            var response = JsonConvert.DeserializeObject<ApiResponse<TradeReceipt>>(sampleData);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success);

            var receipt = response.Return;
            Assert.That(receipt, Is.Not.Null);
            Assert.That(receipt.Received, Is.EqualTo(0.1m));
            Assert.That(receipt.Remains, Is.EqualTo(0m));
            Assert.That(receipt.OrderId, Is.EqualTo(0));

            var funds = receipt.Funds;
            Assert.That(funds, Is.Not.Null);
            Assert.That(funds.Usd, Is.EqualTo(325m));
            Assert.That(funds.Btc, Is.EqualTo(2.498));
            // TODO: What is sc??
            Assert.That(funds.Ltc, Is.EqualTo(0m));
            // TODO: What is ruc?
            Assert.That(funds.Nmc, Is.EqualTo(0));
        }
    }
}