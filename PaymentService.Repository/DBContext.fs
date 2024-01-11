namespace PaymentService.Repository
 
open System.Data
open System.Data.SqlClient
open PaymentService.Repository.Entity
 
module DBContext =
    open Dapper.FSharp.MSSQL
 
    let connection: IDbConnection =
        new SqlConnection(
            "Server=tcp:tccl-dev-poc.database.windows.net,1433;Initial Catalog=PaymentService;Persist Security Info=False;User ID=tccl-admin;Password=jZP=*R&745jW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
        )
 
        // for MSSQL
    Dapper.FSharp.MSSQL.OptionTypes.register()
    let TransactionHistoryTable = table<LcoWallet>