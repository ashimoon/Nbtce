using NBtce.Attributes;

namespace NBtce.Model
{
    [JsonEnum]
    public enum TradingPair
    {
        [JsonEnumValue("btc_usd")]
        BtcUsd,
        [JsonEnumValue("btc_rur")]
        BtcRur,
        [JsonEnumValue("btc_eir")]
        BtcEur,
        [JsonEnumValue("ltc_btc")]
        LtcBtc,
        [JsonEnumValue("ltc_usd")]
        LtcUsd,
        [JsonEnumValue("ltc_rur")]
        LtcRur,
        [JsonEnumValue("nmc_btc")]
        NmcBtc,
        [JsonEnumValue("nvc_btc")]
        NvcBtc,
        [JsonEnumValue("usd_rur")]
        UsdRur,
        [JsonEnumValue("eur_usd")]
        EurUsd,
        [JsonEnumValue("trc_btc")]
        TrcBtc,
        [JsonEnumValue("ppc_btc")]
        PpcBtc,
        [JsonEnumValue("ftc_btc")]
        FtcBtc
    }
}