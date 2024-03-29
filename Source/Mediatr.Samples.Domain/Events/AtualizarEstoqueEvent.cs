﻿using Commander.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr.Samples.Domain.Events
{
    public class AtualizarEstoqueEvent : Event
    {
        protected AtualizarEstoqueEvent()
        {
        }

        public AtualizarEstoqueEvent(Guid produtoId)
        {
            ProdutoId = produtoId;
            Quantidade = 1;
        }

        public Guid ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
