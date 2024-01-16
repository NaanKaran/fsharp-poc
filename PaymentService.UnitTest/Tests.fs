module Tests
 
open FSharp.Data
open System
open Xunit
open PaymentService.Repository
open Dapper.FSharp.MSSQL
open PaymentService.Repository.DBContext
open PaymentService.Repository.Entity
 
[<Fact>]
let ``My test`` () = Assert.True(true)
 
[<Fact>]
let ``Read Csv`` () =
    let csv =
        CsvFile.Load("D:\\Tccl\\LCO\\LCODepositLedgerReport_2024-01-0512_01_02-0-1000000.csv")
 
    let rows = csv.Rows
    let list = rows |> Seq.toList
    let firstRow = rows |> Seq.head
    let firstRowFirstColumn = firstRow.Columns
    Assert.True(true)
 
[<Fact>]
let ``Call GetAllTransaction`` () =
    let transactions = LCOTransactionRepository.GetCreditTransaction
    Assert.NotNull(transactions)
 
[<Fact>]
let ``Call Database`` () =
    let histories =
        select {
            for row in LcoWalletTable do
                selectAll
        }
        |> connection.SelectAsync<LcoWallet>
        |> Async.AwaitTask
        |> Async.RunSynchronously
 
    printfn "%A" histories
 
    Assert.NotNull(histories)