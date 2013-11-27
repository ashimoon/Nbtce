using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBtce;
using NBtce.Model;
using NUnit.Framework;
using Newtonsoft.Json;

namespace Nbtce.Test
{
    [TestFixture]
    public class UserInfoSerializationTests
    {
        [Test]
        public void deserialize_sample_user_info()
        {
            string sampleData = @"{
	            'success':1,
		            'return':{
		            'funds':{
			            'usd':325,
			            'btc':23.998,
			            'sc':121.998,
			            'ltc':0,
			            'ruc':0,
			            'nmc':0
		            },
		            'rights':{
			            'info':1,
			            'trade':1
		            },
		            'transaction_count':80,
		            'open_orders':1,
		            'server_time':1342123547
	            }
            }";

            var deserialized = JsonConvert.DeserializeObject<ApiResponse<UserInfo>>(sampleData);

            Assert.That(deserialized.Success, Is.True);
            Assert.That(deserialized.ErrorText, Is.Null);
            Assert.That(deserialized.Return, Is.Not.Null);

            var funds = deserialized.Return.Funds;
            Assert.That(funds, Is.Not.Null);
            Assert.That(funds.Usd, Is.EqualTo(325m));
            Assert.That(funds.Btc, Is.EqualTo(23.998m));
            Assert.That(funds.Ltc, Is.EqualTo(0m));

            var permissions = deserialized.Return.Permissions;
            Assert.That(permissions, Is.Not.Null);
            Assert.That(permissions.Information, Is.True);
            Assert.That(permissions.Trade, Is.True);

            Assert.That(deserialized.Return.TransactionCount, Is.EqualTo(80));
            Assert.That(deserialized.Return.OpenOrderCount, Is.EqualTo(1));
            Assert.That(deserialized.Return.ServerTime, Is.EqualTo(1342123547));
        }
    }
}
