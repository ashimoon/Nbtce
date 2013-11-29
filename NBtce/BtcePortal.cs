using System;
using NBtce.Model;
using NBtce.Requests;

namespace NBtce
{
    public class BtcePortal
    {
        private readonly string _apiKey;
        private readonly string _secret;
        private readonly NonceProvider _nonceProvider;

        public BtcePortal(string apiKey, string secret)
        {
            _apiKey = apiKey;
            _secret = secret;
            _nonceProvider = new NonceProvider();
        }

        public UserInfo GetUserInfo()
        {
            return SubmitRequest<GetInfoRequest, UserInfo>(new GetInfoRequest());
        }

        public ActiveOrders GetActiveOrders(TradingPair? tradingPair = null)
        {
            return SubmitRequest<ActiveOrdersRequest, ActiveOrders>(new ActiveOrdersRequest()
                {
                    TradingPair = tradingPair
                });
        }

        public TradeHistory GetTradeHistory(
            int? fromId = null,
            int? endId = null,
            SortOrder? sortOrder = null,
            int? count = null,
            DateTime? since = null,
            DateTime? until = null,
            TradingPair? tradingPair = null)
        {
            return SubmitRequest<TradeHistoryRequest, TradeHistory>(new TradeHistoryRequest()
                {
                    FromId = fromId,
                    EndId = endId,
                    SortOrder = sortOrder,
                    Count = count,
                    Since = since,
                    Until = until,
                    TradingPair = tradingPair
                });
        }

        public TransactionHistory GetTransactionHistory(
            int? fromId = null,
            int? endId = null,
            int? count = null,
            SortOrder? sortOrder = null,
            DateTime? since = null,
            DateTime? until = null)
        {
            return SubmitRequest<TransactionHistoryRequest, TransactionHistory>(new TransactionHistoryRequest()
                {
                    FromId = fromId,
                    EndId = endId,
                    Count = count,
                    SortOrder = sortOrder,
                    Since = since,
                    Until = until
                });
        }

        public TradeReceipt SubmitTrade(
            TradingPair pair,
            TradeType type,
            decimal rate,
            decimal amount)
        {
            return SubmitRequest<TradeRequest, TradeReceipt>(new TradeRequest(
                                                                 pair, type, rate, amount));
        }

        public CancelResponse CancelTrade(int orderId)
        {
            return SubmitRequest<CancelOrderRequest, CancelResponse>(new CancelOrderRequest(orderId));
        }

        private TResponse SubmitRequest<TRequest, TResponse>(TRequest request) where TRequest : ApiRequest<TResponse>
        {
            ApiResponse<TResponse> apiResponse;
            try
            {
                apiResponse = request.Submit(_apiKey, _secret, _nonceProvider);
            }
            catch (Exception ex)
            {
                throw new BtcePortalException(
                    string.Format("There was an error submitting request of type {0}", typeof (TRequest)), ex);
            }
            if (!apiResponse.Success)
            {
                throw new BtcePortalException(
                    string.Format("Server returned an error: " + apiResponse.ErrorText));
            }
            return apiResponse.Return;
        }
    }
}