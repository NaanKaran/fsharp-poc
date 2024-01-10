namespace PaymentService.Repository.Entity
open System
open PaymentService.Types.Enums

type LcoWallet = {
    Id: string
    LcoId: string
    BusinessName: string
    Balance: decimal
    LastTransactionDate: DateTime
    LastTransactionAmount: decimal
    LastTransactionType: TransactionType
    LastTransactionId: string
    CreatedAt: DateTime
    UpdatedAt: DateTime
}