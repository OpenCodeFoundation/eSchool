using MediatR;

namespace OpenCodeFoundation.ESchool.Services.Joining.API.Application.Commands
{
    public class JoinApplicationCommand
        : IRequest<bool>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }
    }
}

