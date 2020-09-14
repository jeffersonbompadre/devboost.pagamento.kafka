﻿using devboost.Domain.Commands.Request;
using devboost.Domain.Model;
using System.Threading.Tasks;

namespace devboost.Domain.Handles.Commands.Interfaces
{
    public interface IPedidoHandler
    {
        Task<Pedido> RealizarPedido(RealizarPedidoRequest pedidoRequest, string userName);
        Task DistribuirPedido();
        Task AtualizaStatusPagamento(PagamentoCartao pagamento);
    }
}
