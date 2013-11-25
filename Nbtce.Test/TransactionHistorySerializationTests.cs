using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBtce;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Nbtce.Test
{
    [TestFixture]
    public class TransactionHistorySerializationTests
    {
        [Test]
        public void deserialize_sample_trans_history()
        {
            string sampleData = @"{
	            'success':1,
	            'return':{
		            '1081672':{
			            'type':1,
			            'amount':1.00000000,
			            'currency':'BTC',
			            'desc':'BTC Payment',
			            'status':2,
			            'timestamp':1342448420
		            }
	            }
            }";

            var response = JsonConvert.DeserializeObject<ApiResponse<TransactionHistory>>(sampleData, new TransactionHistoryConverter());

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Success, Is.True);

            var history = response.Return;
            Assert.That(history, Is.Not.Null);
            Assert.That(history.Count, Is.EqualTo(1));

            var transaction = history[1081672];
            Assert.That(transaction, Is.Not.Null);
            Assert.That(transaction.Type, Is.EqualTo(1));
            Assert.That(transaction.Amount, Is.EqualTo(1.0m));
            Assert.That(transaction.Currency, Is.EqualTo("BTC"));
            Assert.That(transaction.Description, Is.EqualTo("BTC Payment"));
            Assert.That(transaction.Status, Is.EqualTo(2));
            Assert.That(transaction.Timestamp, Is.EqualTo(1342448420));
        }
    }
}
