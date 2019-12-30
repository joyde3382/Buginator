namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        IProjectRepository Project { get; }
        ITicketRepository Ticket { get; }
        void Save();
    }
}