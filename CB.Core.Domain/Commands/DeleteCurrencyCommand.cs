using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CB.Core.Domain.Commands
{
    public class DeleteCurrencyCommand : IRequest<string>
    {
        [Required]
        public Guid Id { get; set; }
    }
}
