namespace PaymentServiceAPI.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open PaymentServiceAPI
open PaymentService.Repository


[<ApiController>]
[<Route("[controller]")>]
type PaymentController (logger : ILogger<PaymentController>) =
    inherit ControllerBase()

    [<HttpGet>]
    [<Route("GetCredit")>]
    member _.GetCredit() =
       let credit = LCOTransactionRepository.GetCreditTransaction
       credit
        
    [<HttpGet("creditdebit")>]
    member _.GetDebit([<FromQuery>] business_name) =
       let debit = LCOTransactionRepository.GetDebitTransaction business_name
       debit
    
    [<HttpGet>]
    [<Route("GetTotal")>]
    member _.GetTotal() =
       let total = LCOTransactionRepository.GetTotalAmount
       total
