using MediatR;

namespace ConferenceSuggest.PublishedLanguage.Events
{
    public class AccountMade: INotification
    {
        public string Name { get; set; }
    }
}