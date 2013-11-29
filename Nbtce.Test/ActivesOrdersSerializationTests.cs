using NBtce;
using NBtce.Model;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Nbtce.Test
{
    [TestFixture]
    public class ActivesOrdersSerializationTests
    {
        [Test]
        public void deserialize_sample_data()
        {
            const string sampleData = @"{
	            'success':1,
	            'return':{
		            '343152':{
			            'pair':'btc_usd',
			            'type':'sell',
			            'amount':1.00000000,
			            'rate':3.00000000,
			            'timestamp_created':1342448420,
			            'status':0
		            }
	            }
            }";

            var response = JsonConvert.DeserializeObject<ApiResponse<ActiveOrders>>(sampleData);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success);

            var orders = response.Return;
            Assert.That(orders, Is.Not.Null);
            Assert.That(orders.Count, Is.EqualTo(1));

            var order = orders[343152];
            Assert.That(order, Is.Not.Null);
            Assert.That(order.TradingPair, Is.EqualTo(TradingPair.BtcUsd));
            Assert.That(order.Type, Is.EqualTo(TradeType.Sell));
            Assert.That(order.Amount, Is.EqualTo(1m));
            Assert.That(order.Rate, Is.EqualTo(3m));
            Assert.That(order.TimestampCreated, Is.EqualTo(1342448420));
            Assert.That(order.Status, Is.EqualTo(0));
        }
    }
}