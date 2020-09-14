﻿using devboost.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace devboost.Domain.Repository
{
    public interface IPedidoRepository
    {
        Task<Pedido> GetPedidoByPagamento(Guid pagamentoId);
        Task<List<Pedido>> GetPedidos(StatusPedido statusPedido);
        Task<List<Pedido>> GetPedidos(StatusPedido statusPedido, double distancia, int peso);
        Task AddPedido(Pedido pedido);
        Task UpdatePedido(Pedido pedido);
        Task AddPedidoDrone(PedidoDrone pedidoDrone);
    }
}
