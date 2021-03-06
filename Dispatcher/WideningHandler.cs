﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging
{
    public class WideningHandler<TDerived, TBase> : IHandle<TBase>
        where TDerived : TBase
        where TBase : Message
    {
        private IHandle<TDerived> _handler;

        public WideningHandler(IHandle<TDerived> handler)
        {
            _handler = handler;
        }

        public void Handle(TBase message)
        {
            _handler.Handle(message as TDerived);
        }
    }
}
