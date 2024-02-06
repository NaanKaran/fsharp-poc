namespace PaymentService.Types

module ViewModel =
    open System
    type Pagination = { PageNumber: int; PageSize: int }

    type Payload =
        { PageNumber: int
          PageSize: int
          BusinessName: string }

    type TransactionHistoryViewModel =
        { LcoId: string
          BusinessName: string
          TransactionDate: DateTime
          TransactionAmount: decimal
          TransactionType: int
          TransactionId: string
          CreatedAt: DateTime
          UpdatedAt: DateTime
          Remarks: string }


    type LcoWalletViewModel =
        { LcoId: string
          BusinessName: string
          Balance: decimal
          LastTransactionDate: DateTime
          LastTransactionAmount: decimal
          LastTransactionType: int
          LastTransactionId: string
          CreatedAt: DateTime
          UpdatedAt: DateTime }
