namespace PaymentService.Repository

open Dapper.FSharp.MSSQL
open PaymentService.Repository.Entity


module TransactionRepository =
    type Pagination = { PageNumber: int; PageSize: int }

    let getWalletList (pagination: Pagination) =
        let arrayOfhistories =
            select {
                for row in DBContext.LcoWalletTable do
                    orderBy row.BusinessName
                    skip (pagination.PageNumber * pagination.PageSize)
                    take pagination.PageSize
                    selectAll

            }
            |> DBContext.connection.SelectAsync<LcoWallet>
            |> Async.AwaitTask
            |> Async.RunSynchronously

        arrayOfhistories

    let getWalletByBusinessName business_name =
        select {
            for row in DBContext.LcoWalletTable do
                where (row.BusinessName = business_name)
                selectAll
        }
        |> DBContext.connection.SelectAsync<LcoWallet>
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let addWallet (wallet: LcoWallet) =
        insert {
            into DBContext.LcoWalletTable
            value wallet
        }
        |> DBContext.connection.InsertAsync
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let updateWallet (wallet: LcoWallet) =
        update {
            for row in DBContext.LcoWalletTable do
                set wallet
                where (row.BusinessName = wallet.BusinessName)
        }
        |> DBContext.connection.UpdateAsync
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let deleteWallet business_name =
        delete {
            for row in DBContext.LcoWalletTable do
                where (row.BusinessName = business_name)
        }
        |> DBContext.connection.DeleteAsync
        |> Async.AwaitTask
        |> Async.RunSynchronously
