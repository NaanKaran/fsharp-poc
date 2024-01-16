namespace PaymentService.Repository.Entity

open System

type TransactionHistory =
    { Id: string
      LcoId: string
      BusinessName: string
      TransactionDate: DateTime
      TransactionAmount: decimal
      TransactionType: int
      TransactionId: string
      CreatedAt: DateTime
      UpdatedAt: DateTime

    }
