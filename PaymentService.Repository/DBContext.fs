namespace PaymentService.Repository

open FSharp.Data.Sql

module DBContext =
    let [<Literal>] dbVendor = Common.DatabaseProviderTypes.MSSQLSERVER
    let [<Literal>] connString = "Server=tcp:tccl-dev-poc.database.windows.net,1433;Initial Catalog=PaymentService;Persist Security Info=False;User ID=tccl-admin;Password=jZP=*R&745jW;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
    let [<Literal>] connexStringName = "DefaultConnectionString"
    let [<Literal>] useOptTypes  = FSharp.Data.Sql.Common.NullableColumnType.OPTION
    type sql = SqlDataProvider<dbVendor, connString, UseOptionTypes = useOptTypes>
    let dbContext = sql.GetDataContext()

    let LcoWallet = dbContext.Dbo.LcoWallet;
    