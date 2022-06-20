using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CB.Core.Domain.Commands
{
    public class EditCurrencyCommand : IRequest<string>
    {
        [Required]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? LongName { get; set; }
        public float ValueInUSD { get; set; }
    }
}
