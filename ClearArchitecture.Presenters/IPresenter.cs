﻿using ClearArchitecture.UseCases.Common.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearArchitecture.Presenters
{
    public interface IPresenter<ResponseType,FormatType> : IOutputPort<ResponseType>
    {
        public FormatType Content { get; }
    }
}