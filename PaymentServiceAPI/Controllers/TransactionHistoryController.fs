namespace PaymentServiceAPI.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PaymentService.Repository
open PaymentService.Services


[<ApiController>]
[<Route("[controller]")>]
type TransactionHistoryController(logger: ILogger<TransactionHistoryController>) =
    inherit ControllerBase()


    [<HttpGet>]
    [<Route("getTransactionHistory/{transactionId}")>]
    member _.GetTransactionHistoryById(transactionId) =
        let history = TransactionHistoryRepository.getTransactionById transactionId
        history

    [<HttpPost>]
    [<Route("addTransactionHistory")>]
    member _.AddTransactionHistory(history) =
        let history = TransactionHistoryRepository.addWallet history
        history

    [<HttpPost>]
    [<Route("getTransactionHistory")>]
    member _.GetTransactionHistory(payload: TransactionHistoryRepository.Payload) =
        let history = TransactionHistoryRepository.getTransationHistory payload
        history

    [<HttpPost>]
    [<Route("addAndUpdateTransactionHistory")>]
    member _.AddAndUpdateTransactionHistory(history) =
        let history = TransactionHistoryService.addAndUpdateTransactionHistory history
        history

