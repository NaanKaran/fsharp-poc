namespace PaymentServiceAPI.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PaymentService.Repository


[<ApiController>]
[<Route("[controller]")>]
type TransactionController(logger: ILogger<TransactionController>) =
    inherit ControllerBase()

    [<HttpPost>]
    [<Route("getWallet")>]
    member _.GetWallet(payload: TransactionRepository.Pagination) =
        let wallet = TransactionRepository.getWalletList payload
        wallet

    [<HttpGet>]
    [<Route("getWallet/{business_name}")>]
    member _.GetWallet(business_name) =
        let wallet = TransactionRepository.getWalletByBusinessName business_name
        wallet

    [<HttpPost>]
    [<Route("addWallet")>]
    member _.AddWallet(wallet) =
        let wallet = TransactionRepository.addWallet wallet
        wallet

    [<HttpPut>]
    [<Route("updateWallet")>]
    member _.UpdateWallet(wallet) =
        let wallet = TransactionRepository.updateWallet wallet
        wallet

    [<HttpDelete>]
    [<Route("updateWallet/{business_name}")>]
    member _.DeleteWallet(business_name) =
        let history = TransactionRepository.deleteWallet business_name
        history
