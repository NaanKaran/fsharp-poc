namespace PaymentService.Repository.Entity
open System
open PaymentService.Types.Enums

type LcoWallet = {
    Id: int 
    LcoId: string
    BusinessName: string
    Balance: decimal
    LastTransactionDate: DateTime
    LastTransactionAmount: decimal
    LastTransactionType: int
    LastTransactionId: string
    CreatedAt: DateTime
    UpdatedAt: DateTime
}