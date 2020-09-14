﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace devboost.Domain.Model
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public int Peso { get; set; }
        public DateTime DataHora { get; set; }
        public double DistanciaParaOrigem { get; set; }
        public StatusPedido StatusPedido { get; set; }

        [NotMapped]
        public string DescricaoStatus
        {
            get
            {
                switch (StatusPedido)
                {
                    case StatusPedido.aguardandoAprovacao:
                        return "Aguardando Aprovação";
                    case StatusPedido.reprovado:
                        return "Reprovado";
                    case StatusPedido.aguardandoEntrega:
                        return "Aguardando Entrega";
                    case StatusPedido.despachado:
                        return "Despachado";
                    case StatusPedido.entregue:
                        return "Entregue";
                    default:
                        return string.Empty;
                }
            }
        }

        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public Guid PagamentoCartaoId { get; set; }
        public PagamentoCartao PagamentoCartao { get; set; }

        public List<PedidoDrone> PedidosDrones { get; set; } = new List<PedidoDrone>();
    }

    public enum StatusPedido
    {
        aguardandoAprovacao = 0,
        reprovado = 1,
        aguardandoEntrega = 2,
        despachado = 3,
        entregue = 4
    }
}
