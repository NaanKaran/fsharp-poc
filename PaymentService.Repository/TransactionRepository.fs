namespace PaymentService.Repository

open Dapper.FSharp.MSSQL
open PaymentService.Repository.Entity


module TransactionRepository =
    let histories =
        select {
            for row in DBContext.TransactionHistoryTable do
                selectAll
        }
        |> DBContext.connection.SelectAsync<LcoWallet>
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let getHistoryByBusinessName business_name =
        select {
            for row in DBContext.TransactionHistoryTable do
                where (row.BusinessName = business_name)
                selectAll
        }
        |> DBContext.connection.SelectAsync<LcoWallet>
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let addHistory (history: LcoWallet) =
        insert {
            into DBContext.TransactionHistoryTable
            value history
        }
        |> DBContext.connection.InsertAsync
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let updateHistory (history: LcoWallet) =
        update {
            for row in DBContext.TransactionHistoryTable do
                set history
                where (row.BusinessName = history.BusinessName)
        }
        |> DBContext.connection.UpdateAsync
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let deleteHistory business_name =
        delete {
            for row in DBContext.TransactionHistoryTable do
                where (row.BusinessName = business_name)
        }
        |> DBContext.connection.DeleteAsync
        |> Async.AwaitTask
        |> Async.RunSynchronously
