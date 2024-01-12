namespace PaymentServiceAPI.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PaymentService.Repository


[<ApiController>]
[<Route("[controller]")>]
type TransactionController(logger: ILogger<TransactionController>) =
    inherit ControllerBase()

    [<HttpPost>]
    [<Route("getHistory")>]
    member _.GetHistory(payload: TransactionRepository.Pagination) =
        let history = TransactionRepository.histories payload
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
