using MediatR;
using System.Collections.Generic;

namespace BjBygg.Application.Common.BaseEntityCommands.DeleteRange
{
    public abstract class DeleteRangeCommand : IRequest
    {
        public IEnumerable<int> Ids { get; set; }
    }
}