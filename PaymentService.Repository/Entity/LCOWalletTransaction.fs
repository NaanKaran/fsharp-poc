namespace PaymentService.Repository.Entity

open PaymentService.Types.Enums
open System

type LCOWalletTransaction = {
    Id : Guid
    LcoId : string
    TransactionType : TransactionType
    TransactionAmount : decimal
    Balance : decimal
    CreatedOn : DateTime
}