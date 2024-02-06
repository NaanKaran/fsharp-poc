namespace PaymentService.Services

open AutoMapper
open PaymentService.Repository.Entity
open PaymentService.Types.ViewModel

module AutoMapping =
    let configureMappings () =
        let config =
            new MapperConfiguration(fun cfg ->
                cfg.CreateMap<LcoWallet, LcoWalletViewModel>().ReverseMap() |> ignore

                cfg.CreateMap<TransactionHistory, TransactionHistoryViewModel>().ReverseMap()
                |> ignore

                cfg.CreateMap<LcoWalletViewModel, TransactionHistoryViewModel>().ReverseMap()
                |> ignore)

        config.CreateMapper()
