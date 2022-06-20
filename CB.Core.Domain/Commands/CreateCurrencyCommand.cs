using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CB.Core.Domain.Commands
{
    public class CreateCurrencyCommand : IRequest<string>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float ValueInUSD { get; set; }
    }
}
