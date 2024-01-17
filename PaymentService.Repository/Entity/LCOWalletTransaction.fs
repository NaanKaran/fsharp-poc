namespace PaymentService.Repository.Entity

open System

type TransactionHistory =
    { LcoId: string
      BusinessName: string
      TransactionDate: DateTime
      TransactionAmount: decimal
      TransactionType: int
      TransactionId: string
      CreatedAt: DateTime
      UpdatedAt: DateTime
      Remarks: string }
