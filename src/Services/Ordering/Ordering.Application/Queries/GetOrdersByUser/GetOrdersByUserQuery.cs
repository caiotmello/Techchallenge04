using MediatR;

namespace Ordering.Application.Queries.GetOrdersByUser
{
    public class GetOrdersByUserQuery : IRequest<List<GetOrdersByUserQueryResponse>>
    {
        public string UserName { get; set; }

        public GetOrdersByUserQuery(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName)) ;
        }
    }
}
