namespace PaymentService.Repository

open Dapper.FSharp.MSSQL
open PaymentService.Repository.Entity


module TransactionHistoryRepository =
    type Payload =
        { PageNumber: int
          PageSize: int
          BusinessName: string }

    let getTransationHistory (pagination: Payload) =
        let arrayOfhistories =
            select {
                for row in DBContext.LcoTransactionTable do
                    where (row.BusinessName = pagination.BusinessName)
                    orderBy row.BusinessName
                    skip (pagination.PageNumber * pagination.PageSize)
                    take pagination.PageSize
                    selectAll

            }
            |> DBContext.connection.SelectAsync<TransactionHistory>
            |> Async.AwaitTask
            |> Async.RunSynchronously

        arrayOfhistories

    let getTransactionById transactionId =
        select {
            for row in DBContext.LcoTransactionTable do
                where (row.TransactionId = transactionId)
                select |> ignore
        }
        |> DBContext.connection.SelectAsync<TransactionHistory>
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let addWallet (transactionHistory: TransactionHistory) =
        insert {
            into DBContext.LcoTransactionTable
            value transactionHistory
        }
        |> DBContext.connection.InsertAsync
        |> Async.AwaitTask
        |> Async.RunSynchronously
