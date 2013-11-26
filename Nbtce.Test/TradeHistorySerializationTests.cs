using NBtce;
using NBtce.Model;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Nbtce.Test
{
    [TestFixture]
    public class TradeHistorySerializationTests
    {
        [Test]
        public void deserialize_sample_trade_history()
        {
            const string sampleData = @"{
	            'success':1,
	            'return':{
		            '166830':{
			            'pair':'btc_usd',
			            'type':'sell',
			            'amount':1,
			            'rate':1,
			            'order_id':343148,
			            'is_your_order':1,
			            'timestamp':1342445793
		            }
	            }
            }";
            
            var response = JsonConvert.DeserializeObject<ApiResponse<TradeHistory>>(sampleData);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success, Is.True);

            var history = response.Return;
            Assert.That(history, Is.Not.Null);
            Assert.That(history.Count, Is.EqualTo(1));
        }
    }
}