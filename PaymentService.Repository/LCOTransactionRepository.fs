namespace PaymentService.Repository
open FSharp.Data
open PaymentService.Types.Enums
open System
open Dapper.FSharp.MSSQL

module LCOTransactionRepository =
    let GetFile = 
           let csv = CsvFile.Load("D:\\Tccl\\LCO\\LCODepositLedgerReport_2024-01-0512_01_02-0-1000000.csv")
           let csv1 = CsvFile.Load("D:\\Tccl\\LCO\\LCODepositLedgerReport_2024-01-0517_01_22-0-1000000.csv")
           let csv2 = CsvFile.Load("D:\\Tccl\\LCO\\LCODepositLedgerReport_2024-01-0517_01_32-0-1000000.csv")
           let allRows = Seq.concat [csv.Rows; csv1.Rows; csv2.Rows] 
           allRows

    let GetCreditTransaction =
            let csv = GetFile
            let sumOfCreditValues = csv
                                    |> Seq.toList
                                    |> Seq.filter (fun row -> not (String.IsNullOrWhiteSpace(row.Columns.[6])))
                                    |> Seq.sumBy (fun row -> row.Columns.[6] |> decimal)
            sumOfCreditValues
            
    let GetDebitTransaction business_name =
            let csv = GetFile
            let sumOfDebitValues = csv
                                    |> Seq.toList
                                    |> Seq.filter(fun row -> not (String.IsNullOrWhiteSpace(row.Columns.[1])) && 
                                                              match business_name with
                                                              | Some id -> row.Columns.[1] = id
                                                              | None -> false)
                                    |> Seq.filter (fun row -> not (String.IsNullOrWhiteSpace(row.Columns.[7])))
                                    |> Seq.sumBy (fun row -> row.Columns.[7] |> decimal)
            sumOfDebitValues

    let GetTotalAmount =
            let sumOfCreditValues = GetCreditTransaction
            let sumOfDebitValues = GetDebitTransaction None
            sumOfCreditValues - sumOfDebitValues


            
        