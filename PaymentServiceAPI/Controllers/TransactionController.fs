namespace PaymentServiceAPI.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PaymentService.Repository


[<ApiController>]
[<Route("[controller]")>]
type TransactionController(logger: ILogger<TransactionController>) =
    inherit ControllerBase()

    [<HttpGet>]
    [<Route("getHistory")>]
    member _.GetHistory() =
        let history = TransactionRepository.histories
        history

    [<HttpGet>]
    [<Route("getHistory/{business_name}")>]
    member _.GetHistory(business_name) =
        let history = TransactionRepository.getHistoryByBusinessName business_name
        history

    [<HttpPost>]
    [<Route("addHistory")>]
    member _.AddHistory(history) =
        let history = TransactionRepository.addHistory history
        history

    [<HttpPut>]
    [<Route("updateHistory")>]
    member _.UpdateHistory(history) =
        let history = TransactionRepository.updateHistory history
        history

    [<HttpDelete>]
    [<Route("updateHistory/{business_name}")>]
    member _.DeleteHistory(business_name) =
        let history = TransactionRepository.deleteHistory business_name
        history
