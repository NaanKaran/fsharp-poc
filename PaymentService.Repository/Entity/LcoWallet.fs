namespace PaymentService.Repository.Entity

open System

type LcoWallet =
    { LcoId: string
      BusinessName: string
      Balance: decimal
      LastTransactionDate: DateTime
      LastTransactionAmount: decimal
      LastTransactionType: int
      LastTransactionId: string
      CreatedAt: DateTime
      UpdatedAt: DateTime }
