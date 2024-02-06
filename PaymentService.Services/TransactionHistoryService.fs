namespace PaymentService.Services

open PaymentService.Repository
open PaymentService.Repository.Entity

module TransactionHistoryService =
    open AutoMapping
    open PaymentService.Types.ViewModel

    let addAndUpdateTransactionHistory (transactionHistory: TransactionHistory) =
        let autoMapper = configureMappings ()
        let history = TransactionHistoryRepository.addWallet transactionHistory

        let mappedHistory =
            autoMapper.Map<LcoWallet>(autoMapper.Map<LcoWalletViewModel>(history))

        let test = TransactionRepository.updateWallet mappedHistory
        history
